using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MapsController : Controller
    {
        private readonly IMapService _mapService;

        public MapsController(IMapService mapService)
        {
            _mapService = mapService;
        }

        public async Task<IActionResult> Index()
        {
            var maps = await _mapService.LoadAllAsync();
            var mappedMaps = maps.Select(m => new MapViewModel
            {
                Id = m.Id,
                Title = m.Title,
                EmbedCode = m.EmbedCode,
                Order = m.Order,
                IsActive = m.IsActive
            }).ToList();

            return View(mappedMaps);
        }

        public IActionResult Create()
        {
            return View(new MapViewModel { Order = 1, IsActive = true });
        }

        [HttpPost]
        public async Task<IActionResult> Create(MapViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var map = new Map
            {
                Title = model.Title,
                EmbedCode = model.EmbedCode,
                Order = model.Order,
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _mapService.AddAsync(map);
            TempData["SuccessMessage"] = "Yeni xəritə uğurla əlavə edildi!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var map = await _mapService.GetByIdAsync(id);
            if (map == null)
            {
                return NotFound();
            }

            var viewModel = new MapViewModel
            {
                Id = map.Id,
                Title = map.Title,
                EmbedCode = map.EmbedCode,
                Order = map.Order,
                IsActive = map.IsActive
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MapViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var map = await _mapService.GetByIdAsync(model.Id);
            if (map == null)
            {
                return NotFound();
            }

            map.Title = model.Title;
            map.EmbedCode = model.EmbedCode;
            map.Order = model.Order;
            map.IsActive = model.IsActive;
            map.UpdatedAt = DateTime.UtcNow;

            await _mapService.UpdateAsync(map);
            TempData["SuccessMessage"] = "Xəritə uğurla yeniləndi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mapService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Xəritə uğurla silindi!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
