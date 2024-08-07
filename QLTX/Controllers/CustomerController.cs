﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace QLTX.Controllers;

public class CustomerController : Controller
{
	private readonly QLTXDbContext _context;

	public CustomerController(QLTXDbContext context)
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
        return _context.Customers != null ?
                      View(await _context.Customers.Where(a => a.IsDelete == false).ToListAsync()) :
                      Problem("Không có bản ghi nào.");
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
		var statusList = Enum.GetValues(typeof(TypeDocument))
						 .Cast<TypeDocument>()
						 .Select(e => new SelectListItem
						 {
							 Value = ((int)e).ToString(),
							 Text = GetEnumDisplayName(e)
						 }).ToList();

		ViewData["StatusList"] = new SelectList(statusList, "Value", "Text");
		return View();
	}

 
	private string GetEnumDisplayName(Enum enumValue)
	{
		var displayAttribute = enumValue.GetType()
										.GetMember(enumValue.ToString())
										.First()
										.GetCustomAttribute<DisplayAttribute>();
		return displayAttribute != null ? displayAttribute.Name : enumValue.ToString();
	}


	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("Id,Name,TypeDocument,IdDocument , PhoneNumber, Email,  Address ")] Customer customer)
	{
		 
		if (!ModelState.IsValid)
		{
			var statusList = Enum.GetValues(typeof(TypeDocument))
							 .Cast<TypeDocument>()
							 .Select(e => new SelectListItem
							 {
								 Value = ((int)e).ToString(),
								 Text = GetEnumDisplayName(e)
							 }).ToList();

			ViewData["StatusList"] = new SelectList(statusList, "Value", "Text");
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

        var statusList = Enum.GetValues(typeof(TypeDocument))
                         .Cast<TypeDocument>()
                         .Select(e => new SelectListItem
                         {
                             Value = ((int)e).ToString(),
                             Text = GetEnumDisplayName(e)
                         }).ToList();

        ViewData["StatusList"] = new SelectList(statusList, "Value", "Text");
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
		 
		var originalCustomer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == customer.Id);
		customer.CreatedBy = originalCustomer.CreatedBy;
		customer.CreationTime = originalCustomer.CreationTime;
		customer.UpdatedBy = User.Identity.Name;
		customer.UpdationTime = DateTime.Now;
		if (!ModelState.IsValid)
		{
            var statusList = Enum.GetValues(typeof(TypeDocument))
                             .Cast<TypeDocument>()
                             .Select(e => new SelectListItem
                             {
                                 Value = ((int)e).ToString(),
                                 Text = GetEnumDisplayName(e)
                             }).ToList();

            ViewData["StatusList"] = new SelectList(statusList, "Value", "Text");
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
			//_context.Customers.Remove(customer);
			//_context.SaveChanges();
			customer.IsDelete = true;
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

