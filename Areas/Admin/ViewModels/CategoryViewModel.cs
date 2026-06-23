using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Kateqoriya Adı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Name { get; set; }

        [Display(Name = "Kateqoriya Kodu")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(50, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string CategoryCode { get; set; }

        [Display(Name = "Açıqlama")]
        [StringLength(500, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string? Description { get; set; }
    }
}
