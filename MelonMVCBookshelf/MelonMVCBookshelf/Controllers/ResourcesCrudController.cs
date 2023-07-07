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
    //TO DO:
    //CREATE THE READ FUNCTION
    public class ResourcesCrudController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcesCrudController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "TypeOfCategory");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ResourceId,Status,ResourceType,CategoryId,Author,Title,DateOfTaking,DateOfReturning")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "TypeOfCategory", resource.CategoryId);
            return View(resource);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resources.FindAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "TypeOfCategory", resource.CategoryId);
            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ResourceId,Status,ResourceType,CategoryId,Author,Title,DateOfTaking,DateOfReturning")] Resource resource)
        {
            if (id != resource.ResourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourceExists(resource.ResourceId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "TypeOfCategory", resource.CategoryId);
            return View(resource);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resources
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.ResourceId == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resource = await _context.Resources.FindAsync(id);
            _context.Resources.Remove(resource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourceExists(int id)
        {
            return _context.Resources.Any(e => e.ResourceId == id);
        }
    }
}
