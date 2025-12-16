using Microsoft.AspNetCore.Mvc;

namespace AgriReachWeb.ViewComponents
{
    public class LocationMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var locations = new List<string>()
            {
                "Kingston & St. Andrew",
                "more locations coming soon..."
            };

            return View(locations);
        }

    }
}
