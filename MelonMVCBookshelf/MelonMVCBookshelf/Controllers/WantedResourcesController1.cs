using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Controllers
{
    public class WantedResourcesController1 : Controller
    {
        public IActionResult NumberOfUpvoedUsers()
        {
            return View();
        }
    }
}
