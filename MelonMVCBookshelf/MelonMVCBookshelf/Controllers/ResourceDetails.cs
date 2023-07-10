using MelonMVCBookshelf.Data;
using MelonMVCBookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Controllers
{
    public class ResourceDetails : Controller
    {
        ApplicationDbContext _context;
        public ResourceDetails(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var item = _context.Resources.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            List<string> resources = new();
            resources.Add(item.Title);
            resources.Add(item.Author);
            resources.Add(item.ResourceType);
            resources.Add(item.Status.ToString());
            resources.Add(item.DateOfTaking.ToString());
            resources.Add(item.DateOfReturning.ToString());
          
            return View(resources);           
        }
    }
}
