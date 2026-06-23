using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FaqController : Controller
    {
        private readonly IFAQService _faqService;

        public FaqController(IFAQService faqService)
        {
            _faqService = faqService;
        }

        public async Task<IActionResult> Index()
        {
            var faqs = await _faqService.LoadAllAsync();
            var mappedFaqs = faqs.Select(f => new FAQViewModel
            {
                Id = f.Id,
                Question = f.Question,
                Answer = f.Answer,
                Order = f.Order,
                IsActive = f.IsActive
            }).ToList();

            return View(mappedFaqs);
        }

        public IActionResult Create()
        {
            return View(new FAQViewModel { Order = 1, IsActive = true });
        }

        [HttpPost]
        public async Task<IActionResult> Create(FAQViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var faq = new FAQ
            {
                Question = model.Question,
                Answer = model.Answer,
                Order = model.Order,
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _faqService.AddAsync(faq);
            TempData["SuccessMessage"] = "Yeni FAQ sualı uğurla əlavə edildi!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var faq = await _faqService.GetByIdAsync(id);
            if (faq == null)
            {
                return NotFound();
            }

            var viewModel = new FAQViewModel
            {
                Id = faq.Id,
                Question = faq.Question,
                Answer = faq.Answer,
                Order = faq.Order,
                IsActive = faq.IsActive
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FAQViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var faq = await _faqService.GetByIdAsync(model.Id);
            if (faq == null)
            {
                return NotFound();
            }

            faq.Question = model.Question;
            faq.Answer = model.Answer;
            faq.Order = model.Order;
            faq.IsActive = model.IsActive;
            faq.UpdatedAt = DateTime.UtcNow;

            await _faqService.UpdateAsync(faq);
            TempData["SuccessMessage"] = "FAQ sualı uğurla yeniləndi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _faqService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "FAQ sualı uğurla silindi!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
