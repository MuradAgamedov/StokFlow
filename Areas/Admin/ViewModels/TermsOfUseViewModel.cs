using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class TermsOfUseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Səhifə Başlığı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(150, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Title { get; set; }

        [Display(Name = "Alt Başlıq / Subtext")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(500, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Subtext { get; set; }

        [Display(Name = "Məzmun (HTML/Mətn)")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        public string BodyContent { get; set; }
    }
}
