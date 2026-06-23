using Microsoft.AspNetCore.Mvc;
using ModernWMC.Services.Abstract;
using ModernWMC.ViewModels;

namespace ModernWMC.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ICtaService _ctaService;

        public FooterViewComponent(ICtaService ctaService)
        {
            _ctaService = ctaService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cta = await _ctaService.LoadAllAsync();
            return View(new CtaViewModel { Cta = cta });
        }
    }
}
