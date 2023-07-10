using MelonMVCBookshelf.Data;
using MelonMVCBookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Controllers
{
    public class EditController : Controller
    {
        ApplicationDbContext _context;
        public EditController(ApplicationDbContext context)
        {
            _context = context;
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

    }
}
