using HD_Support_API.Migrations;
using HD_Support_API.Repositorios.Interfaces;
using System.Net;
using System.Net.Mail;

namespace HD_Support_API.Repositorios
{
    public class EmailSenderRepositorio : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string menssagem)
        {
            var mail = "testejoazinl2r2@hotmail.com";
            var senha = "admin123Empl@yer";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, senha)
            };
            return client.SendMailAsync(
                new MailMessage(from: mail,
                                to: email,
                                subject, menssagem
                                ));
        }
    }
}
