using ModernWMC.Models.Abstract;

namespace ModernWMC.Models.Concrete
{
    public class TransferItem : IEntity
    {
        public int Id { get; set; }

        public int TransferId { get; set; }
        public Transfer? Transfer { get; set; }

        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

        public int Quantity { get; set; }
    }
}
