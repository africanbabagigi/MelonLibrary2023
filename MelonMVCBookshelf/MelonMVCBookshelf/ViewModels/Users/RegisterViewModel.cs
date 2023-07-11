using System.ComponentModel.DataAnnotations;

namespace MelonMVCBookshelf.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.Text)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
    }
}
