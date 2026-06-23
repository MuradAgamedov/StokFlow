using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernWMC.Services.Abstract;
using ModernWMC.Areas.Admin.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ModernWMC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly IWarehouseService _warehouseService;
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly ITransferService _transferService;

        public DashboardController(
            IInventoryService inventoryService,
            IWarehouseService warehouseService,
            IPurchaseOrderService purchaseOrderService,
            ITransferService transferService)
        {
            _inventoryService = inventoryService;
            _warehouseService = warehouseService;
            _purchaseOrderService = purchaseOrderService;
            _transferService = transferService;
        }

        public async Task<IActionResult> Index()
        {
            var allInventory = (await _inventoryService.LoadAllAsync(i => i.IsActive)).ToList();
            var allWarehouses = (await _warehouseService.LoadAllAsync(w => w.IsActive)).ToList();
            var pendingOrders = await _purchaseOrderService.LoadAllAsync(
                po => po.Status == "PendingApproval" || po.Status == "Ordered");
            var activeTransfers = await _transferService.LoadAllAsync(
                t => t.Status == "InTransit" && t.IsActive);

            var criticalItems = allInventory
                .Where(i => i.Quantity <= i.CriticalLimit * 1.5)
                .OrderBy(i => i.Quantity)
                .Take(5)
                .Select(i => new DashboardCriticalItem
                {
                    Name = i.Name,
                    SKU = i.SKU,
                    Quantity = i.Quantity,
                    CriticalLimit = i.CriticalLimit,
                    MeasureUnitCode = i.MeasureUnit?.Code ?? "ədəd",
                    IsAtCritical = i.Quantity <= i.CriticalLimit
                })
                .ToList();

            var warehouseOccupancies = allWarehouses.Select(w =>
            {
                var totalQty = allInventory.Where(i => i.WarehouseId == w.Id).Sum(i => i.Quantity);
                int pct = w.Capacity.HasValue && w.Capacity.Value > 0
                    ? Math.Min((int)Math.Round(totalQty * 100.0 / w.Capacity.Value), 100)
                    : w.OccupancyPercentage;
                return new DashboardWarehouseOccupancy
                {
                    Name = w.Name,
                    TotalQuantity = totalQty,
                    Capacity = w.Capacity,
                    Percentage = pct
                };
            }).ToList();

            var recentItems = allInventory
                .OrderByDescending(i => i.UpdatedAt)
                .Take(6)
                .Select(i => new DashboardRecentItem
                {
                    Name = i.Name,
                    SKU = i.SKU,
                    WarehouseName = i.Warehouse?.Name ?? "—",
                    Quantity = i.Quantity,
                    MeasureUnitCode = i.MeasureUnit?.Code ?? "ədəd",
                    UpdatedAt = i.UpdatedAt
                })
                .ToList();

            var vm = new DashboardViewModel
            {
                TotalStockQuantity = allInventory.Sum(i => i.Quantity),
                TotalProductCount = allInventory.Count,
                CriticalItemsCount = allInventory.Count(i => i.Quantity <= i.CriticalLimit),
                PendingOrdersCount = pendingOrders.Count(),
                ActiveTransfersCount = activeTransfers.Count(),
                CriticalItems = criticalItems,
                WarehouseOccupancies = warehouseOccupancies,
                RecentItems = recentItems
            };

            return View(vm);
        }
    }
}
