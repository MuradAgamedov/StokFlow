using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Concrete;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
                Id = about.Id,
                WhoAreWeTitle = about.WhoAreWeTitle,
                WhoAreWeDescription = about.WhoAreWeDescription,
                OurMissionTitle = about.OurMissionTitle,
                OurMissionDescription = about.OurMissionDescription,
                WhoAreWeListTitle = about.WhoAreWeListTitle,
                WhoAreWeListFirstTextTitle = about.WhoAreWeListFirstTextTitle,
                WhoAreWeListFirstText = about.WhoAreWeListFirstText,
                WhoAreWeListSecondTextTitle = about.WhoAreWeListSecondTextTitle,
                WhoAreWeListSecondText = about.WhoAreWeListSecondText,
                WhoAreWeListThirdTextTitle = about.WhoAreWeListThirdTextTitle,
                WhoAreWeListThirdText = about.WhoAreWeListThirdText
            };
            return View(aboutViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AboutViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var about = new About
            {
                Id = viewModel.Id,
                WhoAreWeTitle = viewModel.WhoAreWeTitle,
                WhoAreWeDescription = viewModel.WhoAreWeDescription,

                OurMissionTitle = viewModel.OurMissionTitle,
                OurMissionDescription = viewModel.OurMissionDescription,

                WhoAreWeListTitle = viewModel.WhoAreWeListTitle,

                WhoAreWeListFirstTextTitle = viewModel.WhoAreWeListFirstTextTitle,
                WhoAreWeListFirstText = viewModel.WhoAreWeListFirstText,

                WhoAreWeListSecondTextTitle = viewModel.WhoAreWeListSecondTextTitle,
                WhoAreWeListSecondText = viewModel.WhoAreWeListSecondText,

                WhoAreWeListThirdTextTitle = viewModel.WhoAreWeListThirdTextTitle,
                WhoAreWeListThirdText = viewModel.WhoAreWeListThirdText,

                UpdatedAt = DateTime.UtcNow
            };

            var result = await _aboutService.UpdateAsync(about);
            if (result)
            {
                TempData["SuccessMessage"] = "Haqqımızda kontenti uğurla yeniləndi!";
            }
            return RedirectToAction(nameof(Index));
        }



    }
}
