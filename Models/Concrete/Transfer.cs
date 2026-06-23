using ModernWMC.Models.Abstract;
using System;
using System.Collections.Generic;

namespace ModernWMC.Models.Concrete
{
    public class Transfer : IEntity
    {
        public int Id { get; set; }
        public string TransferNumber { get; set; } = string.Empty;

        public int SourceWarehouseId { get; set; }
        public Warehouse? SourceWarehouse { get; set; }

        public int DestinationWarehouseId { get; set; }
        public Warehouse? DestinationWarehouse { get; set; }

        public DateTime SendDate { get; set; }
        public string Status { get; set; } = "InTransit"; // InTransit, Completed

        public List<TransferItem> Items { get; set; } = new();

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
