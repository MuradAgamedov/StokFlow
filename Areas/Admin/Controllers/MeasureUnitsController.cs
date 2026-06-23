using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using ModernWMC.Models.Concrete;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MeasureUnitsController : Controller
    {
        private readonly IMeasureUnitService _measureUnitService;

        public MeasureUnitsController(IMeasureUnitService measureUnitService)
        {
            _measureUnitService = measureUnitService;
        }

        public async Task<IActionResult> Index(string? search)
        {
            ViewData["CurrentFilter"] = search;
            IEnumerable<MeasureUnit> units;

            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.ToLower();
                units = await _measureUnitService.LoadAllAsync(
                    e => e.Name.ToLower().Contains(lowerSearch) ||
                         e.Code.ToLower().Contains(lowerSearch) ||
                         (e.Description != null && e.Description.ToLower().Contains(lowerSearch))
                );
            }
            else
            {
                units = await _measureUnitService.LoadAllAsync();
            }

            var mappedUnits = units.Select(u => new MeasureUnitViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Code = u.Code,
                Description = u.Description,
                IsActive = u.IsActive
            }).ToList();

            return View(mappedUnits);
        }

        public IActionResult Create()
        {
            return View(new MeasureUnitViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(MeasureUnitViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var unit = new MeasureUnit
            {
                Name = model.Name,
                Code = model.Code,
                Description = model.Description ?? string.Empty,
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _measureUnitService.AddAsync(unit);
            TempData["SuccessMessage"] = "Yeni ölçü vahidi uğurla əlavə edildi!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var unit = await _measureUnitService.GetByIdAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            var viewModel = new MeasureUnitViewModel
            {
                Id = unit.Id,
                Name = unit.Name,
                Code = unit.Code,
                Description = unit.Description,
                IsActive = unit.IsActive
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MeasureUnitViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var unit = await _measureUnitService.GetByIdAsync(model.Id);
            if (unit == null)
            {
                return NotFound();
            }

            unit.Name = model.Name;
            unit.Code = model.Code;
            unit.Description = model.Description ?? string.Empty;
            unit.IsActive = model.IsActive;
            unit.UpdatedAt = DateTime.UtcNow;

            await _measureUnitService.UpdateAsync(unit);
            TempData["SuccessMessage"] = "Ölçü vahidi məlumatları uğurla yeniləndi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _measureUnitService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Ölçü vahidi uğurla silindi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Ölçü vahidi silinərkən xəta baş verdi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
