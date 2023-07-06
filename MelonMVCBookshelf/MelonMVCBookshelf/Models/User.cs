using Microsoft.AspNetCore.Identity;

namespace MelonMVCBookshelf.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
