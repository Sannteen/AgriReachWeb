using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AgriReachWeb.ViewComponents
{
    public class FarmMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var farms = new List<string>()
            {
                 " Green Valley Farm",
                "Tropical Farm",
                 " Oak Tree Farm",
                 "Valley Farm"
                 
                                
            };

            return View(farms);
        }
    }
}
