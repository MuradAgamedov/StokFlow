using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class CtaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Banner Başlığı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(150, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Title { get; set; }

        [Display(Name = "Açıqlama Mətni")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(500, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Description { get; set; }

        [Display(Name = "Düymə Mətni")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(50, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string ButtonText { get; set; }

        [Display(Name = "Düymə Keçidi (URL)")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(200, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Url { get; set; }
    }
}
