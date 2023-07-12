using MelonMVCBookshelf.Models;
using MelonMVCBookshelf.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.ViewModels
{
    public class HRResourceDetailsViewModel
    {
        public int ResourceId { get; set; }

        public Category Category { get; set; }

        public ResourcesStatus Status { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public DateTime DateOfTaking { get; set; }

        public DateTime DateOfReturning { get; set; }

        

    }
}
