using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class HeroViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Etiket (Label)")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Label { get; set; }

        [Display(Name = "Sol Məzmun Başlığı (CKEditor Left Data)")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(500, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Title { get; set; }

        [Display(Name = "Alt Açıqlama (Subdescription)")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(1000, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string SubText { get; set; }

        [Display(Name = "Şəkil URL")]
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
    }
}
