using Microsoft.AspNetCore.Mvc;

namespace ModernWMC.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}