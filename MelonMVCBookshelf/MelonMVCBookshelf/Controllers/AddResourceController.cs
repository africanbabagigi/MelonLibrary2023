using MelonMVCBookshelf.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Controllers
{
    public class AddResourceController : Controller
    {
        ApplicationDbContext _context;
        public AddResourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Add()
        {

            return View();
        }
    }
}
