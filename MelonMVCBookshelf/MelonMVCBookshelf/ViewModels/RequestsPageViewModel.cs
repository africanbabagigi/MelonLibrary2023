using MelonMVCBookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.ViewModels
{
    public class RequestsPageViewModel
    {

        List<RequestViewModel> RequestViewModel = new();

        public RequestsPageViewModel(List<Request> dbRequest)
        {
            RequestViewModel = dbRequest
               .Select(x => new RequestViewModel()
               {
                   RequestsId=x.RequestsId,
                   Status=x.Status,
                   Author = x.Author,
                   Priority=x.Priority,
                   DateOfAdding = x.DateOfAdding,
                   Category = x.Category.TypeOfCategory                
               })
               .ToList();
        }
    }
}
