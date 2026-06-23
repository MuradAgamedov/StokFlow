using System.ComponentModel.DataAnnotations;

namespace ModernWMC.ViewModels
{
    public class ContactMessageViewModel
    {
        [Display(Name = "Tam adınız")]
        [Required(ErrorMessage = "Ad mütləq daxil edilməlidir")]
        [MinLength(5, ErrorMessage = "Ad soyad minimum 5 simvol olmalıdır")]
        public string FullName { get; set; }
        [Display(Name = "Elektron poçtunuz")]
        [Required(ErrorMessage = "Elektron poçt mütləq daxil edilməlidir")]
        [EmailAddress(ErrorMessage = "Düzgün formatda elektrton poçt daxil edilməlidir")]

        public string Email { get; set; }
        [Display(Name = "Mövzu")]
        [Required(ErrorMessage = "Mövzu mütləq daxil edilməlidir")]
        public string Subject { get; set; }
        [Display(Name = "Mesajınız")]
        [Required(ErrorMessage = "Mesajınız mütləq daxil edilməlidir")]
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
