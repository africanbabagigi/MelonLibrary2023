using MelonMVCBookshelf.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Controllers
{
    public class DeleteController : Controller
    {
        ApplicationDbContext _context;

        public DeleteController(ApplicationDbContext context)
        {
            _context = context;
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
