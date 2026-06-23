using ModernWMC.Models.Abstract;
using System;

namespace ModernWMC.Models.Concrete
{
    public class Inventory : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int? MeasureUnitId { get; set; }
        public MeasureUnit? MeasureUnit { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public string? LotNo { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? ShelfLocation { get; set; }

        public int Quantity { get; set; } = 0;
        public int CriticalLimit { get; set; } = 5;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
