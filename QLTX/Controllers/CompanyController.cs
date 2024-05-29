﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;

namespace QLTX.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly QLTXDbContext _context;

        public CompanyController(QLTXDbContext context)
        {
            _context = context;
        }

        // GET: Company
        public async Task<IActionResult> Index()
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            return _context.Companies != null ? 
                          View(await _context.Companies.ToListAsync()) :
                          Problem("Entity set 'QLTXDbContext.Company'  is null.");
        }

        // GET: Company/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
				.FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description ")] Company company)
        {
			if (CompanyExists(company.Name))
			{
				 
				ModelState.AddModelError("Name", "Tên hãng xe đã tồn tại.");
				return View(company);  
			}
            if (!ModelState.IsValid)
            {
			company.CreatedBy = User.Identity.Name;
            company.CreationTime = DateTime.Now;
            company.UpdatedBy = null;
            company.UpdationTime = null;
           
                
                _context.Add(company);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thêm mới thành công.";
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }
		private bool CompanyExists(string name)
		{
			return _context.Companies.Any(c => c.Name == name);
		}

		// GET: Company/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }
			var existingCompany = await _context.Companies.FirstOrDefaultAsync(c => c.Name == company.Name && c.Id != company.Id);
			if (existingCompany != null)
			{
				ModelState.AddModelError("Name", "Tên đã tồn tại. Vui lòng chọn tên khác.");
				return View(company);
			}
			var originalCompany = await _context.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == company.Id);
            company.CreatedBy = originalCompany.CreatedBy;
            company.CreationTime = originalCompany.CreationTime;
            company.UpdatedBy = User.Identity.Name;
            company.UpdationTime = DateTime.Now;
            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Cập nhật thành công.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }

 

        public JsonResult Delete(int id)
        {
            bool result = false;

            var company = _context.Companies.Find(id);
            if (company != null)
            {
                result = true;
                _context.Companies.Remove(company);
                _context.SaveChanges();
				TempData["SuccessMessage"] = "Đã xóa thành công.";
			}
            return Json(result); 
        }

        private bool CompanyExists(int id)
        {
          return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
