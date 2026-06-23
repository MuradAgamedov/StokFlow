using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LocationsController : Controller
    {
        private readonly IAddressService _addressService;

        public LocationsController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IActionResult> Index()
        {
            var addresses = await _addressService.LoadAllAsync();
            var mappedAddresses = addresses.Select(a => new AddressViewModel
            {
                Id = a.Id,
                Title = a.Title,
                Label = a.Label,
                Order = a.Order,
                IsActive = a.IsActive
            }).ToList();

            return View(mappedAddresses);
        }

        public IActionResult Create()
        {
            return View(new AddressViewModel { Order = 1, IsActive = true });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var address = new Address
            {
                Title = model.Title,
                Label = model.Label,
                Order = model.Order,
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _addressService.AddAsync(address);
            TempData["SuccessMessage"] = "Yeni ünvan uğurla əlavə edildi!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            var viewModel = new AddressViewModel
            {
                Id = address.Id,
                Title = address.Title,
                Label = address.Label,
                Order = address.Order,
                IsActive = address.IsActive
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var address = await _addressService.GetByIdAsync(model.Id);
            if (address == null)
            {
                return NotFound();
            }

            address.Title = model.Title;
            address.Label = model.Label;
            address.Order = model.Order;
            address.IsActive = model.IsActive;
            address.UpdatedAt = DateTime.UtcNow;

            await _addressService.UpdateAsync(address);
            TempData["SuccessMessage"] = "Ünvan uğurla yeniləndi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _addressService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Ünvan uğurla silindi!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
