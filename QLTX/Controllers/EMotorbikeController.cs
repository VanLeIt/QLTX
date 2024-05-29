using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;

namespace QLTX.Controllers;

public class EMotorbikeController : Controller
{
    private readonly QLTXDbContext _context;

    public EMotorbikeController(QLTXDbContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        if (TempData.ContainsKey("SuccessMessage"))
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
        }
        return _context.EMotorbikes != null ?
                      View(await _context.EMotorbikes.Include(t => t.TypeMotorbike).OrderByDescending(m => m.CreationTime).ToListAsync()) :
                      Problem("Khong tim thay xe.");

    }


    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.EMotorbikes == null)
        {
            return NotFound();
        }

        var eMotorbikes = await _context.EMotorbikes
            .Include(t => t.TypeMotorbike)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (eMotorbikes == null)
        {
            return NotFound();
        }

        return View(eMotorbikes);
    }

    // GET: EMotorbike/Create
    public IActionResult Create()
    {
        ViewData["TypeMotorbikeId"] = new SelectList(_context.TypeMotorbikes, "Id", "Name");
		//var statusList = Enum.GetValues(typeof(EMotorbikeStatus))
		//				 .Cast<EMotorbikeStatus>()
		//				 .Select(e => new SelectListItem
		//				 {
		//					 Value = ((int)e).ToString(),
		//					 Text = GetEnumDisplayName(e)
		//				 });
		//ViewData["StatusList"] = new SelectList(statusList, "Value", "Text");
		//ViewData["StatusList"] = new SelectList(Enum.GetValues(typeof(EMotorbikeStatus)));
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
    public async Task<IActionResult> Create([Bind("Id,License,VinNumber,TypeMotorbikeId,Description,ImageUrl")] EMotorbike eMotorbikes, IFormFile ImageFile)
    {
        if (EMotorbikeExists(eMotorbikes.License))
        {
            ModelState.AddModelError("License", "Biển số xe đã tồn tại.");
            ViewData["TypeMotorbikeId"] = new SelectList(_context.TypeMotorbikes, "Id", "Name", eMotorbikes.TypeMotorbikeId);
            return View(eMotorbikes);
        }

        if (!ModelState.IsValid)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                eMotorbikes.ImageUrl = $"/images/{fileName}";
            }

            eMotorbikes.CreatedBy = User.Identity.Name;
            eMotorbikes.CreationTime = DateTime.Now;
            eMotorbikes.UpdatedBy = null;
            eMotorbikes.UpdationTime = null;

            _context.Add(eMotorbikes);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Thêm mới thành công.";
            return RedirectToAction(nameof(Index));
        }

        ViewData["TypeMotorbikeId"] = new SelectList(_context.TypeMotorbikes, "Id", "Name", eMotorbikes.TypeMotorbikeId);
        return View(eMotorbikes);
    }

    private bool EMotorbikeExists(string name)
    {
        return _context.EMotorbikes.Any(c => c.License == name);
    }

    // GET: EMotorbike/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.EMotorbikes == null)
        {
            return NotFound();
        }

        var eMotorbikes = await _context.EMotorbikes.FindAsync(id);
        if (eMotorbikes == null)
        {
            return NotFound();
        }
        var statusList = Enum.GetValues(typeof(EMotorbikeStatus))
                         .Cast<EMotorbikeStatus>()
                         .Select(e => new SelectListItem
                         {
                             Value = ((int)e).ToString(),
                             Text = GetEnumDisplayName(e)
                         });
        ViewData["StatusList"] = new SelectList(statusList, "Value", "Text"); 
        ViewData["TypeMotorbikeId"] = new SelectList(_context.TypeMotorbikes, "Id", "Name", eMotorbikes.TypeMotorbikeId);

        return View(eMotorbikes);
    }


    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int id, [Bind("Id,License,VinNumber,Status,TypeMotorbikeId,Description")] EMotorbike eMotorbikes)
    //{
    //    if (id != eMotorbikes.Id)
    //    {
    //        return NotFound();
    //    }
    //    var existingEMotorbike = await _context.EMotorbikes.FirstOrDefaultAsync(c => c.License == eMotorbikes.License && c.Id != eMotorbikes.Id);
    //    if (existingEMotorbike != null)
    //    {
    //        ModelState.AddModelError("License", "Bien so xe đã tồn tại. Vui lòng chọn lai.");
    //        return View(eMotorbikes);
    //    }
    //    var statusList = Enum.GetValues(typeof(EMotorbikeStatus))
    //                     .Cast<EMotorbikeStatus>()
    //                     .Select(e => new SelectListItem
    //                     {
    //                         Value = ((int)e).ToString(),
    //                         Text = GetEnumDisplayName(e)
    //                     });
    //    ViewData["StatusList"] = new SelectList(statusList, "Value", "Text", (int)eMotorbikes.Status);
    //    ViewData["TypeMotorbikeId"] = new SelectList(_context.TypeMotorbikes, "Id", "Name", eMotorbikes.TypeMotorbikeId);
    //    var originalEMotorbike = await _context.EMotorbikes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == eMotorbikes.Id);
    //    eMotorbikes.CreatedBy = originalEMotorbike.CreatedBy;
    //    eMotorbikes.CreationTime = originalEMotorbike.CreationTime;

    //    if (!ModelState.IsValid)
    //    {
    //        eMotorbikes.UpdatedBy = User.Identity.Name;
    //        eMotorbikes.UpdationTime = DateTime.Now;
    //        try
    //        {
    //            _context.Update(eMotorbikes);
    //            await _context.SaveChangesAsync();
    //            TempData["SuccessMessage"] = "Cập nhật thành công.";
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!EMotorbikeExists(eMotorbikes.Id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(eMotorbikes);
    //}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,License,VinNumber,Status,TypeMotorbikeId,Description")] EMotorbike eMotorbikes, IFormFile ImageFile)
    {
        if (id != eMotorbikes.Id)
        {
            return NotFound();
        }
        var existingEMotorbike = await _context.EMotorbikes.FirstOrDefaultAsync(c => c.License == eMotorbikes.License && c.Id != eMotorbikes.Id);
        if (existingEMotorbike != null)
        {
            ModelState.AddModelError("License", "Biển số xe đã tồn tại. Vui lòng chọn lại.");
            return View(eMotorbikes);
        }
        var originalEMotorbike = await _context.EMotorbikes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == eMotorbikes.Id);

        if (!ModelState.IsValid)
        {
			if (ImageFile != null && ImageFile.Length > 0)
			{
				// Lấy tên file và đường dẫn lưu trữ trên server
				var fileName = Path.GetFileName(ImageFile.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

				// Lưu ảnh vào thư mục trên server
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await ImageFile.CopyToAsync(stream);
				}

				// Cập nhật URL của ảnh trong đối tượng eMotorbikes
				eMotorbikes.ImageUrl = $"/images/{fileName}";
			}
			else
            {
                eMotorbikes.ImageUrl = originalEMotorbike.ImageUrl;
            }

            eMotorbikes.CreatedBy = originalEMotorbike.CreatedBy;
            eMotorbikes.CreationTime = originalEMotorbike.CreationTime;
            eMotorbikes.UpdatedBy = User.Identity.Name;
            eMotorbikes.UpdationTime = DateTime.Now;

            try
            {
                _context.Update(eMotorbikes);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Cập nhật thành công.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMotorbikeExists(eMotorbikes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        var statusList = Enum.GetValues(typeof(EMotorbikeStatus))
                         .Cast<EMotorbikeStatus>()
                         .Select(e => new SelectListItem
                         {
                             Value = ((int)e).ToString(),
                             Text = GetEnumDisplayName(e)
                         });

        ViewData["StatusList"] = new SelectList(statusList, "Value", "Text", (int)eMotorbikes.Status);
        ViewData["TypeMotorbikeId"] = new SelectList(_context.TypeMotorbikes, "Id", "Name", eMotorbikes.TypeMotorbikeId);
        return View(eMotorbikes);
    }



    public JsonResult Delete(int id)
    {
        bool result = false;

        var eMotorbikes = _context.EMotorbikes.Find(id);
        if (eMotorbikes != null)
        {
            if (!string.IsNullOrEmpty(eMotorbikes.ImageUrl))
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", eMotorbikes.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            _context.EMotorbikes.Remove(eMotorbikes);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Đã xóa thành công.";
            result = true;
        }
        return Json(result);
    }

    private bool EMotorbikeExists(int id)
    {
        return (_context.EMotorbikes?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
