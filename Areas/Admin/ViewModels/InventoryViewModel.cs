using System;
using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class InventoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Məhsul Adı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(150, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "SKU (Kod)")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(50, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string SKU { get; set; } = string.Empty;

        [Display(Name = "Kateqoriya")]
        [Required(ErrorMessage = "{0} mütləq seçilməlidir.")]
        public int CategoryId { get; set; }

        [Display(Name = "Kateqoriya")]
        public string? CategoryName { get; set; }

        [Display(Name = "Ölçü Vahidi")]
        [Required(ErrorMessage = "{0} mütləq seçilməlidir.")]
        public int MeasureUnitId { get; set; }

        [Display(Name = "Ölçü Vahidi")]
        public string? MeasureUnitCode { get; set; }

        [Display(Name = "Yerləşdiriləcək Anbar")]
        [Required(ErrorMessage = "{0} mütləq seçilməlidir.")]
        public int WarehouseId { get; set; }

        [Display(Name = "Anbar")]
        public string? WarehouseName { get; set; }

        [Display(Name = "Rəf / Zona (Lokasiya)")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string? ShelfLocation { get; set; }

        [Display(Name = "İlkin Stok Miqdarı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} 0-dan kiçik ola bilməz.")]
        public int Quantity { get; set; } = 0;

        [Display(Name = "Kritik Stok Həddi (Limit)")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} 1-dən kiçik ola bilməz.")]
        public int CriticalLimit { get; set; } = 5;

        [Display(Name = "Partiya (Lot No)")]
        [StringLength(50, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string? LotNo { get; set; }

        [Display(Name = "Son İstifadə Tarixi")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; } = true;
    }
}
