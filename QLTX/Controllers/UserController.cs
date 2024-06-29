using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;
using QLTX.ViewModels;

namespace QLTX.Controllers
{
	[Authorize(Roles = "admin")]
	public class UserController : Controller
	{
		private readonly QLTXDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;
		private readonly UserRoles _userRoles;

		public UserController(QLTXDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager, UserRoles userRoles)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
			_userRoles = userRoles;
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
			var usersWithRoles = await _context.Users
				.Include(u => u.UserRoles)
				.ThenInclude(ur => ur.Role)
				.Where(a => a.IsDelete == false)
				.ToListAsync();

			if (usersWithRoles != null)
			{
				return View(usersWithRoles);
			}
			else
			{
				return Problem("Không có người dùng nào được tìm thấy.");
			} 
		} 

		public async Task<IActionResult> Details(string? id)
		{
			if (id == null || _context.Users == null)
			{
				return NotFound();
			}
			var user = await _context.Users
				.Include(u => u.UserRoles)
				.ThenInclude(ur => ur.Role)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (user == null)
			{
				return NotFound();
			}
			var model = new UserDetailsViewModel
			{
				Id = user.Id,
				UserName = user.UserName,
				FullName = user.FullName,
				Address = user.Address,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				CreatedBy = user.CreatedBy,
				CreationTime = user.CreationTime,
				UpdatedBy = user.UpdatedBy,
				UpdationTime = user.UpdationTime,
				Roles = user.UserRoles.Select(ur => ur.Role.Name).ToList()
			}; 
			return View(model); 
		}

		public IActionResult Create()
		{ 
			return View();
		}
		 
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateUserViewModel input)
		{
			if (UsersExists(input.Email))
			{

				ModelState.AddModelError("Email", "Tên người dùng đã tồn tại.");

				return View(input);
			}

			if (!ModelState.IsValid)
			{
				var user = new User
				{
					UserName = input.Email,
					FullName = input.FullName,
					Address = input.Address,
					Email = input.Email,
					PhoneNumber = input.PhoneNumber,
					CreatedBy = User.Identity.Name,
					CreationTime = DateTime.Now,
					UpdatedBy = null,
					UpdationTime = null
				}; 
				var result = await _userManager.CreateAsync(user, input.Password!); 
				await _context.SaveChangesAsync();
				TempData["SuccessMessage"] = "Thêm mới thành công.";
				return RedirectToAction(nameof(Index)); 
			} 
			return View(input);
		}
		private bool UsersExists(string name)
		{
			return _context.Users.Any(c => c.Email == name);
		}

		public async Task<IActionResult> Edit(string id)
		{
			if (id == null || _context.Users == null)
			{
				return NotFound();
			}

			var user = await _context.Users.FindAsync(id);
			if (user == null)
			{
				return NotFound();
			} 
			var model = new CreateUserViewModel
			{
				FullName = user.FullName,
				Address = user.Address,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber, 
			}; 
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, CreateUserViewModel model)
		{
			if (id != model.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				return View(model);
			}

			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			} 
			user.FullName = model.FullName;
			user.Address = model.Address;
			user.Email = model.Email;
			user.PhoneNumber = model.PhoneNumber;
			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				TempData["SuccessMessage"] = "Cập nhật thành công.";
				return RedirectToAction(nameof(Index));
			}

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}

			return View(model);
		}

		public async Task<JsonResult> Delete(string? id)
		{
			bool result = false; 
			if (id == null)
			{
				return Json(result);
			} 
			var user = await _context.Users
									 .Include(u => u.UserRoles)
									 .FirstOrDefaultAsync(u => u.Id == id); 
			if (user != null)
			{ 
				var userRoles = _context.UserRoles.Where(ur => ur.UserId == id);
				_context.UserRoles.RemoveRange(userRoles); 
				//_context.Users.Remove(user);
				user.IsDelete = true;
				await _context.SaveChangesAsync();
				result = true;
				TempData["SuccessMessage"] = "Đã xóa thành công.";
			} 
			return Json(result);
		}

		//public async Task<bool> ChangeRole(UserRolesDto userRoles)
		//{
		//	var result = false;  
		//	var user = await _context.Users
		//		.Include(u => u.UserRoles)
		//		.FirstOrDefaultAsync(u => u.Id == userRoles.UserId); 
		//	if (user != null)
		//	{ 
		//		_context.UserRoles.RemoveRange(user.UserRoles); 
		//		foreach (var roleId in userRoles.RoleIds)
		//		{
		//			_context.UserRoles.Add(new UserRoles
		//			{
		//				UserId = userRoles.UserId,
		//				RoleId = roleId
		//			});
		//		}
				
		//		await _context.SaveChangesAsync();
		//		result = true;
		//	}
			 
		//	return result;

		//}

		[Authorize(Roles = "admin")]
		[HttpGet]
		public async Task<IActionResult> EditRoles(string? id)
		{
			var user = await _context.Users
			.Include(u => u.UserRoles)
			.ThenInclude(ur => ur.Role)
			.FirstOrDefaultAsync(u => u.Id == id); 
			if (user == null)
			{
				return NotFound();
			} 
			var roles = await _context.Roles.ToListAsync();
			var model = new UserRoleViewModel
			{
				UserId = user.Id,
				UserName = user.UserName,
				AvailableRoles = roles.Select(r => new SelectListItem
				{
					Value = r.Id,
					Text = r.Name
				}).ToList(),
				SelectedRoles = user.UserRoles.Count > 0 ? user.UserRoles.Select(ur => ur.RoleId).ToList() : new List<string>()
			}; 
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditRoles(UserRoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				var roles = await _context.Roles.ToListAsync();
				model.AvailableRoles = roles.Select(r => new SelectListItem
				{
					Value = r.Id,
					Text = r.Name
				}).ToList();
				return View(model);
			} 
			var user = await _context.Users
				.Include(u => u.UserRoles)
				.FirstOrDefaultAsync(u => u.Id == model.UserId);

			if (user == null)
			{
				return NotFound();
			}
			 
			_context.UserRoles.RemoveRange(user.UserRoles);
 
			foreach (var roleId in model.SelectedRoles)
			{
				_context.UserRoles.Add(new UserRoles
				{
					UserId = user.Id,
					RoleId = roleId
				});
			}
			TempData["SuccessMessage"] = "Gán quyền thành công.";
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		 
		private bool UserExists(string id)
		{
			return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
