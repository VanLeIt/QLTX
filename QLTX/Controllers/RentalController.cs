using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;
using QLTX.ViewModels;

namespace QLTX.Controllers;

public class RentalController : Controller
{
	private readonly QLTXDbContext _context;

	public RentalController(QLTXDbContext context)
	{
		_context = context;
	}
 
    public async Task<IActionResult> Index()
    {
        if (TempData.ContainsKey("SuccessMessage"))
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
        }
        else
        {
            ViewBag.SuccessMessage = TempData["ErrorMessage"];
        }
        

		var rentals = await _context.Rentals
							.Where(a => a.IsDelete == false)
							.Include(r => r.Customer)
							.Include(r => r.RentlDetails)
							.ThenInclude(rd => rd.EMotorbike)
							.OrderByDescending(r => r.CreationTime)
							.ToListAsync();

		 
		foreach (var rental in rentals)
		{
			if (rental.DateRetalTo < DateTime.Now && rental.Status == RentalStatus.Renting )
			{
				rental.Status = RentalStatus.Expired;
				_context.Update(rental);
			}
		}

		await _context.SaveChangesAsync();  

		return View(rentals);
	}

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Rentals == null)
        {
            return NotFound();
        }
        var rent = await _context.Rentals.Where(a => a.IsDelete == false).Include(r => r.Customer)
            .Include(r => r.RentlDetails)
            .ThenInclude(rd => rd.EMotorbike)
            .ThenInclude(t=> t.TypeMotorbike)
                .FirstOrDefaultAsync(m => m.Id == id);
        if (rent == null)
        {
            return NotFound();
        }
        return View(rent);
    }

    private string? GetEnumDisplayName(Enum enumValue)
	{
		var displayAttribute = enumValue.GetType()
										.GetMember(enumValue.ToString())
										.First()
										.GetCustomAttribute<DisplayAttribute>();
		return displayAttribute is not null ? displayAttribute.Name : enumValue.ToString();
	}
   
    public async Task<IActionResult> CreateAsync()
    {
		 
		var emotors = _context.EMotorbikes.Include(a=> a.TypeMotorbike).Where(e => e.Status == EMotorbikeStatus.Ready && e.IsDelete == false).ToList();  
        
        ViewData["IdCustomer"] = new SelectList(_context.Customers.Where(a => a.IsDelete == false).Select(c => new { Id = c.Id, FullName = $"{c.Name} - {c.IdDocument}" }), "Id", "FullName"); 
        var viewModel = new CreateRental
        {
            Emotors = emotors,
			 
		};

        return View(viewModel);
    }



    [HttpPost]
    public async Task<IActionResult> Create(CreateRental viewModel)
    {
        if (!ModelState.IsValid)
        {
              
            var rental = new Rental
            {
                CustomerId = viewModel.IdCustomer,
                DateRetalFrom = viewModel.DateRetalFrom,
                DateRetalTo = viewModel.DateRetalTo,
                RetalTime = viewModel.RetalTime,
                Service = viewModel.Service,
                Price = viewModel.Price,
                Total = viewModel.Total,
                Note = viewModel.Note,
                CreatedBy = User.Identity.Name,
                CreationTime = DateTime.Now,
                IsDelete = false
            };

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            if (viewModel.EmotorIds != null && viewModel.EmotorIds.Any())
            {
                
				var ids = viewModel.EmotorIds.Split(',')
							 .Select(int.Parse)
							 .ToArray();
				var rentalDetails = new List<RentalDetail>();
                foreach (var emotorId in ids)
                {
                    var rentalDetail = new RentalDetail
                    {
                        RentalId = rental.Id,
                        EMotorbileId = emotorId
                    };
                    
                    var motor = _context.EMotorbikes.FirstOrDefault(x => x.Id == emotorId);
                    if (motor != null)
                    {
                        motor.Status = EMotorbikeStatus.Renting;
                    }
					_context.RentalDetails.Add(rentalDetail);
					await _context.SaveChangesAsync();

				}
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

            return RedirectToAction("Index");
        }

        ViewData["IdCustomer"] = new SelectList(_context.Customers.Where(a => a.IsDelete == false).Select(c => new { Id = c.Id, FullName = $"{c.Name} - {c.IdDocument}" }), "Id", "FullName", viewModel.IdCustomer);
        viewModel.Emotors = _context.EMotorbikes.Where(e => e.Status == EMotorbikeStatus.Ready && e.IsDelete == false).ToList();
        return View(viewModel);
    }

	public async Task<IActionResult> Edit(int? id)
	{
		var rental = await _context.Rentals.FindAsync(id);
		 
		var emotors = _context.EMotorbikes.Where(e => e.Status == EMotorbikeStatus.Ready && e.IsDelete == false).ToList();
		ViewData["IdCustomer"] = new SelectList(_context.Customers.Where(a => a.IsDelete == false).Select(c => new { Id = c.Id, FullName = $"{c.Name} - {c.IdDocument}" }), "Id", "FullName");
		var viewModel = new CreateRental
		{
			IdCustomer = rental.CustomerId,
			DateRetalFrom = rental.DateRetalFrom,
            DateRetalTo = rental.DateRetalTo,
			RetalTime = rental.RetalTime,
			Service = rental.Service,
			Price = rental.Price,
			Total = rental.Total,
			Note = rental.Note, 
		};

		return View(viewModel);
		 
	}

	[HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,DateRetalFrom,DateRetalTo,RetalTime,Status,Service,Note")] CreateRental rental)
    {
        if (id != rental.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            try
            {
                var originalRental = await _context.Rentals 
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (originalRental == null || originalRental.IsDelete)
                {
                    return NotFound();
                } 
                originalRental.DateRetalFrom = rental.DateRetalFrom;
                originalRental.DateRetalTo = rental.DateRetalTo;
                originalRental.Service = rental.Service;
                originalRental.RetalTime = rental.RetalTime;
                originalRental.Note = rental.Note;
                originalRental.UpdatedBy = User.Identity.Name;
                originalRental.UpdationTime = DateTime.Now;
                if(rental.DateRetalTo > DateTime.Now)
                {
					originalRental.Status = RentalStatus.Renting;
				}
                  
                _context.Update(originalRental);
                await _context.SaveChangesAsync(); 
                TempData["SuccessMessage"] = "Cập nhật thành công.";
				return RedirectToAction(nameof(Index));
			}
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            } 
        }

        return View(rental);
    }


    public JsonResult Delete(int id)
    {
        bool result = false;

        var company = _context.Rentals.Find(id);
		var emotor = _context.RentalDetails.Where(a => a.RentalId == id).ToList();
		if (company != null)
        {
            result = true;
             
            company.IsDelete = true;
			foreach (var detail in emotor)
			{
				var emoto = _context.EMotorbikes.Find(detail.EMotorbileId);
				if (emoto != null)
				{
					emoto.Status = EMotorbikeStatus.Ready;  
				}
			}
			_context.SaveChanges();
            TempData["SuccessMessage"] = "Đã xóa thành công.";
        }
        return Json(result);
    }


    public JsonResult CancelStatus(int id )
    {
		bool result = false;

		var rentalStatus = _context.Rentals.Find(id);
		var emotor = _context.RentalDetails.Where(a => a.RentalId == id).ToList();
		if (rentalStatus != null)
		{
			result = true;

			rentalStatus.Status = RentalStatus.Cancel;
			foreach (var detail in emotor)
			{
				var emoto = _context.EMotorbikes.Find(detail.EMotorbileId);
				if (emoto != null)
				{
					emoto.Status = EMotorbikeStatus.Ready;  
				}
			}
			_context.SaveChanges();
			TempData["SuccessMessage"] = "Hủy đơn thuê thành công.";
		}
		return Json(result);
	}

	public async Task<JsonResult> SuccessStatusAsync(int id )
	{
		bool result = false;
       
		var rentalStatus = _context.Rentals.Find(id);
        var emotor = _context.RentalDetails.Where(a=>a.RentalId == id).ToList();
		if (rentalStatus != null)
		{
			result = true;

			rentalStatus.Status = RentalStatus.Success;
			foreach (var detail in emotor)
			{
				var emoto = _context.EMotorbikes.Find(detail.EMotorbileId);
				if (emoto != null)
				{
					emoto.Status = EMotorbikeStatus.Ready;  
				}
			}
			_context.SaveChanges();
			TempData["SuccessMessage"] = "Đã hoàn thành đơn thuê.";
		}
		return Json(result);
	}
	public async Task<Store> GetConfigAsync()
	{
		return await _context.Stores.FirstOrDefaultAsync();
	}
}
