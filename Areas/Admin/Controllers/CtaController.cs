using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CtaController : Controller
    {
        private readonly ICtaService _ctaService;

        public CtaController(ICtaService ctaService)
        {
            _ctaService = ctaService;
        }

        public async Task<IActionResult> Index()
        {
            var cta = await _ctaService.LoadAllAsync();

            var viewModel = new CtaViewModel
            {
                Id = cta?.Id ?? 0,
                Title = cta?.Title ?? string.Empty,
                Description = cta?.Description ?? string.Empty,
                ButtonText = cta?.ButtonText ?? string.Empty,
                Url = cta?.Url ?? string.Empty
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CtaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var cta = await _ctaService.LoadAllAsync();
            if (cta == null)
            {
                cta = new Cta
                {
                    CreatedAt = DateTime.UtcNow
                };
            }

            cta.Title = model.Title;
            cta.Description = model.Description;
            cta.ButtonText = model.ButtonText;
            cta.Url = model.Url;
            cta.UpdatedAt = DateTime.UtcNow;

            await _ctaService.UpdateAsync(cta);
            TempData["SuccessMessage"] = "CTA banner məlumatları uğurla yeniləndi!";
            return RedirectToAction(nameof(Index));
        }
    }
}
