using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly ICategoryService _categoryService;
        private readonly IWarehouseService _warehouseService;
        private readonly IMeasureUnitService _measureUnitService;

        public InventoryController(
            IInventoryService inventoryService,
            ICategoryService categoryService,
            IWarehouseService warehouseService,
            IMeasureUnitService measureUnitService)
        {
            _inventoryService = inventoryService;
            _categoryService = categoryService;
            _warehouseService = warehouseService;
            _measureUnitService = measureUnitService;
        }

        public async Task<IActionResult> Index(string? search, int? categoryId)
        {
            ViewData["CurrentFilter"] = search;
            ViewData["CurrentCategoryId"] = categoryId;

            var categories = await _categoryService.LoadAllAsync();
            ViewBag.CategoriesList = new SelectList(categories, "Id", "Name", categoryId);

            IEnumerable<Inventory> items;

            if (!string.IsNullOrWhiteSpace(search) || categoryId.HasValue)
            {
                var lowerSearch = search?.ToLower() ?? string.Empty;
                items = await _inventoryService.LoadAllAsync(
                    e => (string.IsNullOrWhiteSpace(search) || 
                          e.Name.ToLower().Contains(lowerSearch) || 
                          e.SKU.ToLower().Contains(lowerSearch) ||
                          (e.LotNo != null && e.LotNo.ToLower().Contains(lowerSearch)) ||
                          (e.ShelfLocation != null && e.ShelfLocation.ToLower().Contains(lowerSearch))) &&
                         (!categoryId.HasValue || e.CategoryId == categoryId.Value)
                );
            }
            else
            {
                items = await _inventoryService.LoadAllAsync();
            }

            var mappedItems = items.Select(i => new InventoryViewModel
            {
                Id = i.Id,
                Name = i.Name,
                SKU = i.SKU,
                CategoryId = i.CategoryId,
                CategoryName = i.Category?.Name ?? "Seçilməyib",
                MeasureUnitId = i.MeasureUnitId ?? 0,
                MeasureUnitCode = i.MeasureUnit?.Code ?? "ədəd",
                WarehouseId = i.WarehouseId,
                WarehouseName = i.Warehouse?.Name ?? "Seçilməyib",
                ShelfLocation = i.ShelfLocation,
                Quantity = i.Quantity,
                CriticalLimit = i.CriticalLimit,
                LotNo = i.LotNo,
                ExpirationDate = i.ExpirationDate,
                IsActive = i.IsActive
            }).ToList();

            return View(mappedItems);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.LoadAllAsync();
            var warehouses = await _warehouseService.LoadAllAsync();
            var measureUnits = await _measureUnitService.LoadAllAsync();

            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.Warehouses = new SelectList(warehouses, "Id", "Name");
            ViewBag.MeasureUnits = new SelectList(measureUnits, "Id", "Name");

            return View(new InventoryViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(InventoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.LoadAllAsync();
                var warehouses = await _warehouseService.LoadAllAsync();
                var measureUnits = await _measureUnitService.LoadAllAsync();

                ViewBag.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
                ViewBag.Warehouses = new SelectList(warehouses, "Id", "Name", model.WarehouseId);
                ViewBag.MeasureUnits = new SelectList(measureUnits, "Id", "Name", model.MeasureUnitId);

                return View(model);
            }

            var inventory = new Inventory
            {
                Name = model.Name,
                SKU = model.SKU,
                CategoryId = model.CategoryId,
                MeasureUnitId = model.MeasureUnitId,
                WarehouseId = model.WarehouseId,
                ShelfLocation = model.ShelfLocation,
                Quantity = model.Quantity,
                CriticalLimit = model.CriticalLimit,
                LotNo = model.LotNo,
                ExpirationDate = model.ExpirationDate,
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _inventoryService.AddAsync(inventory);
            TempData["SuccessMessage"] = "Məhsul və stok qeydi uğurla əlavə edildi!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _inventoryService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var categories = await _categoryService.LoadAllAsync();
            var warehouses = await _warehouseService.LoadAllAsync();
            var measureUnits = await _measureUnitService.LoadAllAsync();

            ViewBag.Categories = new SelectList(categories, "Id", "Name", item.CategoryId);
            ViewBag.Warehouses = new SelectList(warehouses, "Id", "Name", item.WarehouseId);
            ViewBag.MeasureUnits = new SelectList(measureUnits, "Id", "Name", item.MeasureUnitId);

            var viewModel = new InventoryViewModel
            {
                Id = item.Id,
                Name = item.Name,
                SKU = item.SKU,
                CategoryId = item.CategoryId,
                MeasureUnitId = item.MeasureUnitId ?? 0,
                WarehouseId = item.WarehouseId,
                ShelfLocation = item.ShelfLocation,
                Quantity = item.Quantity,
                CriticalLimit = item.CriticalLimit,
                LotNo = item.LotNo,
                ExpirationDate = item.ExpirationDate,
                IsActive = item.IsActive
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InventoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.LoadAllAsync();
                var warehouses = await _warehouseService.LoadAllAsync();
                var measureUnits = await _measureUnitService.LoadAllAsync();

                ViewBag.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
                ViewBag.Warehouses = new SelectList(warehouses, "Id", "Name", model.WarehouseId);
                ViewBag.MeasureUnits = new SelectList(measureUnits, "Id", "Name", model.MeasureUnitId);

                return View(model);
            }

            var item = await _inventoryService.GetByIdAsync(model.Id);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = model.Name;
            item.SKU = model.SKU;
            item.CategoryId = model.CategoryId;
            item.MeasureUnitId = model.MeasureUnitId;
            item.WarehouseId = model.WarehouseId;
            item.ShelfLocation = model.ShelfLocation;
            item.Quantity = model.Quantity;
            item.CriticalLimit = model.CriticalLimit;
            item.LotNo = model.LotNo;
            item.ExpirationDate = model.ExpirationDate;
            item.IsActive = model.IsActive;
            item.UpdatedAt = DateTime.UtcNow;

            await _inventoryService.UpdateAsync(item);
            TempData["SuccessMessage"] = "Məhsul və stok məlumatları uğurla yeniləndi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _inventoryService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Məhsul stok qeydi uğurla silindi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Silinmə zamanı xəta baş verdi.";
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> VisualMap(int? warehouseId)
        {
            var warehouses = await _warehouseService.LoadAllAsync(w => w.IsActive);
            int selectedWarehouseId = warehouseId ?? warehouses.FirstOrDefault()?.Id ?? 0;

            ViewBag.WarehousesList = new SelectList(warehouses, "Id", "Name", selectedWarehouseId);
            ViewBag.SelectedWarehouseId = selectedWarehouseId;
            ViewBag.SelectedWarehouseName = warehouses.FirstOrDefault(w => w.Id == selectedWarehouseId)?.Name ?? "Seçilməyib";

            var items = await _inventoryService.LoadAllAsync(i => i.WarehouseId == selectedWarehouseId && i.IsActive);

            var mappedItems = items.Select(i => new InventoryViewModel
            {
                Id = i.Id,
                Name = i.Name,
                SKU = i.SKU,
                CategoryId = i.CategoryId,
                CategoryName = i.Category?.Name ?? "Seçilməyib",
                MeasureUnitId = i.MeasureUnitId ?? 0,
                MeasureUnitCode = i.MeasureUnit?.Code ?? "ədəd",
                WarehouseId = i.WarehouseId,
                WarehouseName = i.Warehouse?.Name ?? "Seçilməyib",
                ShelfLocation = i.ShelfLocation,
                Quantity = i.Quantity,
                CriticalLimit = i.CriticalLimit,
                LotNo = i.LotNo,
                ExpirationDate = i.ExpirationDate,
                IsActive = i.IsActive
            }).ToList();

            return View(mappedItems);
        }

        public async Task<IActionResult> AdjustStock()
        {
            var inventories = await _inventoryService.LoadAllAsync(i => i.IsActive);
            var uniqueProducts = inventories
                .GroupBy(i => i.SKU)
                .Select(g => g.First())
                .Select(i => new { SKU = i.SKU, Name = $"{i.Name} (SKU: {i.SKU})" })
                .ToList();

            var warehouses = await _warehouseService.LoadAllAsync(w => w.IsActive);

            ViewBag.Products = new SelectList(uniqueProducts, "SKU", "Name");
            ViewBag.Warehouses = new SelectList(warehouses, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdjustStock(string productId, int warehouseId, string type, int quantity, string reason)
        {
            if (string.IsNullOrWhiteSpace(productId) || quantity <= 0)
            {
                TempData["ErrorMessage"] = "Düzgün məhsul və miqdar daxil edin.";
                return RedirectToAction(nameof(Index));
            }

            Inventory? inventory = null;
            string sku = productId;

            if (int.TryParse(productId, out int invId))
            {
                var tempInv = await _inventoryService.GetByIdAsync(invId);
                if (tempInv != null)
                {
                    sku = tempInv.SKU;
                }
            }

            inventory = (await _inventoryService.LoadAllAsync(i => i.SKU == sku && i.WarehouseId == warehouseId && i.IsActive)).FirstOrDefault();

            if (inventory == null)
            {
                if (type == "Subtract")
                {
                    TempData["ErrorMessage"] = "Seçilmiş anbarda bu məhsuldan mövcud deyil, çıxış etmək mümkün deyil.";
                    return RedirectToAction(nameof(Index));
                }
                else // Add
                {
                    var template = (await _inventoryService.LoadAllAsync(i => i.SKU == sku && i.IsActive)).FirstOrDefault();
                    if (template == null)
                    {
                        TempData["ErrorMessage"] = "Məhsul sistemdə tapılmadı.";
                        return RedirectToAction(nameof(Index));
                    }

                    inventory = new Inventory
                    {
                        Name = template.Name,
                        SKU = template.SKU,
                        CategoryId = template.CategoryId,
                        MeasureUnitId = template.MeasureUnitId,
                        WarehouseId = warehouseId,
                        ShelfLocation = "Təyin olunmayıb",
                        Quantity = quantity,
                        CriticalLimit = template.CriticalLimit,
                        LotNo = "ADJ-" + DateTime.UtcNow.ToString("yyyyMMdd"),
                        ExpirationDate = null,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    await _inventoryService.AddAsync(inventory);
                }
            }
            else
            {
                if (type == "Subtract")
                {
                    if (inventory.Quantity < quantity)
                    {
                        TempData["ErrorMessage"] = $"Kifayət qədər stok yoxdur. Mövcud stok: {inventory.Quantity} {inventory.MeasureUnit?.Code ?? "ədəd"}";
                        return RedirectToAction(nameof(Index));
                    }
                    inventory.Quantity -= quantity;
                }
                else // Add
                {
                    inventory.Quantity += quantity;
                }
                inventory.UpdatedAt = DateTime.UtcNow;
                await _inventoryService.UpdateAsync(inventory);
            }

            TempData["SuccessMessage"] = $"Stok düzəlişi ({reason}) uğurla tətbiq edildi!";
            return RedirectToAction(nameof(Index));
        }
    }
}
