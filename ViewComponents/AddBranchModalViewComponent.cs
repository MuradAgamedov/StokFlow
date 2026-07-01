using Microsoft.AspNetCore.Mvc;

namespace ModernWMC.ViewComponents
{
    public class AddBranchModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
