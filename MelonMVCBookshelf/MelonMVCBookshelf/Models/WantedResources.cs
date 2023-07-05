using MelonMVCBookshelf.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Models
{
    public class WantedResources
    {
        [Key]
        public int WantedBookId { get; set; }

        [Required]
        public WantedStatus Status { get; set; }

        [Required]
        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }


        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public DateTime DateOfAdding { get; set; }

        [Required]
        public int NumberOfUsers { get; set; }

        

    }
}
