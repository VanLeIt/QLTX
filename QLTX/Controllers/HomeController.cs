using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;
using QLTX.ViewModels;

namespace QLTX.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QLTXDbContext _context;
        public HomeController(ILogger<HomeController> logger, QLTXDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {

            var storeInfo = await _context.Stores.FirstOrDefaultAsync();
            var emotoReady = await _context.EMotorbikes.Where(a => a.IsDelete == false && a.Status == EMotorbikeStatus.Ready).ToListAsync();
            var emotoRenting = await _context.EMotorbikes.Where(a => a.IsDelete == false && a.Status == EMotorbikeStatus.Renting).ToListAsync();
            var emoto = await _context.EMotorbikes.Where(a => a.IsDelete == false).ToListAsync();
            var renting = await _context.Rentals.Where(a => a.IsDelete == false && a.Status == RentalStatus.Renting).ToListAsync();
            var rentSuccess = await _context.Rentals.Where(a => a.IsDelete == false && a.Status == RentalStatus.Success).ToListAsync();
            var countEmotorReady = emotoReady.Count;
            var countEmotoRenting = emotoRenting.Count;
            var countEmoto = emoto.Count;
            var countRenting = renting.Count;
            var countRentSuccess = rentSuccess.Count;
            //var dasboad = new DasboadDto();
             var dasboad = new DasboadDto()
            {
                Name = storeInfo.Name,
                Address = storeInfo.Address,
                Description = storeInfo.Description,
                Email = storeInfo.Email,
                PhoneNumber = storeInfo.PhoneNumber,
                eMotorReady = countEmotorReady,
                eMotorRenting = countEmotoRenting,
                 eMotor = countEmoto,
                renting = countRenting,
                rentalSuccess = countRentSuccess

            };
            return View(dasboad);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
