using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace WestwindWebApp.Pages
{
    public class SendMailModel : PageModel
    {
        public void OnGet()
        {
            var gmailUsername = Configuration["GmailCredentials:Username"];
            var gmailAppPassword = Configuration["GmailCredentials:Password"];
            FeedbackMessage = $"Gmail Username = {gmailUsername} <br/>";
            FeedbackMessage +=$"Gmail App Passwowrd ={gmailAppPassword}";

        }
        private readonly IConfiguration Configuration;
        public SendMailModel(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        [BindProperty]
        public string FeedbackMessage { get; set; }
        [BindProperty]
        public string MailUsername { get; set; }
        [BindProperty]
        public string MailAppPassword { get; set; }
        [BindProperty]
        public string EmailToAddress { get; set; }
        [BindProperty]
        public string EmailSubject { get; set; }
        [BindProperty]
        public string EmailMessage { get; set; }
        public void OnPostSendMail()
        {
            // FeedbackMessage = "<h2>Send Mail button clicked</h2>";
            var sendMailClient = new SmtpClient();
            sendMailClient.Host = "smtp.gmail.com";
            sendMailClient.Port = 587;
            sendMailClient.EnableSsl = true;
            var sendMailCredentials = new NetworkCredential();
            MailUsername = Configuration["GmailCredentials:Username"];
            MailAppPassword= Configuration["GmailCredentials:Password"];
            sendMailCredentials.UserName = MailUsername;
            sendMailCredentials.Password = MailAppPassword;
            sendMailClient.Credentials = sendMailCredentials;

            var sendFromAddress = new MailAddress(MailUsername);
            var sendToAddress = new MailAddress(EmailToAddress);

            var mailMessage = new MailMessage(sendFromAddress, sendToAddress);
            mailMessage.Subject = EmailSubject;
            mailMessage.Body = EmailMessage;

            try
            {
                sendMailClient.Send(mailMessage);
                FeedbackMessage = "<div class='alert alert-primary'>Email sent</div";
            }
            catch (Exception)
            {
                FeedbackMessage = "<div class='alert alert-danger'>Error sending email</div";
            }
        }
        public void OnPostClearForm()
        {
            FeedbackMessage="<h2>Clear Form button clicked</h2>";
        }
        
        

    }
}
