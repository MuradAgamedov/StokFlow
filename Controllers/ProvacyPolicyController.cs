using Microsoft.AspNetCore.Mvc;
using ModernWMC.Services.Abstract;
using ModernWMC.ViewModels;

namespace ModernWMC.Controllers
{
    public class PrivacyPolicyController : Controller
    {
        private readonly IPrivacyPolicyService _privacyPolicyService;

        public PrivacyPolicyController(IPrivacyPolicyService privacyPolicyService)
        {
            _privacyPolicyService = privacyPolicyService;
        }

        public async Task<IActionResult> Index()
        {
            var privacyPolicy = await _privacyPolicyService.LoadFirstAsync();

            var privacyPolicyViewModel = new PrivacyPolicyViewModel
            {
                PrivacyPolicy = privacyPolicy,
            };
            return View(privacyPolicyViewModel);
        }
    }
}
