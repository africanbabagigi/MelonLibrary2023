using MelonMVCBookshelf.Data;
using MelonMVCBookshelf.ViewModels.Dashboard;
using MelonMVCBookshelf.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using MelonMVCBookshelf.Models;

namespace MelonMVCBookshelf.Controllers
{
    public class RequestController : Controller
    {
        ApplicationDbContext _context;
        public RequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requests.Include(r => r.Category).ToList();
            RequestsPageViewModel requestsPageViewModel = new();

            var items = new DashboardRequestViewModel { Title = "Title 1", Author = "Author 1", Status = Models.Enums.RequestStatus.Delivering, Priority = Models.Enums.Priority.High, DateOfAdding = DateTime.Now };
            var items1 = new DashboardRequestViewModel { Title = "Title 2", Author = "Author 2", Status = Models.Enums.RequestStatus.Delivering, Priority = Models.Enums.Priority.High, DateOfAdding = DateTime.Now };
            requestsPageViewModel.Items.Add(items);
            requestsPageViewModel.Items.Add(items1);

            return View(requestsPageViewModel);
        }

        public IActionResult Add(string title, string author)
        {
            var ResourceExists = _context.Resources.Any(item => item.Title == title && item.Author == author);

            var RequestExists = _context.Requests.Any(item => item.Title == title && item.Author == author);

            if (!ResourceExists && !RequestExists)
            {
                Models.Request request = new();
                _context.Requests.Add(request);
            }

            return View();
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


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = GetDataById(id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        public Request GetDataById(int id)
        {
            // Retrieve the data from the data source
            // Implement the logic specific to your data access technology

            // For example, if you're using Entity Framework, you can do something like this:
            using (var context = new ApplicationDbContext())
            {
                var data = context.Requests.FirstOrDefault(m => m.RequestsId == id);
                return data;
            }

            // If you're using a different data access technology, adjust the code accordingly

            // If the data is not found, return null or throw an exception, based on your requirements
            return null;
        }

        [HttpPost]
        public IActionResult Edit(Request model)
        {
            if (ModelState.IsValid)
            {
                var existingData = GetDataById(model.RequestsId);

                if (existingData == null)
                {
                    return NotFound();
                }

                // Update the relevant properties with the new values
                existingData.RequestsId = model.RequestsId;
                existingData.Title = model.Title;
                // ...

                // Save the changes to the data source
                UpdateData(existingData);

                // Redirect to a success page or display a success message
                return RedirectToAction("Index");
            }

            // If there are validation errors, redisplay the form with errors
            return View(model);
        }

        public void UpdateData(Request data)
        {
            using (var context = new ApplicationDbContext())
            {
                // Retrieve the existing data from the data source
                var existingData = context.Requests.FirstOrDefault(m => m.RequestsId == data.RequestsId);

                if (existingData != null)
                {
                    // Update the relevant properties with the new values
                    existingData.RequestsId = data.RequestsId;
                    existingData.Title = data.Title;
                    // ...

                    // Save the changes to the data source
                    context.SaveChanges();
                }
            }
        }

        public IActionResult Delete(int id)
        {
            var item = _context.Requests.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: My/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = _context.Requests.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
