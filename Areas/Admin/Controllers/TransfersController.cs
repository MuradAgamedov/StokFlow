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
    public class TransfersController : Controller
    {
        private readonly ITransferService _transferService;
        private readonly IWarehouseService _warehouseService;
        private readonly IInventoryService _inventoryService;

        public TransfersController(
            ITransferService transferService,
            IWarehouseService warehouseService,
            IInventoryService inventoryService)
        {
            _transferService = transferService;
            _warehouseService = warehouseService;
            _inventoryService = inventoryService;
        }

        public async Task<IActionResult> Index(string? search)
        {
            ViewData["CurrentFilter"] = search;
            IEnumerable<Transfer> transfers;

            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.ToLower();
                transfers = await _transferService.LoadAllAsync(
                    t => t.TransferNumber.ToLower().Contains(lowerSearch) ||
                          (t.SourceWarehouse != null && t.SourceWarehouse.Name.ToLower().Contains(lowerSearch)) ||
                          (t.DestinationWarehouse != null && t.DestinationWarehouse.Name.ToLower().Contains(lowerSearch))
                );
            }
            else
            {
                transfers = await _transferService.LoadAllAsync();
            }

            var mappedTransfers = transfers.Select(t => new TransferViewModel
            {
                Id = t.Id,
                TransferNumber = t.TransferNumber,
                SourceWarehouseId = t.SourceWarehouseId,
                SourceWarehouseName = t.SourceWarehouse?.Name ?? "Bilinmir",
                DestinationWarehouseId = t.DestinationWarehouseId,
                DestinationWarehouseName = t.DestinationWarehouse?.Name ?? "Bilinmir",
                SendDate = t.SendDate,
                Status = t.Status
            }).ToList();

            return View(mappedTransfers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var transfer = await _transferService.GetByIdAsync(id);
            if (transfer == null)
            {
                return NotFound();
            }

            var viewModel = new TransferViewModel
            {
                Id = transfer.Id,
                TransferNumber = transfer.TransferNumber,
                SourceWarehouseId = transfer.SourceWarehouseId,
                SourceWarehouseName = transfer.SourceWarehouse?.Name ?? "Bilinmir",
                DestinationWarehouseId = transfer.DestinationWarehouseId,
                DestinationWarehouseName = transfer.DestinationWarehouse?.Name ?? "Bilinmir",
                SendDate = transfer.SendDate,
                Status = transfer.Status,
                Items = transfer.Items.Select(ti => new TransferItemViewModel
                {
                    Id = ti.Id,
                    InventoryId = ti.InventoryId,
                    ProductName = ti.Inventory?.Name ?? "Bilinmir",
                    ProductSKU = ti.Inventory?.SKU ?? "—",
                    MeasureUnitCode = ti.Inventory?.MeasureUnit?.Code ?? "ədəd",
                    Quantity = ti.Quantity
                }).ToList()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var warehouses = await _warehouseService.LoadAllAsync(w => w.IsActive);
            ViewBag.Warehouses = new SelectList(warehouses, "Id", "Name");
            return View(new TransferViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransferViewModel model)
        {
            if (model.Items == null || !model.Items.Any())
            {
                ModelState.AddModelError(string.Empty, "Transferə ən azı bir məhsul daxil edilməlidir.");
            }
            else if (model.SourceWarehouseId == model.DestinationWarehouseId)
            {
                ModelState.AddModelError(string.Empty, "Mənbə və Hədəf anbarlar eyni ola bilməz.");
            }

            if (!ModelState.IsValid)
            {
                var warehouses = await _warehouseService.LoadAllAsync(w => w.IsActive);
                ViewBag.Warehouses = new SelectList(warehouses, "Id", "Name", model.SourceWarehouseId);

                // Load source warehouse inventories
                var inventories = await _inventoryService.LoadAllAsync(i => i.WarehouseId == model.SourceWarehouseId && i.IsActive && i.Quantity > 0);
                ViewBag.SourceInventories = inventories.Select(i => new {
                    Id = i.Id,
                    Name = $"{i.Name} ({i.SKU})",
                    AvailableQuantity = i.Quantity,
                    MeasureUnitCode = i.MeasureUnit?.Code ?? "ədəd"
                }).ToList();

                return View(model);
            }

            try
            {
                var currentYear = DateTime.UtcNow.Year;
                var allTransfers = await _transferService.LoadAllAsync();
                var count = allTransfers.Count(t => t.SendDate.Year == currentYear);
                var transferNum = $"TR-{currentYear}-{(count + 1).ToString("D4")}";

                var transfer = new Transfer
                {
                    TransferNumber = transferNum,
                    SourceWarehouseId = model.SourceWarehouseId,
                    DestinationWarehouseId = model.DestinationWarehouseId,
                    SendDate = DateTime.UtcNow,
                    Status = "InTransit",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Items = model.Items.Select(item => new TransferItem
                    {
                        InventoryId = item.InventoryId,
                        Quantity = item.Quantity
                    }).ToList()
                };

                await _transferService.AddAndShipAsync(transfer);
                TempData["SuccessMessage"] = $"Yeni transfer ({transferNum}) uğurla yaradıldı və yola salındı!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                var warehouses = await _warehouseService.LoadAllAsync(w => w.IsActive);
                ViewBag.Warehouses = new SelectList(warehouses, "Id", "Name", model.SourceWarehouseId);

                var inventories = await _inventoryService.LoadAllAsync(i => i.WarehouseId == model.SourceWarehouseId && i.IsActive && i.Quantity > 0);
                ViewBag.SourceInventories = inventories.Select(i => new {
                    Id = i.Id,
                    Name = $"{i.Name} ({i.SKU})",
                    AvailableQuantity = i.Quantity,
                    MeasureUnitCode = i.MeasureUnit?.Code ?? "ədəd"
                }).ToList();

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Complete(int id)
        {
            var result = await _transferService.CompleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Məhsullar hədəf anbarına uğurla qəbul edildi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Transfer tamamlanarkən xəta baş verdi.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _transferService.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Transfer uğurla silindi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Transfer silinərkən xəta baş verdi.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetInventoriesByWarehouse(int warehouseId)
        {
            var inventories = await _inventoryService.LoadAllAsync(i => i.WarehouseId == warehouseId && i.IsActive && i.Quantity > 0);
            var result = inventories.Select(i => new {
                id = i.Id,
                name = $"{i.Name} ({i.SKU})",
                sku = i.SKU,
                availableQuantity = i.Quantity,
                measureUnitCode = i.MeasureUnit?.Code ?? "ədəd"
            }).ToList();
            return Json(result);
        }
    }
}
