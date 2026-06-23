using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public async Task<IActionResult> Index()
        {
            var stats = await _statisticsService.LoadAllAsync();
            var mappedStats = stats.Select(s => new StatisticsViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Order = s.Order,
                IsActive = s.IsActive
            }).ToList();

            return View(mappedStats);
        }

        public IActionResult Create()
        {
            return View(new StatisticsViewModel { Order = 5, IsActive = true });
        }

        [HttpPost]
        public async Task<IActionResult> Create(StatisticsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var stats = new Statistics
            {
                Title = model.Title,
                Description = model.Description,
                Order = model.Order,
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _statisticsService.AddAsync(stats);
            TempData["SuccessMessage"] = "Yeni statistika göstəricisi uğurla əlavə edildi!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var stats = await _statisticsService.GetByIdAsync(id);
            if (stats == null)
            {
                return NotFound();
            }

            var viewModel = new StatisticsViewModel
            {
                Id = stats.Id,
                Title = stats.Title,
                Description = stats.Description,
                Order = stats.Order,
                IsActive = stats.IsActive
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StatisticsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var stats = await _statisticsService.GetByIdAsync(model.Id);
            if (stats == null)
            {
                return NotFound();
            }

            stats.Title = model.Title;
            stats.Description = model.Description;
            stats.Order = model.Order;
            stats.IsActive = model.IsActive;
            stats.UpdatedAt = DateTime.UtcNow;

            await _statisticsService.UpdateAsync(stats);
            TempData["SuccessMessage"] = "Statistika göstəricisi uğurla yeniləndi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _statisticsService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Statistika göstəricisi uğurla silindi!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
