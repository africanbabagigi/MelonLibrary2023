using System.ComponentModel.DataAnnotations;

namespace MelonMVCBookshelf.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.Text)]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Password { get; set; }
    }
}
