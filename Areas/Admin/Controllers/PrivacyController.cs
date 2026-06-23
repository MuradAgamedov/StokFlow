using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PrivacyController : Controller
    {
        private readonly IPrivacyPolicyService _privacyPolicyService;

        public PrivacyController(IPrivacyPolicyService privacyPolicyService)
        {
            _privacyPolicyService = privacyPolicyService;
        }

        public async Task<IActionResult> Index()
        {
            var privacy = await _privacyPolicyService.LoadFirstAsync();

            var viewModel = new PrivacyPolicyViewModel
            {
                Id = privacy.Id,
                Title = privacy.Title,
                Subtext = privacy.SubText,
                BodyContent = privacy.Content
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(PrivacyPolicyViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var privacy = new PrivacyPolicy
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                SubText = viewModel.Subtext,
                Content = viewModel.BodyContent,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _privacyPolicyService.UpdateAsync(privacy);
            if (result)
            {
                TempData["SuccessMessage"] = "Gizlilik siyasəti uğurla yeniləndi!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
