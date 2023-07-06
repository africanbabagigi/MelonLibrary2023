using System.Threading.Tasks;

namespace MelonMVCBookshelf.Services
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message);
    }
}
