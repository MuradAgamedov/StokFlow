using ModernWMC.Models.Abstract;

namespace ModernWMC.Models.Concrete
{
    public class PurchaseOrderItem : IEntity
    {
        public int Id { get; set; }

        public int PurchaseOrderId { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }

        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
