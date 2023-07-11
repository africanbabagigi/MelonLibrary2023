using MelonMVCBookshelf.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelonMVCBookshelf.Models;

namespace MelonMVCBookshelf.ViewModels.HR_Dashboard
{
    public class HRRequestViewModel
    {
        public HRRequestViewModel()
        {
        }

        public HRRequestViewModel(MelonMVCBookshelf.Models.Request request)
        {
            RequestsId = request.RequestsId;
            Type = request.Type;
            Title = request.Title;
            Author = request.Author;
            Link = request.Link;
            Description = request.Description;
        }

        public int RequestsId { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }
    }
}
