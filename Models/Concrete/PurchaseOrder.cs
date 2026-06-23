using ModernWMC.Models.Abstract;
using System;
using System.Collections.Generic;

namespace ModernWMC.Models.Concrete
{
    public class PurchaseOrder : IEntity
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;

        public int SupplierId { get; set; }
        public Company? Supplier { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "PendingApproval"; // PendingApproval, Ordered, Completed

        public List<PurchaseOrderItem> Items { get; set; } = new();

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
