using System.ComponentModel.DataAnnotations;

namespace ModernWMC.Areas.Admin.ViewModels;

public class LoginViewModel
{
	[Required]
	[EmailAddress]
	[Display(Name = "E-poçt Ünvanı")]
	public string Email { get; set; } = string.Empty;

	[Required]
	[DataType(DataType.Password)]
	[Display(Name = "Şifrə")]
	public string Password { get; set; } = string.Empty;

	[Display(Name = "Məni yadda saxla")]
	public bool RememberMe { get; set; }
}