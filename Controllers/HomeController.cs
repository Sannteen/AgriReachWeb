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
