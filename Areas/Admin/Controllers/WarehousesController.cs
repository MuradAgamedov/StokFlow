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
    public class WarehousesController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehousesController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<IActionResult> Index(string? search)
        {
            ViewData["CurrentFilter"] = search;
            IEnumerable<Warehouse> warehouses;

            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.ToLower();
                warehouses = await _warehouseService.LoadAllAsync(
                    e => e.Name.ToLower().Contains(lowerSearch) || 
                         e.Code.ToLower().Contains(lowerSearch) ||
                         (e.ContactPerson != null && e.ContactPerson.ToLower().Contains(lowerSearch)) ||
                         (e.Address != null && e.Address.ToLower().Contains(lowerSearch))
                );
            }
            else
            {
                warehouses = await _warehouseService.LoadAllAsync();
            }

            var mappedWarehouses = warehouses.Select(w => new WarehouseViewModel
            {
                Id = w.Id,
                Name = w.Name,
                Code = w.Code,
                ContactPerson = w.ContactPerson,
                Capacity = w.Capacity,
                Address = w.Address,
                OccupancyPercentage = w.OccupancyPercentage,
                IsActive = w.IsActive
            }).ToList();

            return View(mappedWarehouses);
        }

        public IActionResult Create()
        {
            return View(new WarehouseViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WarehouseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var warehouse = new Warehouse
            {
                Name = model.Name,
                Code = model.Code,
                ContactPerson = model.ContactPerson,
                Capacity = model.Capacity,
                Address = model.Address,
                OccupancyPercentage = 0,
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _warehouseService.AddAsync(warehouse);
            TempData["SuccessMessage"] = "Yeni anbar uğurla əlavə edildi!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var warehouse = await _warehouseService.GetByIdAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            var viewModel = new WarehouseViewModel
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                Code = warehouse.Code,
                ContactPerson = warehouse.ContactPerson,
                Capacity = warehouse.Capacity,
                Address = warehouse.Address,
                OccupancyPercentage = warehouse.OccupancyPercentage,
                IsActive = warehouse.IsActive
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WarehouseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var warehouse = await _warehouseService.GetByIdAsync(model.Id);
            if (warehouse == null)
            {
                return NotFound();
            }

            warehouse.Name = model.Name;
            warehouse.Code = model.Code;
            warehouse.ContactPerson = model.ContactPerson;
            warehouse.Capacity = model.Capacity;
            warehouse.Address = model.Address;
            warehouse.IsActive = model.IsActive;
            warehouse.UpdatedAt = DateTime.UtcNow;

            await _warehouseService.UpdateAsync(warehouse);
            TempData["SuccessMessage"] = "Anbar məlumatları uğurla yeniləndi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _warehouseService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Anbar uğurla silindi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Anbar silinərkən xəta baş verdi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
