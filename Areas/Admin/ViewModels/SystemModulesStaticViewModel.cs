using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class SystemModulesStaticViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Bölmə Etiketi (Tag)")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string SectionTag { get; set; }

        [Display(Name = "Əsas Başlıq")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(200, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string SectionTitle { get; set; }

        [Display(Name = "Açıqlama Mətni")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(1000, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string SectionDesc { get; set; }
    }
}
