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
        return _context.Rentals != null ?
                      View(await _context.Rentals.Where(a => a.IsDelete == false).Include(r => r.Customer)
            .Include(r => r.RentlDetails)
            .ThenInclude(rd => rd.EMotorbike)
            .ToListAsync()) :
                      Problem("Không có bản ghi nào.");
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
		var config = await _context.Configs.FirstOrDefaultAsync();
		var emotors = _context.EMotorbikes.Where(e => e.Status == EMotorbikeStatus.Ready).ToList();  
        ViewData["IdCustomer"] = new SelectList(_context.Customers.Where(a => a.IsDelete == false).Select(c => new { Id = c.Id, FullName = $"{c.Name} - {c.IdDocument}" }), "Id", "FullName"); 
        var viewModel = new CreateRental
        {
            Emotors = emotors,
			Config = config
		};

        return View(viewModel);
    }

     

    [HttpPost]
    public async Task<IActionResult> Create(CreateRental viewModel)
    {
        if (!ModelState.IsValid)
        {
			var config = await _context.Configs.FirstOrDefaultAsync();
			if (config != null)
			{
				switch (viewModel.Service)
				{
					case RentalService.Hour:
						viewModel.Price = (double)config.PriceHour;
						break;
					case RentalService.Day:
						viewModel.Price = (double)config.PriceDay;
						break;
					case RentalService.Week:
						viewModel.Price = (double)config.PriceWeek;
						break;
					default:
						break;
				}
			}

			var rental = new Rental
            {
                CustomerId = viewModel.IdCustomer,
                DateRetalFrom = viewModel.DateRetalFrom,
                DateRetalTo = viewModel.DateRetalTo,
                RetalTime = viewModel.RetalTime,
                Service = viewModel.Service,
                Price = viewModel.Price,
                Note = viewModel.Note,
                CreatedBy = User.Identity.Name,
                CreationTime = DateTime.Now,
               
                IsDelete = false
                 
            };

            _context.Rentals.Add(rental);
             await _context.SaveChangesAsync();
			if (viewModel.EmotorIds != null && viewModel.EmotorIds.Any())
			{
				foreach (var emotorId in viewModel.EmotorIds)
				{
					var rentalDetail = new RentalDetail
					{
						RentalId = rental.Id,
						EMotorbileId = emotorId
					};

					_context.RentalDetails.Add(rentalDetail);
				}

				await _context.SaveChangesAsync();
			}
            return RedirectToAction("Index");
        }
        ViewData["IdCustomer"] = new SelectList(_context.Customers.Where(a => a.IsDelete == false).Select(c => new { Id = c.Id, FullName = $"{c.Name} - {c.IdDocument}" }), "Id", "FullName" , viewModel.IdCustomer); 
        viewModel.Emotors = _context.EMotorbikes.Where(e => e.Status == EMotorbikeStatus.Ready).ToList();
        return View(viewModel);
    }

    public JsonResult Delete(int id)
    {
        bool result = false;

        var company = _context.Rentals.Find(id);
        if (company != null)
        {
            result = true;
             
            company.IsDelete = true;
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Đã xóa thành công.";
        }
        return Json(result);
    }

	public async Task<Config> GetConfigAsync()
	{
		return await _context.Configs.FirstOrDefaultAsync();
	}
}
