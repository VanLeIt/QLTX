using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QLTX.Data;
using QLTX.Models;
using QLTX.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace QLTX.Controllers;

public class RentalController : Controller
{
    private readonly QLTXDbContext _context;

    public RentalController(QLTXDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(/*RentalStatus? status*/)
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
         
        /*if (status.HasValue)
        {
            rentalsQuery = rentalsQuery.Where(r => r.Status == status.Value);
        }

        var rentals = await rentalsQuery.ToListAsync();*/

        foreach (var rental in rentals)
        {
            if (rental.DateRetalTo < DateTime.Now && rental.Status == RentalStatus.Renting)
            {
                rental.Status = RentalStatus.Expired;
                _context.Update(rental);
            }
        }

        await _context.SaveChangesAsync();

        return View(rentals);
    }

	public async Task<IActionResult> IndexBill(DateTime? startDate, DateTime? endDate)
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
							.Where(a => a.IsDelete == false && a.Status== RentalStatus.Success)
							.Include(r => r.Customer)
							.Include(r => r.RentlDetails)
							.ThenInclude(rd => rd.EMotorbike)
							.OrderByDescending(r => r.CreationTime)
							.ToListAsync();


		foreach (var rental in rentals)
		{
			if (rental.DateRetalTo < DateTime.Now && rental.Status == RentalStatus.Renting)
			{
				rental.Status = RentalStatus.Expired;
				_context.Update(rental);
			}
		}

		await _context.SaveChangesAsync();
		ViewBag.DailyRevenue = rentals
		.Where(r => r.CreationTime.Date == DateTime.Now.Date)
		.Sum(r => r.SumTotal);

		ViewBag.CustomRangeRevenue = rentals
			.Where(r => r.CreationTime >= startDate && r.CreationTime <= endDate)
			.Sum(r => r.SumTotal);

		ViewBag.MonthlyRevenue = rentals
			.Where(r => r.CreationTime.Month == DateTime.Now.Month && r.CreationTime.Year == DateTime.Now.Year)
			.Sum(r => r.SumTotal);
		return View(rentals);
	}


    public async Task<IActionResult> GetRevenueReport(DateTime? startDate, DateTime? endDate, string period)
    {
        var rentals = await _context.Rentals
            .Where(a => a.IsDelete == false && a.Status == RentalStatus.Success)
            .ToListAsync();

        float revenue = 0;

        switch (period)
        {
            case "today":
                revenue = rentals
                    .Where(r => r.CreationTime.Date == DateTime.Now.Date)
                    .Sum(r => r.SumTotal);
                break;
            case "week":
                var last7Days = DateTime.Now.Date.AddDays(-6); // Lấy ngày cách đây 6 ngày từ hôm nay
                revenue = rentals
                    .Where(r => r.CreationTime.Date >= last7Days && r.CreationTime.Date <= DateTime.Now.Date)
                    .Sum(r => r.SumTotal);
                break;
            case "month":
                var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                revenue = rentals
                    .Where(r => r.CreationTime >= startOfMonth && r.CreationTime <= endOfMonth)
                    .Sum(r => r.SumTotal);
                break;
            case "custom":
                if (startDate.HasValue && endDate.HasValue)
                {
                    revenue = rentals
                        .Where(r => r.CreationTime.Date >= startDate.Value.Date && r.CreationTime.Date <= endDate.Value.Date)
                        .Sum(r => r.SumTotal);
                }
                break;
        }

        return Json(new { revenue = revenue });
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
            .ThenInclude(t => t.TypeMotorbike)
                .FirstOrDefaultAsync(m => m.Id == id);
        if (rent == null)
        {
            return NotFound();
        }
        return View(rent);
    }

	public async Task<IActionResult> DetailBill(int? id)
	{
		if (id == null || _context.Rentals == null)
		{
			return NotFound();
		}
		var rent = await _context.Rentals.Where(a => a.IsDelete == false).Include(r => r.Customer)
			.Include(r => r.RentlDetails)
			.ThenInclude(rd => rd.EMotorbike)
			.ThenInclude(t => t.TypeMotorbike)
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

        var emotors = _context.EMotorbikes.Include(a => a.TypeMotorbike).Where(e => e.Status == EMotorbikeStatus.Ready && e.IsDelete == false).ToList();

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
    public async Task<IActionResult> Edit(int id,  CreateRental rental)
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
                originalRental.Price = rental.Price;
                originalRental.Total = rental.Total;
                originalRental.UpdationTime = DateTime.Now;
                if (rental.DateRetalTo > DateTime.Now)
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


    public JsonResult CancelStatus(int id)
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

    /*public async Task<JsonResult> SuccessStatusAsync(int id )
	{
		bool result = false;
       
		var rentalStatus = _context.Rentals.Find(id);
        var emotor = _context.RentalDetails.Where(a=>a.RentalId == id).ToList();
		if (rentalStatus != null)
		{
			result = true;

			
            if (rentalStatus.Status == RentalStatus.Expired)
            {
                TimeSpan overdueTime = DateTime.Now - rentalStatus.DateRetalTo;
                float totalHours = (float)Math.Ceiling(overdueTime.TotalHours);
                 rentalStatus.LateFee = (float?)(totalHours * 1.5 * rentalStatus.Price);
                
            }
            rentalStatus.Total = (float)(rentalStatus.Total + rentalStatus.LateFee);
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
	}*/

    public async Task<JsonResult> SuccessStatusAsync(int id)
    {
        bool result = false;

        var rental = _context.Rentals.Find(id);
        var emotor = _context.RentalDetails.Where(a => a.RentalId == id).ToList();

        if (rental != null)
        {
            result = true;

            if (rental.Status == RentalStatus.Expired)
            {
                TimeSpan overdueTime = DateTime.Now - rental.DateRetalTo;
				float totalHours = (float)overdueTime.TotalHours;
				if (totalHours < 1)
				{
					totalHours = (float)Math.Ceiling(totalHours);
				}
				else
				{
					totalHours = (float)Math.Round(totalHours);
				}
				//float totalHours = (float)Math.Round(overdueTime.TotalHours);
                float totalDays = (float)overdueTime.TotalDays;
                float totalWeeks = totalDays / 7;
                float lateFee = 0;

                switch (rental.Service)
                {
                    case RentalService.Hour:
                        if (totalHours < 10)
                        {
                            lateFee = totalHours * 1.5f * rental.Price;
                        }
                        else if (totalHours < 144)
                        {
                            lateFee = rental.Price * 10 * 1.5f * totalDays;
                        }
                        else
                        {
                            lateFee = rental.Price * 10 * 6 * 1.5f * totalWeeks;
                        }
                        break;

                    case RentalService.Day:
                        if (totalHours < 10)
                        {
                            lateFee = totalHours * 1.5f * (rental.Price / 10);
                        }
                        else if (totalHours < 144)
                        {
                            lateFee = rental.Price * 1.5f * totalDays;
                        }
                        else
                        {
                            lateFee = rental.Price * 6 * 1.5f * totalWeeks;
                        }
                        break;

                    case RentalService.Week:
                        if (totalHours < 10)
                        {
                            lateFee = totalHours * 1.5f * (rental.Price / 10 / 6);
                        }
                        else if (totalHours < 144)
                        {
                            lateFee = (rental.Price / 6) * 1.5f * totalDays;
                        }
                        else
                        {
                            lateFee = rental.Price * 1.5f * totalWeeks;
                        }
                        break;
                }
                string overdueTimeString;
                if (overdueTime.TotalMinutes < 60)
                {
                    overdueTimeString = $"{overdueTime.Minutes} phút";
                }
                else if (overdueTime.TotalHours < 24)
                {
                    overdueTimeString = $"{overdueTime.Hours} giờ, {overdueTime.Minutes} phút";
                }
                else
                {
                    overdueTimeString = $"{overdueTime.Days} ngày, {overdueTime.Hours % 24} giờ, {overdueTime.Minutes} phút";
                }

                rental.ExpiredTime = overdueTimeString;
                //rentalStatus.LateFee = lateFee;
                //rental.ExpiredTime = overdueTime.ToString();
                rental.DateExpired = DateTime.Now;
                rental.LateFee = RoundToNear(lateFee, 500);
            }
             
            rental.SumTotal = (float)(rental.Total + (rental.LateFee.HasValue ? rental.LateFee : 0)  + (rental.TotalBroken.HasValue  ? rental.TotalBroken : 0 ));
            rental.Status = RentalStatus.Success;

            foreach (var detail in emotor)
            {
                var emoto = _context.EMotorbikes.Find(detail.EMotorbileId);
                if (emoto != null && emoto.Status != EMotorbikeStatus.Broken)
                {
                    emoto.Status = EMotorbikeStatus.Ready;
                }
            }

            _context.SaveChanges();
            TempData["SuccessMessage"] = "Đã hoàn thành đơn thuê.";
        }

        return Json(result);
    }

    public async Task<IActionResult> RentalBroken(int id)
    {
        var rental = await _context.Rentals.FindAsync(id);
        var rentalVM = new RentalBroken()
        {
            DetailBroken = rental.DetailBroken,
            TotalBroken = rental.TotalBroken
        };

		return View(rentalVM);
    }

    [HttpPost]
    public async Task<IActionResult> ChangStatus(int id, RentalBroken rental)
    {
        // var rental = await _context.Rentals.FindAsync(id);
        if (id != rental.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                var emotor = _context.RentalDetails.Where(a => a.RentalId == id).ToList();
                var originalRental = await _context.Rentals
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (originalRental == null || originalRental.IsDelete)
                {
                    return NotFound();
                }
                originalRental.DetailBroken = rental.DetailBroken;
                originalRental.TotalBroken = rental.TotalBroken;

                foreach (var detail in emotor)
                {
                    var emoto = _context.EMotorbikes.Find(detail.EMotorbileId);
                    if (emoto != null)
                    {
                        emoto.Status = EMotorbikeStatus.Broken;
                    }
                }
                // _context.SaveChanges();
                _context.Update(originalRental);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Báo hỏng xe thành công.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        return View(rental);
      
    }

     

    private float RoundToNear(float amount, float nearest)
    {
        return (float)(Math.Round(amount / nearest) * nearest);
    }


}
