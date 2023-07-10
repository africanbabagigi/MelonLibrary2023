using MelonMVCBookshelf.Data;
using MelonMVCBookshelf.Models;

using MelonMVCBookshelf.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            var items = new RequestViewModel { Title = "Title 1", Author = "Author 1", Status = Models.Enums.RequestStatus.Delivering, Priority = Models.Enums.Priority.High, DateOfAdding = DateTime.Now, Category = "Category 1" };
            var items1 = new RequestViewModel { Title = "Title 2", Author = "Author 2", Status = Models.Enums.RequestStatus.Delivering, Priority = Models.Enums.Priority.High, DateOfAdding = DateTime.Now, Category = "Category 2" };
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

            else
            {

            }

            return View();
        }

    }
}
