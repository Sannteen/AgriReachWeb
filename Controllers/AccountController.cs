using Microsoft.AspNetCore.Mvc;

namespace AgriReachWeb.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]  // For the form button
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();  // Logs out the user
            return RedirectToAction("Index", "Home");  // Goes back to home page
        }

        // Optional: If you want a simple link (no form)
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Index", "Home");
        //}
    }
}