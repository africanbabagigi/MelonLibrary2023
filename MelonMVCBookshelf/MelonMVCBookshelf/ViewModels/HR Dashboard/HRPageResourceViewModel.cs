using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.ViewModels
{
    public class HRPageResourceViewModel
    {
        public HRPageResourceViewModel()
        {
            Items = new();
        }

        public List<HRResourcesViewModel> Items { get; set; }       
    }
}
