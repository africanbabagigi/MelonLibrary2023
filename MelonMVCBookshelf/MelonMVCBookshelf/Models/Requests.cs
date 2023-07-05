using MelonMVCBookshelf.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Models.Requests
{
    public class Requests
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public string ResourceType { get; set; }
    }
}
