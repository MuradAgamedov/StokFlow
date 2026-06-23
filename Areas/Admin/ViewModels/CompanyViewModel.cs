using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Şirkət Adı")]
        [Required(ErrorMessage = "{0} mütləq daxil edilməlidir.")]
        [StringLength(150, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "VÖEN")]
        [StringLength(50, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string? Voen { get; set; }

        [Display(Name = "Məsul Şəxs")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string? ContactPerson { get; set; }

        [Display(Name = "E-poçt")]
        [EmailAddress(ErrorMessage = "Düzgün e-poçt ünvanı daxil edin.")]
        [StringLength(100, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string? Email { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(50, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string? Phone { get; set; }

        [Display(Name = "Ünvan")]
        [StringLength(500, ErrorMessage = "{0} ən çox {1} simvoldan ibarət ola bilər.")]
        public string? Address { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; } = true;
    }
}
