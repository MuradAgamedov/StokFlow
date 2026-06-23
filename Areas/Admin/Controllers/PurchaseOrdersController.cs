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
    public class PurchaseOrdersController : Controller
    {
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly ICompanyService _companyService;
        private readonly IWarehouseService _warehouseService;
        private readonly IInventoryService _inventoryService;

        public PurchaseOrdersController(
            IPurchaseOrderService purchaseOrderService,
            ICompanyService companyService,
            IWarehouseService warehouseService,
            IInventoryService inventoryService)
        {
            _purchaseOrderService = purchaseOrderService;
            _companyService = companyService;
            _warehouseService = warehouseService;
            _inventoryService = inventoryService;
        }

        public async Task<IActionResult> Index(string? search)
        {
            ViewData["CurrentFilter"] = search;
            IEnumerable<PurchaseOrder> orders;

            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.ToLower();
                orders = await _purchaseOrderService.LoadAllAsync(
                    po => po.OrderNumber.ToLower().Contains(lowerSearch) ||
                          (po.Supplier != null && po.Supplier.Name.ToLower().Contains(lowerSearch)) ||
                          (po.Warehouse != null && po.Warehouse.Name.ToLower().Contains(lowerSearch))
                );
            }
            else
            {
                orders = await _purchaseOrderService.LoadAllAsync();
            }

            var mappedOrders = orders.Select(po => new PurchaseOrderViewModel
            {
                Id = po.Id,
                OrderNumber = po.OrderNumber,
                SupplierId = po.SupplierId,
                SupplierName = po.Supplier?.Name ?? "Bilinmir",
                WarehouseId = po.WarehouseId,
                WarehouseName = po.Warehouse?.Name ?? "Bilinmir",
                OrderDate = po.OrderDate,
                TotalAmount = po.TotalAmount,
                Status = po.Status
            }).ToList();

            return View(mappedOrders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var po = await _purchaseOrderService.GetByIdAsync(id);
            if (po == null)
            {
                return NotFound();
            }

            var viewModel = new PurchaseOrderViewModel
            {
                Id = po.Id,
                OrderNumber = po.OrderNumber,
                SupplierId = po.SupplierId,
                SupplierName = po.Supplier?.Name ?? "Bilinmir",
                WarehouseId = po.WarehouseId,
                WarehouseName = po.Warehouse?.Name ?? "Bilinmir",
                OrderDate = po.OrderDate,
                TotalAmount = po.TotalAmount,
                Status = po.Status,
                Items = po.Items.Select(poi => new PurchaseOrderItemViewModel
                {
                    Id = poi.Id,
                    InventoryId = poi.InventoryId,
                    ProductName = poi.Inventory?.Name ?? "Bilinmir",
                    ProductSKU = poi.Inventory?.SKU ?? "—",
                    MeasureUnitCode = poi.Inventory?.MeasureUnit?.Code ?? "ədəd",
                    Quantity = poi.Quantity,
                    UnitPrice = poi.UnitPrice
                }).ToList()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var suppliers = await _companyService.LoadAllAsync(c => c.IsActive);
            var warehouses = await _warehouseService.LoadAllAsync(w => w.IsActive);
            var products = await _inventoryService.LoadAllAsync(i => i.IsActive);

            ViewBag.Suppliers = new SelectList(suppliers, "Id", "Name");
            ViewBag.Warehouses = new SelectList(warehouses, "Id", "Name");
            ViewBag.ProductsList = products.Select(p => new { Id = p.Id, Name = $"{p.Name} ({p.SKU})" }).ToList();

            return View(new PurchaseOrderViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseOrderViewModel model)
        {
            if (model.Items == null || !model.Items.Any())
            {
                ModelState.AddModelError(string.Empty, "Sifarişə ən azı bir məhsul daxil edilməlidir.");
            }

            if (!ModelState.IsValid)
            {
                var suppliers = await _companyService.LoadAllAsync(c => c.IsActive);
                var warehouses = await _warehouseService.LoadAllAsync(w => w.IsActive);
                var products = await _inventoryService.LoadAllAsync(i => i.IsActive);

                ViewBag.Suppliers = new SelectList(suppliers, "Id", "Name", model.SupplierId);
                ViewBag.Warehouses = new SelectList(warehouses, "Id", "Name", model.WarehouseId);
                ViewBag.ProductsList = products.Select(p => new { Id = p.Id, Name = $"{p.Name} ({p.SKU})" }).ToList();

                return View(model);
            }

            var currentYear = DateTime.UtcNow.Year;
            var allOrders = await _purchaseOrderService.LoadAllAsync();
            var count = allOrders.Count(po => po.OrderDate.Year == currentYear);
            var orderNum = $"PO-{currentYear}-{(count + 1).ToString("D4")}";

            decimal total = model.Items.Sum(item => item.Quantity * item.UnitPrice);

            var purchaseOrder = new PurchaseOrder
            {
                OrderNumber = orderNum,
                SupplierId = model.SupplierId,
                WarehouseId = model.WarehouseId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = total,
                Status = "PendingApproval",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Items = model.Items.Select(item => new PurchaseOrderItem
                {
                    InventoryId = item.InventoryId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList()
            };

            await _purchaseOrderService.AddAsync(purchaseOrder);
            TempData["SuccessMessage"] = $"Yeni satınalma sifarişi ({orderNum}) uğurla yaradıldı!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var result = await _purchaseOrderService.ApproveAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Satınalma sifarişi uğurla təsdiqləndi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Sifariş təsdiqlənərkən xəta baş verdi.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Complete(int id)
        {
            var result = await _purchaseOrderService.CompleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Məhsullar uğurla qəbul edildi və anbar stok miqdarları artırıldı!";
            }
            else
            {
                TempData["ErrorMessage"] = "Məhsulların qəbulu zamanı xəta baş verdi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
