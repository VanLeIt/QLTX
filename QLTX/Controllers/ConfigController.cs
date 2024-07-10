using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;

namespace QLTX.Controllers;
[Authorize]
public class ConfigController : Controller
{

	private readonly QLTXDbContext _context;

	public ConfigController(QLTXDbContext context)
	{
		_context = context;
	}
	[HttpGet]
	public async Task<IActionResult> Index()
	{
		var config = await _context.Configs.FirstOrDefaultAsync();
		if (config == null)
		{
			config = new Config();
		}
		return View(config);
	}

	[HttpPost]
	public async Task<IActionResult> Index(Config config)
	{
		if (ModelState.IsValid)
		{

			var existingConfig = await _context.Configs.FirstOrDefaultAsync();
			if (existingConfig != null)
			{
				existingConfig.Name = config.Name;
				existingConfig.Description = config.Description;
				existingConfig.PhoneNumber = config.PhoneNumber;
				existingConfig.Email = config.Email;
				existingConfig.Address = config.Address;
				existingConfig.PriceHour = config.PriceHour;
				existingConfig.PriceDay = config.PriceDay;
				existingConfig.PriceWeek = config.PriceWeek;
				 

				_context.Configs.Update(existingConfig);
			}
			else
			{
				await _context.Configs.AddAsync(config);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		return View(config);
	}
}

