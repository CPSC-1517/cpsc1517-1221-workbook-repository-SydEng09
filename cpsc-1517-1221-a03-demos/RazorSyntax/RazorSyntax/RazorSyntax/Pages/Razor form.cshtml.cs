using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSyntax.Pages
{
    public class Razor_formModel : PageModel
    {
        public string FeedbackMessage { get; set; }
        public void OnGet()
        {
            FeedbackMessage = "This page was accessed using a GET request";
        }
        public void OnPost()
        {
            FeedbackMessage = "This page was posted using the Submit button.";
        }
    }
}
