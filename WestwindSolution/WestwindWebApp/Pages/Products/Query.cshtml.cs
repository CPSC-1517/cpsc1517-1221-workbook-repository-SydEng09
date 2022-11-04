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
        private readonly ProductServices _productServices;

        public QueryModel(CategoryServices categoryServices, ProductServices productServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;

            CategoryList = _categoryServices.List();
            CategorySelectList = new SelectList(_categoryServices.List(), "Id", "CategoryName", SelectedCategoryId);
        }

        public List<Category> CategoryList { get; private set; }
        [BindProperty()]
        public int SelectedCategoryId { get; set; }
        public SelectList CategorySelectList { get; set; }
        [TempData]
        public string FeedBackMessage { get; set; }
        [BindProperty]
        public string? QueryProductName { get; set; }
        public List<Product>? QueryResultList { get; private set; }
        public void OnGet()
        {
         
            //if (currentSelectedCategoryId.HasValue && currentSelectedCategoryId.Value > 0)
            //{
            //    SelectedCategoryId = currentSelectedCategoryId.Value;
            //}
        }
        public void OnPostSearchByCategory()
        {
            FeedBackMessage = "You clicked search by category";
            QueryResultList = _productServices.FindProductsByCategoryId(SelectedCategoryId);
        }
        public void OnPostSearchByProductName()
        {
            FeedBackMessage = "You clicked product name";
            QueryResultList = _productServices.FindProductByProductName(QueryProductName);
        }
        public IActionResult OnPostClearForm()
        {
            FeedBackMessage = "You clicked the clear button";
            //SelectedCategoryId = 0;
            //QueryProductName = null;
            return RedirectToPage();
        }
    }
}
