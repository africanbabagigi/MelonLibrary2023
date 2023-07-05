using MelonMVCBookshelf.Data;
using MelonMVCBookshelf.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Controllers
{
    public class ResourceController : Controller
    {
        ApplicationDbContext _context;

        public ResourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Return(int resourceId)
        {
            var resource = _context.Resources.FirstOrDefault(item => item.ResourceId == resourceId);
            return View(ResourcesStatus.Available);          
        }


    }
}
