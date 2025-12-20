
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgriReachWeb.Models;
using AgriReachWeb.ViewModels;

namespace AgriReachWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AgriReachDbContext _context;

        public ProductsController(AgriReachDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(string? category)
        {
            var productsQuery = _context.FarmProducts
                .Include(fp => fp.Product)
                .Include(fp => fp.Farm)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                productsQuery = productsQuery
                    .Where(fp => fp.Product.ProductCategory.ProductCategoryName == category);
            }

            var products = productsQuery
                .Select(fp => new ProductListVM
                {
                    ProductName = fp.Product.ProductName,
                    Price = fp.BasePrice ?? fp.Product.Price,
                    Unit = fp.Unit ?? fp.Product.Unit,
                    FarmName = fp.Farm.FarmName,
                    AvailabilityStatus = fp.AvailabilityStatus
                })
                .ToList();

            return View(products);
        }

    }
}





