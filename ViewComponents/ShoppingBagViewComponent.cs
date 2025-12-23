using Microsoft.AspNetCore.Mvc;
using AgriReachWeb.Models;
using System.Linq;

namespace AgriReachWeb.ViewComponents
{
    public class ShoppingBagViewComponent : ViewComponent
    {
        private readonly AgriReachDbContext _context;

        public ShoppingBagViewComponent(AgriReachDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // TEMP: Replace with logged-in user's shopping list
            int shoppingListId = 1;

            var itemCount = _context.ShoppingListItems
                .Where(s => s.ListId == shoppingListId)
                .Sum(s => s.Quantity);

            return View(itemCount);
        }
    }
}
