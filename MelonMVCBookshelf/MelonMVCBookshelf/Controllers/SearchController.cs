using MelonMVCBookshelf.Data;
using MelonMVCBookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Controllers
{
    public class SearchController : Controller
    {
        ApplicationDbContext _context;
        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Search(Category category, string resourceType, string title)
        {
            var results = _context.Resources.Include($"{nameof(Resource.Category)}")
            .Where(item => item.Title.Contains(title)
            && item.ResourceType.Contains(resourceType)
            && item.CategoryId == 0);

            return View(results);
        }
    }
}
