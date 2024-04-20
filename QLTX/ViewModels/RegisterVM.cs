using System.ComponentModel.DataAnnotations;

namespace QLTX.ViewModels;

public class RegisterVM
{
    
     
    [Required]
    public string? FullName { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
    public string? ConfirmPassword { get; set; }
}