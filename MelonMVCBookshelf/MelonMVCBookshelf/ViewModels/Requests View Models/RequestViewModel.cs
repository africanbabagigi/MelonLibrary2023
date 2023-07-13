using MelonMVCBookshelf.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.ViewModels.Request
{
    public class RequestViewModel
    {
        public RequestViewModel()
        {
        }

        public RequestViewModel(Models.Request request)
        {
            RequestsId = request.CategoryId;

            Status = request.Status;
            Type = request.Type;
            Title = request.Title;
            Author = request.Author;
            Description = request.Description;
            Link = request.Link;
            Priority = request.Priority;
            DateOfAdding = request.DateOfAdding;
        }

        public int RequestsId { get; set; }

        public virtual CategoryViewModel Category { get; set; }

        public RequestStatus Status { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public Priority Priority { get; set; }

        public DateTime DateOfAdding { get; set; }
    }
}
