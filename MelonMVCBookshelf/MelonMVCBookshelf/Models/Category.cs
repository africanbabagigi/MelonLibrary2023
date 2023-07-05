using System.ComponentModel.DataAnnotations;

namespace MelonMVCBookshelf.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string TypeOfCategory { get; set; }
    }
}