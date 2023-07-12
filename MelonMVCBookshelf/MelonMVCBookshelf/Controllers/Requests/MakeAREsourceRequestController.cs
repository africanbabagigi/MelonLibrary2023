using MelonMVCBookshelf.Data;
using MelonMVCBookshelf.ViewModels;
using MelonMVCBookshelf.ViewModels.Dashboard;
using MelonMVCBookshelf.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Controllers
{
    public class MakeAREsourceRequestController : Controller
    {

        ApplicationDbContext _context;
        public MakeAREsourceRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: My/ResourceRequest
        public ActionResult ResourceRequest()
        {
            return View();
        }

        // POST: My/ResourceRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResourceRequest(DashboardRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the form data and handle the resource request
                // Example: Save the resource request to the database

                // Redirect to a success view or action
                return RedirectToAction("ResourceRequestSuccess");
            }

            // If the form submission is invalid, return the same view with validation errors
            return View(model);
        }

        // GET: My/ResourceRequestSuccess
        public ActionResult ResourceRequestSuccess()
        {
            return View();
        }     
    }

}
