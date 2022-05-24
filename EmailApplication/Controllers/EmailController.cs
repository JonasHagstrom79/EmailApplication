using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace EmailApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body) 
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(body));
            email.To.Add(MailboxAddress.Parse(body));
            email.Subject = "Test email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body }; 

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com");
        }
    }
}
