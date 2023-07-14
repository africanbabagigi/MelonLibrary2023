using MelonMVCBookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel(Category category)
        {
            CategoryId = category.CategoryId;
            TypeOfCategory = category.TypeOfCategory;   
        }

        public int CategoryId { get; set; }

       
        public string TypeOfCategory { get; set; }
    }
}
