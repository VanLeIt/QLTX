/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;

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
	[HttpPost]
	public IActionResult Create(Rental model)
	{
		if (ModelState.IsValid)
		{
			// Kiểm tra xem khách hàng đã tồn tại trong cơ sở dữ liệu chưa
			var existingCustomer = _context.Customers.FirstOrDefault(c => c.Id == model.CustomerId);
			if (existingCustomer == null)
			{
				// Nếu khách hàng chưa tồn tại, tạo một khách hàng mới từ dữ liệu nhập vào từ form
				var newCustomer = new Customer
				{
					Name = model.,
					IdDocument = model.CustomerIdDocument,
					PhoneNumber = model.CustomerPhoneNumber,
					Email = model.CustomerEmail,
					Address = model.CustomerAddress,
					CreatedBy = model.CreatedBy,
					CreationTime = DateTime.Now
					// Bạn có thể thêm các trường còn lại tương tự ở đây
				};

				// Lưu khách hàng mới vào cơ sở dữ liệu
				_context.Customers.Add(newCustomer);
				_context.SaveChanges();

				// Sử dụng khách hàng mới để tạo đối tượng đơn thuê
				var rental = new Rental
				{
					CustomerId = newCustomer.Id,
					UserId = model.UserId,
					DateRetalFrom = model.DateRetalFrom,
					DateRetalTo = model.DateRetalTo,
					RetalTime = model.RetalTime,
					Service = model.Service,
					Price = model.Price,
					Status = RentalStatus.Renting, // Mặc định đang thuê
					Total = model.Total,
					Note = model.Note,
					CreatedBy = model.CreatedBy,
					CreationTime = DateTime.Now
					// Bạn có thể thêm các trường còn lại tương tự ở đây
				};

				// Lưu đối tượng đơn thuê vào cơ sở dữ liệu
				_context.Rentals.Add(rental);
				_context.SaveChanges();
			}
			else
			{
				// Nếu khách hàng đã tồn tại, sử dụng đối tượng khách hàng đã có để tạo đơn thuê
				var rental = new Rental
				{
					CustomerId = existingCustomer.Id,
					UserId = model.UserId,
					DateRetalFrom = model.DateRetalFrom,
					DateRetalTo = model.DateRetalTo,
					RetalTime = model.RetalTime,
					Service = model.Service,
					Price = model.Price,
					Status = RentalStatus.Renting, // Mặc định đang thuê
					Total = model.Total,
					Note = model.Note,
					CreatedBy = model.CreatedBy,
					CreationTime = DateTime.Now
					// Bạn có thể thêm các trường còn lại tương tự ở đây
				};

				// Lưu đối tượng đơn thuê vào cơ sở dữ liệu
				_context.Rentals.Add(rental);
				_context.SaveChanges();
			}

			// Chuyển hướng đến trang cần thiết sau khi thêm thành công
			return RedirectToAction("Index");
		}

		// Nếu ModelState không hợp lệ, hiển thị lại form với thông báo lỗi
		return View(model);
	}

}
*/