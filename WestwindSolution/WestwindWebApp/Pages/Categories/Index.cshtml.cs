using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WestWindSystem.BLL;
using WestWindSystem.Entities;
using WestWindSystem.BLL;

namespace WestwindWebApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly CategoryServices _categoryServices;

        public IndexModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public List<Category> Categories { get; private set; } = new List<Category>();

        public void OnGet()
        {
            Categories = _categoryServices.List();
        }
    }
}
