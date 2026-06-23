using System;
using System.Collections.Generic;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalStockQuantity { get; set; }
        public int TotalProductCount { get; set; }
        public int CriticalItemsCount { get; set; }
        public int PendingOrdersCount { get; set; }
        public int ActiveTransfersCount { get; set; }

        public List<DashboardCriticalItem> CriticalItems { get; set; } = new();
        public List<DashboardWarehouseOccupancy> WarehouseOccupancies { get; set; } = new();
        public List<DashboardRecentItem> RecentItems { get; set; } = new();
    }

    public class DashboardCriticalItem
    {
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int CriticalLimit { get; set; }
        public string MeasureUnitCode { get; set; } = "ədəd";
        public bool IsAtCritical { get; set; }
    }

    public class DashboardWarehouseOccupancy
    {
        public string Name { get; set; } = string.Empty;
        public int TotalQuantity { get; set; }
        public int? Capacity { get; set; }
        public int Percentage { get; set; }
    }

    public class DashboardRecentItem
    {
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string MeasureUnitCode { get; set; } = "ədəd";
        public DateTime UpdatedAt { get; set; }
    }
}
