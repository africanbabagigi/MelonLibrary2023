using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace MelonMVCBookshelf.Services
{
    public class EmailSender:IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            string senderMail = "melonemailsender@gmail.com";
            string password = "gcohdwuehlclgcoy";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 465)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(senderMail, password)
            };

            return smtpClient.SendMailAsync(
                new MailMessage(
                    from: senderMail,
                    to: email,
                    subject,
                    message
                    ));
        }
    }
}
