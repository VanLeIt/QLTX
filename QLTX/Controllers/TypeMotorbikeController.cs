using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;

namespace QLTX.Controllers;

public class TypeMotorbikeController : Controller
{
	private readonly QLTXDbContext _context;

	public TypeMotorbikeController(QLTXDbContext context)
	{
		_context = context;
	}

	 
	public async Task<IActionResult> Index()
	{
		if (TempData.ContainsKey("SuccessMessage"))
		{
			ViewBag.SuccessMessage = TempData["SuccessMessage"];
		}
		return _context.TypeMotorbikes != null ?
					  View(await _context.TypeMotorbikes.Include(t=> t.Company).Where(a=>a.IsDelete ==false).ToListAsync()) :
					  Problem("Không tìm thấy bản ghi.");
		 
	}

 
	public async Task<IActionResult> Details(int? id)
	{
		if (id == null || _context.TypeMotorbikes == null)
		{
			return NotFound();
		}

		var typeMotorbikes = await _context.TypeMotorbikes
			.Include(t => t.Company)
			.FirstOrDefaultAsync(m => m.Id == id);
		if (typeMotorbikes == null)
		{
			return NotFound();
		}

		return View(typeMotorbikes);
	}

	// GET: TypeMotorbike/Create
	public IActionResult Create()
	{
		ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
		return View();
	}


	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("Id,Name,Power,Speed,Battery,Charging,CompanyId,Description ")] TypeMotorbike typeMotorbikes)
	{
		if (TypeMotorbikeExists(typeMotorbikes.Name))
		{

			ModelState.AddModelError("Name", "Tên loai xe đã tồn tại.");
			return View(typeMotorbikes);
		}
		ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", typeMotorbikes.CompanyId);
		if (!ModelState.IsValid)
		{
			typeMotorbikes.CreatedBy = User.Identity.Name;
			typeMotorbikes.CreationTime = DateTime.Now;
			typeMotorbikes.UpdatedBy = null;
			typeMotorbikes.UpdationTime = null;


			_context.Add(typeMotorbikes);
			await _context.SaveChangesAsync();
			TempData["SuccessMessage"] = "Thêm mới thành công.";
			return RedirectToAction(nameof(Index));
		}
		return View(typeMotorbikes);
	}
	private bool TypeMotorbikeExists(string name)
	{
		return _context.TypeMotorbikes.Any(c => c.Name == name);
	}

	// GET: TypeMotorbike/Edit/5
	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null || _context.TypeMotorbikes == null)
		{
			return NotFound();
		}

		var typeMotorbikes = await _context.TypeMotorbikes.FindAsync(id);
		if (typeMotorbikes == null)
		{
			return NotFound();
		}
		ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", typeMotorbikes.CompanyId);
		return View(typeMotorbikes);
	}


	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Power,Speed,Battery,Charging,CompanyId,Description")] TypeMotorbike typeMotorbikes)
	{
		if (id != typeMotorbikes.Id)
		{
			return NotFound();
		}
		var existingTypeMotorbike = await _context.TypeMotorbikes.FirstOrDefaultAsync(c => c.Name == typeMotorbikes.Name && c.Id != typeMotorbikes.Id);
		if (existingTypeMotorbike != null)
		{
			ModelState.AddModelError("Name", "Tên đã tồn tại. Vui lòng chọn tên khác.");
			return View(typeMotorbikes);
		}
		ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", typeMotorbikes.CompanyId);
		var originalTypeMotorbike = await _context.TypeMotorbikes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == typeMotorbikes.Id);
		typeMotorbikes.CreatedBy = originalTypeMotorbike.CreatedBy;
		typeMotorbikes.CreationTime = originalTypeMotorbike.CreationTime;
		
		if (!ModelState.IsValid)
		{
			typeMotorbikes.UpdatedBy = User.Identity.Name;
			typeMotorbikes.UpdationTime = DateTime.Now;
			try
			{
				_context.Update(typeMotorbikes);
				await _context.SaveChangesAsync();
				TempData["SuccessMessage"] = "Cập nhật thành công.";
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TypeMotorbikeExists(typeMotorbikes.Id))
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
		return View(typeMotorbikes);
	}
	 

	public JsonResult Delete(int id)
	{
		bool result = false;

		var typeMotorbikes = _context.TypeMotorbikes.Find(id);
		if (typeMotorbikes != null)
		{
			result = true;
			typeMotorbikes.IsDelete = true;
			//_context.TypeMotorbikes.Remove(typeMotorbikes);
			_context.SaveChanges();
			TempData["SuccessMessage"] = "Đã xóa thành công.";
		}
		return Json(result);
	}

	private bool TypeMotorbikeExists(int id)
	{
		return (_context.TypeMotorbikes?.Any(e => e.Id == id)).GetValueOrDefault();
	}
}
