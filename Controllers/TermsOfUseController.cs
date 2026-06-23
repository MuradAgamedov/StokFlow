using Microsoft.AspNetCore.Mvc;
using ModernWMC.Services.Abstract;
using ModernWMC.ViewModels;

namespace ModernWMC.Controllers
{
    public class TermsOfUseController : Controller
    {
        private readonly ITermsOfUseService _termsOfUseService;

        public TermsOfUseController(ITermsOfUseService termsOfUseService)
        {
            _termsOfUseService = termsOfUseService;
        }

        public async Task<IActionResult> Index()
        {
            var termsOfUse = await _termsOfUseService.LoadFirstAsync();

            var viewModel = new TermsOfUseViewModel
            {
                TermsOfUse = termsOfUse,
            };
            return View(viewModel);
        }
    }
}
