using MelonMVCBookshelf.Data;
using MelonMVCBookshelf.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Controllers
{
    public class ReturnResourceController : Controller
    {

        ApplicationDbContext _context;
        public ReturnResourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Return(int id)
        {

            var item = _context.Resources.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            bool available = item.Status.Equals(_context.Resources
            .FirstOrDefault(resource => resource.Status == ResourcesStatus.Available)); // Set the availability status to true
            _context.SaveChanges(); // Save changes to the database

            return RedirectToAction("Index");
        }
    }
}
