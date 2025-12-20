using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgriReachWeb.Models;

namespace AgriReachWeb.ViewComponents
{
    public class ProductCategoryMenuViewComponent : ViewComponent
    {
        private readonly AgriReachDbContext _context;

        public ProductCategoryMenuViewComponent(AgriReachDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.ProductCategories
                .OrderBy(c => c.ProductCategoryName)
                .ToListAsync();

            return View(categories);
        }
    }
}
