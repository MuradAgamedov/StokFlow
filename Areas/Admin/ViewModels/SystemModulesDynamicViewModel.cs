using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class SystemModulesDynamicViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Kartın Başlığı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(150, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Title { get; set; }

        [Display(Name = "İkon Sinifi")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string IconClass { get; set; }

        [Display(Name = "Keçid Linki (URL)")]
        [StringLength(200, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Url { get; set; }

        [Display(Name = "Açıqlama / Təsvir")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(500, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Description { get; set; }

        [Display(Name = "Sıralama")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        public int Order { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
