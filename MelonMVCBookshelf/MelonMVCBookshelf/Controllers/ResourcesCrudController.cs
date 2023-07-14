using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MelonMVCBookshelf.Data;
using MelonMVCBookshelf.Models;
using MelonMVCBookshelf.Models.Enums;
using MelonMVCBookshelf.ViewModels;

namespace MelonMVCBookshelf.Controllers
{
    public class ResourcesCrudController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcesCrudController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        {
            var resources = _context.Resources.Include("Category").Select(item=> new HRResourcesViewModel(item)).ToList();
            var model = new HRPageResourceViewModel();
            model.Items = resources;
            return View(model);
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

        public async Task<IActionResult> Edit(int? resourceId)
        {
            if (resourceId == null)
            {
                return NotFound();
            }

            var resource = await _context.Resources.FindAsync(resourceId);
            if (resource == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "TypeOfCategory", resource.CategoryId);
            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int resourceId, [Bind("ResourceId,Status,ResourceType,CategoryId,Author,Title,DateOfTaking,DateOfReturning")] Resource resource)
        {
            if (resourceId != resource.ResourceId)
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

        public IActionResult ToggleResourceStatus(int id)
        {

            var resource = _context.Resources.FirstOrDefault(x => x.ResourceId == id);
            if (resource == null)
            {
                return NotFound();
            }

            if (resource.Status == ResourcesStatus.Taken)
            {
                resource.Status = ResourcesStatus.Available;
            }

            else
            {
                resource.Status = ResourcesStatus.Taken;
            }

            _context.Update(resource);
            _context.SaveChanges();

            return RedirectToAction("Index"); //TODO: Redirect to reguests
        }

        public IActionResult GetResourceDetails(int id)
        {
            var item = _context.Resources.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            List<string> resources = new();
            resources.Add(item.Title);
            resources.Add(item.Author);
            resources.Add(item.ResourceType.ToString());
            resources.Add(item.Status.ToString());
            resources.Add(item.DateOfTaking.ToString());
            resources.Add(item.DateOfReturning.ToString());

            return View(resources);
        }
    }
}
