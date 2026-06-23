using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class StatisticsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Dəyər (Value)")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(50, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Title { get; set; }

        [Display(Name = "Açıqlama (Label)")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(150, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Description { get; set; }

        [Display(Name = "Sıralama")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} ən az {1} olmalıdır.")]
        public int Order { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
