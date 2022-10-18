using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace WestwindWebApp.Pages
{
    public class SendMailModel : PageModel
    {
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
        

        

        public void OnGet()
        {
            //MailUsername = "sydneyengblom@gmail.com";
            //MailAppPassword = "";
            //EmailToAddress = "sydneyengblom@gmail.com";
            //EmailSubject = "Hi";
            //EmailMessage = "using razor page";

            //var sendMailClient = new SmtpClient();
            //sendMailClient.Host = "smtp.gmail.com";
            //sendMailClient.Port = 587;
            //sendMailClient.EnableSsl = true;
            //var sendMailCredentials = new NetworkCredential();
            //sendMailCredentials.UserName = MailUsername;
            //sendMailCredentials.Password = MailAppPassword;
            //sendMailClient.Credentials = sendMailCredentials;

            //var sendFromAddress = new MailAddress(MailUsername);
            //var sendToAddress = new MailAddress(EmailToAddress);

            //var mailMessage = new MailMessage(sendFromAddress, sendToAddress);
            //mailMessage.Subject = EmailSubject;
            //mailMessage.Body = EmailMessage;
            //sendMailClient.Send(mailMessage);


        }
        

    }
}
