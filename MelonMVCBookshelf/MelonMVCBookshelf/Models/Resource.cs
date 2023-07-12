using MelonMVCBookshelf.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public ResourcesStatus Status { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required] 
        [ForeignKey (nameof(Category))]
        public int CategoryId { get; set; }


        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DateOfTaking { get; set; }

        [Required]
        public DateTime DateOfReturning { get; set; }

        [Required]
        public string Link { get; set; }

    }
}
