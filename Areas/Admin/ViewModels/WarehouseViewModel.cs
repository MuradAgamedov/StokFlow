using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Anbar Adı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Anbar Kodu")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(50, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Code { get; set; } = string.Empty;

        [Display(Name = "Məsul Şəxs")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string? ContactPerson { get; set; }

        [Display(Name = "Ümumi Həcm Tutumu (m³)")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} minimum 1 ola bilər.")]
        public int? Capacity { get; set; }

        [Display(Name = "Fiziki Ünvan")]
        [StringLength(500, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string? Address { get; set; }

        [Display(Name = "Doluluq Faizi")]
        public int OccupancyPercentage { get; set; } = 0;

        [Display(Name = "Status")]
        public bool IsActive { get; set; } = true;
    }
}
