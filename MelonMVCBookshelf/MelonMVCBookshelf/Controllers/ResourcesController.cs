using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MelonMVCBookshelf.Data;
using MelonMVCBookshelf.Models;

namespace MelonMVCBookshelf.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Resources.Include(r => r.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> FindById(int id)
        {
            var resources = await _context.Resources
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.ResourceId == id);
            if (resources == null)
            {
                return NotFound();
            }

            return View(resources);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "TypeOfCategory");
            return View();
        }

        [HttpPost]
<<<<<<< Updated upstream
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResourceId,Status,ResourceType,CategoryId,Author,Title,DateOfTaking,DateOfReturning")] Resource resources)
=======
        public async Task<IActionResult> Create([Bind("ResourceId,Status,ResourceType,CategoryId,Author,Title,DateOfTaking,DateOfReturning")] Resources resources)
>>>>>>> Stashed changes
        {
            if (ModelState.IsValid)
            {
                _context.Add(resources);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "TypeOfCategory", resources.CategoryId);
            return View(resources);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resources = await _context.Resources.FindAsync(id);
            if (resources == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "TypeOfCategory", resources.CategoryId);
            return View(resources);
        }

        [HttpPost]
<<<<<<< Updated upstream
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResourceId,Status,ResourceType,CategoryId,Author,Title,DateOfTaking,DateOfReturning")] Resource resources)
=======
        public async Task<IActionResult> Edit(int id, [Bind("ResourceId,Status,ResourceType,CategoryId,Author,Title,DateOfTaking,DateOfReturning")] Resources resources)
>>>>>>> Stashed changes
        {
            if (id != resources.ResourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resources);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourcesExists(resources.ResourceId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "TypeOfCategory", resources.CategoryId);
            return View(resources);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resources = await _context.Resources
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.ResourceId == id);
            if (resources == null)
            {
                return NotFound();
            }

            return View(resources);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resources = await _context.Resources.FindAsync(id);
            _context.Resources.Remove(resources);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourcesExists(int id)
        {
            return _context.Resources.Any(e => e.ResourceId == id);
        }
    }
}
