using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class FAQViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Sual")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(250, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Question { get; set; }

        [Display(Name = "Cavab")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        public string Answer { get; set; }

        [Display(Name = "Sıralama")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} ən az {1} olmalıdır.")]
        public int Order { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
