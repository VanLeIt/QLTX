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

	public IActionResult Index()
	{
		return View();
	}
	//[HttpPost]
	//public IActionResult Createaa(Rental model)
	//{
	//	if (ModelState.IsValid)
	//	{
	//		// Kiểm tra xem khách hàng đã tồn tại trong cơ sở dữ liệu chưa
	//		var existingCustomer = _context.Customers.FirstOrDefault(c => c.Id == model.CustomerId);
	//		if (existingCustomer == null)
	//		{
				  
	//			// Lưu khách hàng mới vào cơ sở dữ liệu
	//			//_context.Customers.Add(newCustomer);
	//			//_context.SaveChanges();

	//			// Sử dụng khách hàng mới để tạo đối tượng đơn thuê
	//			var rental = new Rental
	//			{
	//				//CustomerId = newCustomer.Id,
	//				UserId = User.Identity.Name,
	//				DateRetalFrom = model.DateRetalFrom,
	//				DateRetalTo = model.DateRetalTo,
	//				RetalTime = model.RetalTime,
	//				Service = model.Service,
	//				Price = model.Price,
	//				Status = RentalStatus.Renting, // Mặc định đang thuê
	//				Total = model.Total,
	//				Note = model.Note,
	//				CreatedBy = User.Identity.Name,
	//				CreationTime = DateTime.Now
	//				// Bạn có thể thêm các trường còn lại tương tự ở đây
	//			};

	//			// Lưu đối tượng đơn thuê vào cơ sở dữ liệu
	//			_context.Rentals.Add(rental);
	//			_context.SaveChanges();
	//		}
	//		else
	//		{
	//			// Nếu khách hàng đã tồn tại, sử dụng đối tượng khách hàng đã có để tạo đơn thuê
	//			var rental = new Rental
	//			{
	//				CustomerId = existingCustomer.Id,
	//				UserId = model.UserId,
	//				DateRetalFrom = model.DateRetalFrom,
	//				DateRetalTo = model.DateRetalTo,
	//				RetalTime = model.RetalTime,
	//				Service = model.Service,
	//				Price = model.Price,
	//				Status = RentalStatus.Renting, // Mặc định đang thuê
	//				Total = model.Total,
	//				Note = model.Note,
	//				CreatedBy = model.CreatedBy,
	//				CreationTime = DateTime.Now
	//				// Bạn có thể thêm các trường còn lại tương tự ở đây
	//			};

	//			// Lưu đối tượng đơn thuê vào cơ sở dữ liệu
	//			_context.Rentals.Add(rental);
	//			_context.SaveChanges();
	//		}

	//		// Chuyển hướng đến trang cần thiết sau khi thêm thành công
	//		return RedirectToAction("Index");
	//	}

	//	// Nếu ModelState không hợp lệ, hiển thị lại form với thông báo lỗi
	//	return View(model);
	//}


	//public IActionResult Create()
	//{
	//	ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
	//	var statusList = Enum.GetValues(typeof(RentalStatus))
	//					 .Cast<RentalStatus>()
	//					 .Select(e => new SelectListItem
	//					 {
	//						 Value = ((int)e).ToString(),
	//						 Text = GetEnumDisplayName(e)
	//					 });
	//	ViewData["StatusList"] = new SelectList(statusList, "Value", "Text");
	//	ViewData["StatusList"] = new SelectList(Enum.GetValues(typeof(RentalStatus)));

	//	var serviceList = Enum.GetValues(typeof(RentalService))
	//					 .Cast<RentalService>()
	//					 .Select(e => new SelectListItem
	//					 {
	//						 Value = ((int)e).ToString(),
	//						 Text = GetEnumDisplayName(e)
	//					 });
	//	ViewData["serviceList"] = new SelectList(serviceList, "Value", "Text");
	//	ViewData["serviceList"] = new SelectList(Enum.GetValues(typeof(RentalService)));
	//	return View();
	//}
	private string GetEnumDisplayName(Enum enumValue)
	{
		var displayAttribute = enumValue.GetType()
										.GetMember(enumValue.ToString())
										.First()
										.GetCustomAttribute<DisplayAttribute>();
		return displayAttribute != null ? displayAttribute.Name : enumValue.ToString();
	}



	public async Task AddRentalAsync(Rental rental)
    {
        _context.Rentals.Add(rental);
        await _context.SaveChangesAsync();
    }

    public async Task<Rental> CreateRentalAsync(CreateRental createRental)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.IdDocument == createRental.IdDocument);

        if (customer == null)
        {
            customer = new Customer
            {
                Name = createRental.Name,
                IdDocument = createRental.IdDocument,
                PhoneNumber = createRental.PhoneNumber,
                Email = createRental.Email,
                Address = createRental.Address,
                CreatedBy = createRental.CreatedBy,
                CreationTime = createRental.CreationTime,
                UpdatedBy = createRental.UpdatedBy,
                UpdationTime = createRental.UpdationTime
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        var rental = new Rental
        {
            CustomerId = customer.Id,
			UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            DateRetalFrom  = createRental.DateRetalFrom,
            DateRetalTo = createRental.DateRetalTo,
            RetalTime = createRental.RetalTime,
            Service = createRental.Service,
            Price = createRental.Price,
            Status = createRental.Status,
            Total = createRental.Total,
            Note = createRental.Note,
            CreatedBy = User.Identity.Name,
            CreationTime = DateTime.UtcNow,
            UpdatedBy = null,
            UpdationTime = null
        };

        foreach (var motorbikeId in createRental.EmotorIds)
        {
            var rentalDetail = new RentalDetail
            {
                EMotorbileId = motorbikeId,
                Rental = rental
            };
            rental.RentlDetails.Add(rentalDetail);
        }

        await AddRentalAsync(rental);
        return rental;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateRental createRental)
    {
        if (!ModelState.IsValid)
        {
            await CreateRentalAsync(createRental);
            return RedirectToAction(nameof(Index));
        }

        return View(createRental);
    }

}
