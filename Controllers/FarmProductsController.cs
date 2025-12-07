using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriReachWeb.Models;

namespace AgriReachWeb.Controllers
{
    public class FarmProductsController : Controller
    {
        private readonly AgriReachDbContext _context;

        public FarmProductsController(AgriReachDbContext context)
        {
            _context = context;
        }

        // GET: FarmProducts
        public async Task<IActionResult> Index()
        {
            var agriReachDbContext = _context.FarmProducts.Include(f => f.Farm).Include(f => f.Product);
            return View(await agriReachDbContext.ToListAsync());
        }

        // GET: FarmProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmProduct = await _context.FarmProducts
                .Include(f => f.Farm)
                .Include(f => f.Product)
                .FirstOrDefaultAsync(m => m.FarmProductId == id);
            if (farmProduct == null)
            {
                return NotFound();
            }

            return View(farmProduct);
        }

        // GET: FarmProducts/Create
        public IActionResult Create()
        {
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: FarmProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FarmProductId,FarmId,ProductId,BasePrice,AvailabilityStatus,LastUpdated,Unit")] FarmProduct farmProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmId", farmProduct.FarmId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", farmProduct.ProductId);
            return View(farmProduct);
        }

        // GET: FarmProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmProduct = await _context.FarmProducts.FindAsync(id);
            if (farmProduct == null)
            {
                return NotFound();
            }
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmId", farmProduct.FarmId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", farmProduct.ProductId);
            return View(farmProduct);
        }

        // POST: FarmProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmProductId,FarmId,ProductId,BasePrice,AvailabilityStatus,LastUpdated,Unit")] FarmProduct farmProduct)
        {
            if (id != farmProduct.FarmProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmProductExists(farmProduct.FarmProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmId", farmProduct.FarmId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", farmProduct.ProductId);
            return View(farmProduct);
        }

        // GET: FarmProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmProduct = await _context.FarmProducts
                .Include(f => f.Farm)
                .Include(f => f.Product)
                .FirstOrDefaultAsync(m => m.FarmProductId == id);
            if (farmProduct == null)
            {
                return NotFound();
            }

            return View(farmProduct);
        }

        // POST: FarmProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmProduct = await _context.FarmProducts.FindAsync(id);
            if (farmProduct != null)
            {
                _context.FarmProducts.Remove(farmProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmProductExists(int id)
        {
            return _context.FarmProducts.Any(e => e.FarmProductId == id);
        }
    }
}
