using Microsoft.AspNetCore.Mvc;
using ModernWMC.Services.Abstract;
using ModernWMC.Services.Concrete;
using ModernWMC.ViewModels;

namespace ModernWMC.Controllers
{
    public class FaqController : Controller
    {
        private readonly IFAQService _faqService;


        public FaqController(IFAQService faqService)
        {

            _faqService = faqService;

        }
        public async Task<IActionResult> Index()
        {
            var faq = (await _faqService.LoadAllAsync()).ToList();

            var faqViewModel = new FAQViewModel
            {
                FAQ = faq,
            };
            return View(faqViewModel);
        }
    }
}
