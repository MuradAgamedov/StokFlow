using Microsoft.AspNetCore.Mvc;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using ModernWMC.Services.Concrete;
using ModernWMC.ViewModels;

namespace MyApp.Namespace
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;


        public AboutController(IAboutService aboutService)
        {

            _aboutService = aboutService;

        }

        public async Task<IActionResult> Index()
        {
            var about = await _aboutService.LoadFirstAsync();

            var aboutViewModel = new AboutViewModel
            {
                About = about,
            };
            return View(aboutViewModel);
        }

    }
}
