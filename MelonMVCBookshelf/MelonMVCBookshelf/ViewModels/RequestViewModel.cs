using MelonMVCBookshelf.Models;
using MelonMVCBookshelf.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.ViewModels
{
    public class RequestViewModel
    {
        public int RequestsId { get; set; }

        public RequestStatus Status { get; set; }

        public int StatusId { get; set; }

        public string Category { get; set; }

        public int CategoryId { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public Priority Priority { get; set; }

        public DateTime DateOfAdding { get; set; }

        public int NumberOfUsers { get; set; }
    }
}
