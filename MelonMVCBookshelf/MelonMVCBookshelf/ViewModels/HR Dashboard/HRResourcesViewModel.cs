using MelonMVCBookshelf.Models;
using MelonMVCBookshelf.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.ViewModels
{
    public class HRResourcesViewModel
    {
        public HRResourcesViewModel()
        {
        }

        public HRResourcesViewModel(Resource resource)
        {
            ResourceId = resource.ResourceId;
            Author = resource.Author;
            Title = resource.Title;
            Status = resource.Status;
            DateOfTaking = resource.DateOfTaking;
            DateOfReturning = resource.DateOfReturning;
            Category = new CategoryViewModel(resource.Category);
        }

        public int ResourceId { get; set; }
       
        public CategoryViewModel Category { get; set; }
        
        public string Author { get; set; }

        public string Title { get; set; }

        public ResourcesStatus Status { get; set; }

        public DateTime DateOfTaking { get; set; }

        public DateTime DateOfReturning { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Link { get; set; }
    }
}
