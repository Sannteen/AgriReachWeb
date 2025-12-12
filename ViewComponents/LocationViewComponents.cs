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
                "St. Mary",
                "Clarendon",
                "St. Catherine"
            };

            return View(locations);
        }

    }
}
