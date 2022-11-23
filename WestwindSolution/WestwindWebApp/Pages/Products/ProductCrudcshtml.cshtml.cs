using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;

namespace WestwindWebApp.Pages.Products
{
    public class ProductCrudcshtmlModel : PageModel
    {
        private readonly CategoryServices categoryServices;
        private readonly ProductServices productServices;

        [BindProperty(SupportsGet =true)]
        public int? EditProductId { get; set; }
        public void OnGet()
        {
        }
    }
}
