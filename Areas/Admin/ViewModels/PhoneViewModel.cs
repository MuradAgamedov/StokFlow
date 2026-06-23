using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class PhoneViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Etiket / Növ")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Title { get; set; }

        [Display(Name = "Telefon Nömrəsi")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(50, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Label { get; set; }

        [Display(Name = "Sıralama")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} ən az {1} olmalıdır.")]
        public int Order { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
