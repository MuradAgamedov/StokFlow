using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TelephonesController : Controller
    {
        private readonly IPhoneService _phoneService;

        public TelephonesController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        public async Task<IActionResult> Index()
        {
            var phones = await _phoneService.LoadAllAsync();
            var mappedPhones = phones.Select(p => new PhoneViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Label = p.Label,
                Order = p.order,
                IsActive = p.IsActive
            }).ToList();

            return View(mappedPhones);
        }

        public IActionResult Create()
        {
            return View(new PhoneViewModel { Order = 1, IsActive = true });
        }

        [HttpPost]
        public async Task<IActionResult> Create(PhoneViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var phone = new Phone
            {
                Title = model.Title,
                Label = model.Label,
                EmbedMap = string.Empty,
                order = model.Order,
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _phoneService.AddAsync(phone);
            TempData["SuccessMessage"] = "Yeni telefon nömrəsi uğurla əlavə edildi!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var phone = await _phoneService.GetByIdAsync(id);
            if (phone == null)
            {
                return NotFound();
            }

            var viewModel = new PhoneViewModel
            {
                Id = phone.Id,
                Title = phone.Title,
                Label = phone.Label,
                Order = phone.order,
                IsActive = phone.IsActive
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PhoneViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var phone = await _phoneService.GetByIdAsync(model.Id);
            if (phone == null)
            {
                return NotFound();
            }

            phone.Title = model.Title;
            phone.Label = model.Label;
            phone.order = model.Order;
            phone.IsActive = model.IsActive;
            phone.UpdatedAt = DateTime.UtcNow;

            await _phoneService.UpdateAsync(phone);
            TempData["SuccessMessage"] = "Telefon nömrəsi uğurla yeniləndi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _phoneService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Telefon nömrəsi uğurla silindi!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
