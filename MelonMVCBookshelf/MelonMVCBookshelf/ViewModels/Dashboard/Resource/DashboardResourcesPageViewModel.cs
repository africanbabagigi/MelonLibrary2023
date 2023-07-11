using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.ViewModels.Dashboard
{
    public class DashboardResourcesPageViewModel
    {
        public DashboardResourcesPageViewModel()
        {
            Items = new();
        }

        public List<DashboardResourceViewModel> Items { get; set; }
    }
}
