using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TermsController : Controller
    {
        private readonly ITermsOfUseService _termsOfUseService;

        public TermsController(ITermsOfUseService termsOfUseService)
        {
            _termsOfUseService = termsOfUseService;
        }

        public async Task<IActionResult> Index()
        {
            var terms = await _termsOfUseService.LoadFirstAsync();

            var viewModel = new TermsOfUseViewModel
            {
                Id = terms.Id,
                Title = terms.Title,
                Subtext = terms.SubText,
                BodyContent = terms.Content
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TermsOfUseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var terms = new TermsOfUse
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                SubText = viewModel.Subtext,
                Content = viewModel.BodyContent,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _termsOfUseService.UpdateAsync(terms);
            if (result)
            {
                TempData["SuccessMessage"] = "İstifadə şərtləri uğurla yeniləndi!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
