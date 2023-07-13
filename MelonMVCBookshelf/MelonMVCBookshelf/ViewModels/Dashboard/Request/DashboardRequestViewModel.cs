using MelonMVCBookshelf.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.ViewModels.Dashboard
{
    public class DashboardRequestViewModel
    {
        public DashboardRequestViewModel()
        {
        }

        public DashboardRequestViewModel(MelonMVCBookshelf.Models.Request request)
        {
            RequestsId = request.RequestsId;
            Status = request.Status;
            Author = request.Author;
            Title = request.Title;
            Priority = request.Priority;
            DateOfAdding = request.DateOfAdding;
        }

        public int RequestsId { get; set; }

        public RequestStatus Status { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public Priority Priority { get; set; }

        public DateTime DateOfAdding { get; set; }

        public string Type { get; set; }

       

        public string Link { get; set; }
    }
}
