using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;

namespace QLTX.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
	{
		private readonly QLTXDbContext _context;

		public RoleController(QLTXDbContext context)
		{
			_context = context;
		}

		// GET: Role
		public async Task<IActionResult> Index()
		{
			if (TempData.ContainsKey("SuccessMessage"))
			{
				ViewBag.SuccessMessage = TempData["SuccessMessage"];
			}
			return _context.Roles != null ?
						  View(await _context.Roles.Where(a=>a.IsDelete == false).ToListAsync()) :
						  Problem("Không có bản ghi nào.");
		}

		// GET: Role/Details/5
		public async Task<IActionResult> Details(string? id)
		{
			if (id == null || _context.Roles == null)
			{
				return NotFound();
			}

			var role = await _context.Roles
				.FirstOrDefaultAsync(m => m.Id == id);
			if (role == null)
			{
				return NotFound();
			}

			return View(role);
		}

		// GET: Role/Create
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Description ")] Role role)
		{
			if (RoleNameExists(role.Name))
			{

				ModelState.AddModelError("Name", "Tên role đã tồn tại.");
				return View(role);
			}
			if (!ModelState.IsValid)
			{
				role.CreatedBy = User.Identity.Name;
				role.CreationTime = DateTime.Now;
				role.UpdatedBy = null;
				role.UpdationTime = null;


				_context.Add(role);
				await _context.SaveChangesAsync();
				TempData["SuccessMessage"] = "Thêm mới thành công.";
				return RedirectToAction(nameof(Index));
			}
			return View(role);
		}
		private bool RoleNameExists(string name)
		{
			return _context.Roles.Any(c => c.Name == name);
		}

		// GET: Role/Edit/5
		public async Task<IActionResult> Edit(string? id)
		{
			if (id == null || _context.Roles == null)
			{
				return NotFound();
			}
            var role = await _context.Roles
                .FindAsync(id); 
             
			if (role == null)
			{
				return NotFound();
			}
			return View(role);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description")] Role role)
		{

			if (id != role.Id)
			{
				return NotFound();
			}
			var existingRole = await _context.Roles.FirstOrDefaultAsync(c => c.Name == role.Name && c.Id != role.Id);
			if (existingRole != null)
			{
				ModelState.AddModelError("Name", "Tên đã tồn tại. Vui lòng chọn tên khác.");
				return View(role);
			}
			var originalRole = await _context.Roles.AsNoTracking().FirstOrDefaultAsync(c => c.Id == role.Id);
			role.CreatedBy = originalRole.CreatedBy;
			role.CreationTime = originalRole.CreationTime;
			role.UpdatedBy = User.Identity.Name;
			role.UpdationTime = DateTime.Now;
			if (!ModelState.IsValid)
			{
				try
				{
					_context.Update(role);
					await _context.SaveChangesAsync();
					TempData["SuccessMessage"] = "Cập nhật thành công.";
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!RoleExists(role.Id))
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
			return View(role);
		}


		public JsonResult Delete(string id)
		{
			bool result = false;

			var role = _context.Roles.Find(id);
			if (role != null)
			{
				result = true;
				//_context.Roles.Remove(role);
				role.IsDelete = true;
				_context.SaveChanges();
				TempData["SuccessMessage"] = "Đã xóa thành công.";
			}
			return Json(result);
		}

		private bool RoleExists(string id)
		{
			return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
