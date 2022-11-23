using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestwindWebApp.Pages.Products
{
    
    
        public class ProductCategoryModel : PageModel
        {
            private readonly CategoryServices _categoryServices;
            private readonly ProductServices _productServices;

            public ProductCategoryModel(CategoryServices categoryServices, ProductServices productServices)
            {
                _categoryServices = categoryServices;
                _productServices = productServices;

                CategoryList = _categoryServices.List();
                CategorySelectList = new SelectList(_categoryServices.List(), "Id", "CategoryName", SelectedCategoryId);
            }

            public List<Category> CategoryList { get; private set; }
            [BindProperty()]
            public int? SelectedCategoryId { get; set; }
            public SelectList CategorySelectList { get; set; }
            [TempData]
            public string FeedBackMessage { get; set; }
            [BindProperty]
            public List<Product>? QueryResultList { get; private set; }
        public string? ErrorMessage { get; set; }
            public void OnGet()
            {

                //if (currentSelectedCategoryId.HasValue && currentSelectedCategoryId.Value > 0)
                //{
                //    SelectedCategoryId = currentSelectedCategoryId.Value;
                //}
            }
            public IActionResult OnPostSearchByCategory()
            {
            IActionResult nextPage = Page();
            if(SelectedCategoryId.HasValue && SelectedCategoryId.Value > 0)
            {
                int categoryId = SelectedCategoryId.Value;
                QueryResultList = _productServices.FindProductsByCategoryId(categoryId);
                
            }
             
                
            return nextPage;
            }
        public IActionResult OnPostNewProduct()
        {
            IActionResult nextPage = RedirectToPage("/Product/ProductCrud");
            return nextPage;
        }
            public IActionResult OnPostClearForm()
            {
            IActionResult nextPage = Page();

                SelectedCategoryId = 0;
            QueryResultList = null;
            ModelState.Clear();
                //QueryProductName = null;
                return nextPage();
            }
        }
        
    }

