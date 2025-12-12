using Microsoft.AspNetCore.Mvc;
using AgriReachWeb.Models;

namespace AgriReachWeb.ViewComponents
{
    public class ProductCategoryMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = new List<ProductCategory>()
            {
                new ProductCategory {ProductCategoryId = 1, ProductCategoryName = "Fruits"},
                new ProductCategory {ProductCategoryId = 2, ProductCategoryName = "Vegetables"},
                new ProductCategory {ProductCategoryId = 3, ProductCategoryName = "Herbs"},
                new ProductCategory {ProductCategoryId = 4, ProductCategoryName = "Spice & Seasoning"},
                new ProductCategory {ProductCategoryId = 5, ProductCategoryName = "Ground Provisions"},
                new ProductCategory {ProductCategoryId = 6, ProductCategoryName = "Honey & Preserves"},
                new ProductCategory {ProductCategoryId = 7, ProductCategoryName = "Prepared Foods"},
            };

            return View(categories);
        }
    }
}
