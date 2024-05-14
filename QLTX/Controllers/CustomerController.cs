using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;

namespace QLTX.Controllers;

public class CustomerController : Controller
{
	private readonly QLTXDbContext _context;

	public CustomerController(QLTXDbContext context)
	{
		_context = context;
	}

	// GET: Customer
	public async Task<IActionResult> Index()
	{
		if (TempData.ContainsKey("SuccessMessage"))
		{
			ViewBag.SuccessMessage = TempData["SuccessMessage"];
		}
		return _context.Customers != null ?
					  View(await _context.Customers.ToListAsync()) :
					  Problem("Entity set 'QLTXDbContext.Customer'  is null.");
	}

	// GET: Customer/Details/5
	public async Task<IActionResult> Details(int? id)
	{
		if (id == null || _context.Customers == null)
		{
			return NotFound();
		}

		var customer = await _context.Customers
			.FirstOrDefaultAsync(m => m.Id == id);
		if (customer == null)
		{
			return NotFound();
		}

		return View(customer);
	}

	// GET: Customer/Create
	public IActionResult Create()
	{
		return View();
	}


	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("Id,Name,IdDocument , PhoneNumber, Email,  Address ")] Customer customer)
	{
		if (CustomerExists(customer.Name))
		{

			ModelState.AddModelError("Name", "Tên hãng xe đã tồn tại.");
			return View(customer);
		}
		if (!ModelState.IsValid)
		{
			customer.CreatedBy = User.Identity.Name;
			customer.CreationTime = DateTime.Now;
			customer.UpdatedBy = null;
			customer.UpdationTime = null;


			_context.Add(customer);
			await _context.SaveChangesAsync();
			TempData["SuccessMessage"] = "Thêm mới thành công.";
			return RedirectToAction(nameof(Index));
		}
		return View(customer);
	}
	private bool CustomerExists(string name)
	{
		return _context.Customers.Any(c => c.Name == name);
	}

	// GET: Customer/Edit/5
	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null || _context.Customers == null)
		{
			return NotFound();
		}

		var customer = await _context.Customers.FindAsync(id);
		if (customer == null)
		{
			return NotFound();
		}
		return View(customer);
	}


	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IdDocument , PhoneNumber, Email,  Address")] Customer customer)
	{
		if (id != customer.Id)
		{
			return NotFound();
		}
		var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Name == customer.Name && c.Id != customer.Id);
		if (existingCustomer != null)
		{
			ModelState.AddModelError("Name", "Tên đã tồn tại. Vui lòng chọn tên khác.");
			return View(customer);
		}
		var originalCustomer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == customer.Id);
		customer.CreatedBy = originalCustomer.CreatedBy;
		customer.CreationTime = originalCustomer.CreationTime;
		customer.UpdatedBy = User.Identity.Name;
		customer.UpdationTime = DateTime.Now;
		if (!ModelState.IsValid)
		{
			try
			{
				_context.Update(customer);
				await _context.SaveChangesAsync();
				TempData["SuccessMessage"] = "Cập nhật thành công.";
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CustomerExists(customer.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return RedirectToAction(nameof(Index));
		}
		return View(customer);
	}


	public JsonResult Delete(int id)
	{
		bool result = false;

		var customer = _context.Customers.Find(id);
		if (customer != null)
		{
			result = true;
			_context.Customers.Remove(customer);
			_context.SaveChanges();
			TempData["SuccessMessage"] = "Đã xóa thành công.";
		}
		return Json(result);
	}

	private bool CustomerExists(int id)
	{
		return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
	}
}

