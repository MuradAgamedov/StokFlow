using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EmailsController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            var emails = await _emailService.LoadAllAsync();
            var mappedEmails = emails.Select(e => new EmailViewModel
            {
                Id = e.Id,
                Title = e.Title,
                Label = e.Label,
                Order = e.order,
                IsActive = e.IsActive
            }).ToList();

            return View(mappedEmails);
        }

        public IActionResult Create()
        {
            return View(new EmailViewModel { Order = 1, IsActive = true });
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var email = new Email
            {
                Title = model.Title,
                Label = model.Label,
                order = model.Order,
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _emailService.AddAsync(email);
            TempData["SuccessMessage"] = "Yeni e-poçt ünvanı uğurla daxil edildi!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var email = await _emailService.GetByIdAsync(id);
            if (email == null)
            {
                return NotFound();
            }

            var viewModel = new EmailViewModel
            {
                Id = email.Id,
                Title = email.Title,
                Label = email.Label,
                Order = email.order,
                IsActive = email.IsActive
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var email = await _emailService.GetByIdAsync(model.Id);
            if (email == null)
            {
                return NotFound();
            }

            email.Title = model.Title;
            email.Label = model.Label;
            email.order = model.Order;
            email.IsActive = model.IsActive;
            email.UpdatedAt = DateTime.UtcNow;

            var result = await _emailService.UpdateAsync(email);
            if (result)
            {
                TempData["SuccessMessage"] = "E-poçt ünvanı uğurla yeniləndi!";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _emailService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "E-poçt ünvanı uğurla silindi!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
