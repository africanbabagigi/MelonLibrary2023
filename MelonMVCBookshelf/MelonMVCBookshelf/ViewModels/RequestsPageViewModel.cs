using MelonMVCBookshelf.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.ViewModels
{
    public class RequestsPageViewModel
    {
        public RequestsPageViewModel()
        {
            Items = new();
        }
        public List<RequestViewModel> Items { get; set; } // Assuming MyItem is a model class representing the data          

       
    }
}
