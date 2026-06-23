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
    public class HeroController : Controller
    {
        private readonly IHeroService _heroService;

        public HeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        public async Task<IActionResult> Index()
        {
            var hero = await _heroService.LoadFirstAsync();
            if (hero == null)
            {
                return NotFound();
            }

            var viewModel = new HeroViewModel
            {
                Id = hero.Id,
                Label = hero.Label,
                Title = hero.Title,
                SubText = hero.SubText,
                ImageUrl = hero.ImageUrl
            };

            return View(viewModel);
        }




        [HttpPost]
        public async Task<IActionResult> Index(HeroViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var hero = new Hero
            {
                Id = viewModel.Id,
                Label = viewModel.Label,
                Title = viewModel.Title,
                SubText = viewModel.SubText,
                ImageUrl = viewModel.ImageUrl
            };

            var result = await _heroService.UpdateAsync(hero,viewModel.Image);
            if (result)
            {
                TempData["SuccessMessage"] = "Hero kontenti uğurla yeniləndi!";
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
