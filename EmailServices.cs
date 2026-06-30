using System.Net;
using System.Net.Mail;

namespace Hotelreservation.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(string subject, string body)
        {
            var email = _config["EmailSettings:Email"];
            var password = _config["EmailSettings:Password"];

            var client = new SmtpClient(_config["EmailSettings:Host"])
            {
               // Port = int.Parse(_config["EmailSettings:Port"]),
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
               // From = new MailAddress(email),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            //Manager email
            mail.To.Add("hotel@gmail.com");

            client.Send(mail);
        }
    }
}