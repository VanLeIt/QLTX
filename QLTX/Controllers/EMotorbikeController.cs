using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTX.Data;
using QLTX.Models;

namespace QLTX.Controllers
{
    public class EMotorbikeController : Controller
    {
        private readonly QLTXDbContext _context;

        public EMotorbikeController(QLTXDbContext context)
        {
            _context = context;
        }

        // GET: EMotorbike
        public async Task<IActionResult> Index()
        {
            return _context.EMotorbikes != null ?
                        View(await _context.EMotorbikes.ToListAsync()) :
                        Problem("Entity set 'QLTXDbContext.EMotorbike'  is null.");
        }

        // GET: EMotorbike/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EMotorbikes == null)
            {
                return NotFound();
            }

            var emotor = await _context.EMotorbikes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emotor == null)
            {
                return NotFound();
            }

            return View(emotor);
        }

        // GET: EMotorbike/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EMotorbike/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description ")] EMotorbike emotor)
        {

            emotor.CreatedBy = User.Identity.Name;
            emotor.CreationTime = DateTime.Now;
            emotor.UpdatedBy = null;
            emotor.UpdationTime = null;
            if (!ModelState.IsValid)
            {

                _context.Add(emotor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emotor);
        }

        // GET: EMotorbike/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EMotorbikes == null)
            {
                return NotFound();
            }

            var emotor = await _context.EMotorbikes.FindAsync(id);
            if (emotor == null)
            {
                return NotFound();
            }
            return View(emotor);
        }

        // POST: EMotorbike/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreatedBy,CreationTime,UpdatedBy,UpdationTime")] EMotorbike emotor)
        {
            if (id != emotor.Id)
            {
                return NotFound();
            }


            emotor.UpdatedBy = User.Identity.Name;
            emotor.UpdationTime = DateTime.Now;
            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(emotor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EMotorbikeExists(emotor.Id))
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
            return View(emotor);
        }

        // GET: EMotorbike/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EMotorbikes == null)
            {
                return NotFound();
            }

            var emotor = await _context.EMotorbikes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emotor == null)
            {
                return NotFound();
            }

            return View(emotor);
        }

        // POST: EMotorbike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EMotorbikes == null)
            {
                return Problem("Entity set 'QLTXDbContext.EMotorbike'  is null.");
            }
            var emotor = await _context.EMotorbikes.FindAsync(id);
            if (emotor != null)
            {
                _context.EMotorbikes.Remove(emotor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EMotorbikeExists(int id)
        {
            return (_context.EMotorbikes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

