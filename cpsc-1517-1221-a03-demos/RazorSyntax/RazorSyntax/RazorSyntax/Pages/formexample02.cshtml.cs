using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSyntax.Pages
{
    public class formexample02Model : PageModel
    {
        public void OnGET()
        {

        }
        public string FeedBackMessage { get; set; };
        public void OnPOST()
        {
            var rand = new Random();
            var generatedNumber = new List<int>();
            while (generatedNumber.Count < 7)
            {
                var randomNumber=rand.Next(1, 51);
                if (!generatedNumber.Contains(randomNumber))
                {
                    generatedNumber.Add(randomNumber);
                }
            }
            generatedNumber.Sort();
            FeedBackMessage = "";
            foreach(var num in generatedNumber)
            {
                FeedBackMessage += num + " ";
            }
            FeedBackMessage = generatedNumber.ToString();
        }
    }
}
