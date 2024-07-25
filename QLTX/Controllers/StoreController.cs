using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;

namespace QLTX.Controllers;
[Authorize]
public class StoreController : Controller
{

	private readonly QLTXDbContext _context;

	public StoreController(QLTXDbContext context)
	{
		_context = context;
	}
	[HttpGet]
	public async Task<IActionResult> Index()
	{
		var config = await _context.Stores.FirstOrDefaultAsync();
		if (config == null)
		{
			config = new Store();
		}
		return View(config);
	}

	[HttpPost]
	public async Task<IActionResult> Index(Store config)
	{
		if (ModelState.IsValid)
		{

			var existingConfig = await _context.Stores.FirstOrDefaultAsync();
			if (existingConfig != null)
			{
				existingConfig.Name = config.Name;
				existingConfig.Description = config.Description;
				existingConfig.PhoneNumber = config.PhoneNumber;
				existingConfig.Email = config.Email;
				existingConfig.Address = config.Address;
				//existingConfig.PriceHour = config.PriceHour;
				//existingConfig.PriceDay = config.PriceDay;
				//existingConfig.PriceWeek = config.PriceWeek;
				 

				_context.Stores.Update(existingConfig);
			}
			else
			{
				await _context.Stores.AddAsync(config);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		return View(config);
	}
}

