using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class TransferViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Transfer No")]
        public string TransferNumber { get; set; } = string.Empty;

        [Display(Name = "Mənbə Anbar (Çıxış)")]
        [Required(ErrorMessage = "{0} mütləq seçilməlidir.")]
        public int SourceWarehouseId { get; set; }

        [Display(Name = "Mənbə Anbar")]
        public string? SourceWarehouseName { get; set; }

        [Display(Name = "Hədəf Anbar (Giriş)")]
        [Required(ErrorMessage = "{0} mütləq seçilməlidir.")]
        public int DestinationWarehouseId { get; set; }

        [Display(Name = "Hədəf Anbar")]
        public string? DestinationWarehouseName { get; set; }

        [Display(Name = "Göndəriş Tarixi")]
        public DateTime SendDate { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "InTransit";

        public List<TransferItemViewModel> Items { get; set; } = new();
    }

    public class TransferItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Məhsul")]
        [Required(ErrorMessage = "{0} mütləq seçilməlidir.")]
        public int InventoryId { get; set; }

        [Display(Name = "Məhsul Adı")]
        public string? ProductName { get; set; }

        [Display(Name = "SKU")]
        public string? ProductSKU { get; set; }

        [Display(Name = "Ölçü Vahidi")]
        public string? MeasureUnitCode { get; set; }

        [Display(Name = "Transfer Miqdarı")]
        [Required(ErrorMessage = "{0} daxil edilməlidir.")]
        [Range(1, 1000000, ErrorMessage = "{0} 1 ilə {2} arasında olmalıdır.")]
        public int Quantity { get; set; } = 1;

        [Display(Name = "Mövcud Stok")]
        public int AvailableQuantity { get; set; }
    }
}
