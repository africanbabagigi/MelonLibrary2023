using MelonMVCBookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.ViewModels.Dashboard
{
    

    public class DashboardResourceViewModel
    {
        public DashboardResourceViewModel()
        {
          
        }

        public DashboardResourceViewModel(Resource resource)
        {
            ResourceId = resource.ResourceId;
            Author = resource.Author;
            Title = resource.Title;
            DateOfReturning = resource.DateOfReturning;
        }

        public int ResourceId { get; set; }

        public CategoryViewModel Category { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public DateTime DateOfReturning { get; set; }
    }
}
