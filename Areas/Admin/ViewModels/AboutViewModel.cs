using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class AboutViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Biz Kimik Başlığı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string WhoAreWeTitle { get; set; }

        [Display(Name = "Biz Kimik Açıqlaması")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(1000, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string WhoAreWeDescription { get; set; }

        [Display(Name = "Missiyamız Başlığı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string OurMissionTitle { get; set; }

        [Display(Name = "Missiyamız Açıqlaması")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(2000, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string OurMissionDescription { get; set; }

        [Display(Name = "Siyahı Başlığı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string WhoAreWeListTitle { get; set; }

        [Display(Name = "Məntəqə 1 Başlığı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string WhoAreWeListFirstTextTitle { get; set; }

        [Display(Name = "Məntəqə 1 Açıqlaması")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(500, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string WhoAreWeListFirstText { get; set; }

        [Display(Name = "Məntəqə 2 Başlığı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string WhoAreWeListSecondTextTitle { get; set; }

        [Display(Name = "Məntəqə 2 Açıqlaması")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(500, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string WhoAreWeListSecondText { get; set; }

        [Display(Name = "Məntəqə 3 Başlığı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string WhoAreWeListThirdTextTitle { get; set; }

        [Display(Name = "Məntəqə 3 Açıqlaması")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(500, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string WhoAreWeListThirdText { get; set; }
    }
}
