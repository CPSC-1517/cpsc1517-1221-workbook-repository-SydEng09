using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WestWindSystem.BLL;
using WestWindSystem.Entities;
namespace WestwindWebApp.Pages.Products
{
    public class QueryModel : PageModel
    {
        private readonly CategoryServices _categoryServices;

        public QueryModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public List<Category> CategoryList { get; private set; }
        [BindProperty()]
        public int? SelectedCategoryId { get; set; }
        public SelectList CategorySelectList { get; set; }
        public void OnGet(int? currentSelectedCategoryId)
        {
           
            CategoryList = _categoryServices.List();
            CategorySelectList = new SelectList(_categoryServices.List(), "Id", "CategoryName", SelectedCategoryId);
            if (currentSelectedCategoryId.HasValue && currentSelectedCategoryId.Value > 0)
            {
                SelectedCategoryId = currentSelectedCategoryId.Value;
            }
        }
        public IActionResult OnPostSearchByCategory()
        {
            return RedirectToPage(new {currentSelectedCategoryId=SelectedCategoryId});
        }
        public IActionResult OnPostSearchByProductName()
        {
            return RedirectToPage();
        }
        public IActionResult OnPostClearForm()
        {
            return RedirectToPage();
        }
    }
}
