using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WepAppCoches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly IConfiguration _configuration;
        public EmailController(
            ISendGridClient sendGridClient,
            IConfiguration configuration)
        {
            _sendGridClient = sendGridClient;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("send-text-mail")]
        public async Task<IActionResult> SendPlainTextEmail(string toEmail)
        {
            string fromEmail = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromEmail");

            string fromName = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromName");

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = "Plain Text Email",
                PlainTextContent = "Hello, WellCome!!!"
            };
            msg.AddTo(toEmail);
            var response = await _sendGridClient.SendEmailAsync(msg);
            string message = response.IsSuccessStatusCode ? "Email Send Successfully" :
            "Email Sending Failed";
            return Ok(message);
        }
       /* [HttpPost]
        [Route("send-html-mail")]
        public async Task<IActionResult> SendHtmlEmail(SuperHeroEmail heroEmail)
        {
            string fromEmail = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromEmail");

            string fromName = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromName");

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = "HTML Email",
                HtmlContent = EmailHTMLTemplate(heroEmail)
            };
            msg.AddTo(heroEmail.ToEmail);
            var response = await _sendGridClient.SendEmailAsync(msg);
            string message = response.IsSuccessStatusCode ? "Email Send Successfully" :
            "Email Sending Failed";
            return Ok(message);
        }*/
    }
}
