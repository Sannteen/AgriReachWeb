using System.Diagnostics;
using AgriReachWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgriReachWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var ProductCategory = new List<ProductCategory>()
            {
                new ProductCategory {ProductCategoryId = 1, ProductCategoryName = "Fruits"},
                new ProductCategory {ProductCategoryId = 2, ProductCategoryName = "Vegetables"}, 
                new ProductCategory {ProductCategoryId = 3, ProductCategoryName = "Herbs"},
                new ProductCategory {ProductCategoryId = 4, ProductCategoryName = "Spice & Seasoning"},
                new ProductCategory {ProductCategoryId = 5, ProductCategoryName = "Ground Provisions"},
                new ProductCategory {ProductCategoryId = 6, ProductCategoryName = "Honey & Preserves"},
                new ProductCategory {ProductCategoryId = 7, ProductCategoryName = "Prepared Foods"},
            };
            ViewBag.ProductCategory = ProductCategory;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
