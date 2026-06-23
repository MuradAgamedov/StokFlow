using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class PurchaseOrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Sifariş No")]
        public string OrderNumber { get; set; } = string.Empty;

        [Display(Name = "Təchizatçı Firma")]
        [Required(ErrorMessage = "{0} mütləq seçilməlidir.")]
        public int SupplierId { get; set; }

        [Display(Name = "Təchizatçı Firma")]
        public string? SupplierName { get; set; }

        [Display(Name = "Qəbul Anbarı")]
        [Required(ErrorMessage = "{0} mütləq seçilməlidir.")]
        public int WarehouseId { get; set; }

        [Display(Name = "Qəbul Anbarı")]
        public string? WarehouseName { get; set; }

        [Display(Name = "Sifariş Tarixi")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Yekun Məbləğ")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "PendingApproval";

        public List<PurchaseOrderItemViewModel> Items { get; set; } = new();
    }

    public class PurchaseOrderItemViewModel
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

        [Display(Name = "Miqdar")]
        [Required(ErrorMessage = "{0} daxil edilməlidir.")]
        [Range(1, 1000000, ErrorMessage = "{0} 1 ilə {2} arasında olmalıdır.")]
        public int Quantity { get; set; } = 1;

        [Display(Name = "Vahid Qiymət")]
        [Required(ErrorMessage = "{0} daxil edilməlidir.")]
        [Range(0.01, 10000000.0, ErrorMessage = "{0} 0.01-dən az ola bilməz.")]
        public decimal UnitPrice { get; set; }
    }
}
