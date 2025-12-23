using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgriReachWeb.Models;  
using System.Linq;
using System.Threading.Tasks;

namespace AgriReachWeb.Controllers
{
    public class ShoppingBagController : Controller
    {
        private readonly AgriReachDbContext _context; 

        public ShoppingBagController(AgriReachDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            
            int shoppingListId = 1;

            
            var items = await _context.ShoppingListItems
                .Include(s => s.Product)
                .Where(s => s.ListId == shoppingListId)
                .ToListAsync();

            return View(items);
        }
    }
}

