using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class MeasureUnitViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ölçü Vahidi Adı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Qısa Kod")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(20, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Code { get; set; } = string.Empty;

        [Display(Name = "Açıqlama")]
        [StringLength(300, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string? Description { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; } = true;
    }
}
