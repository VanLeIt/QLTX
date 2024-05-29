using System.ComponentModel.DataAnnotations;
using QLTX.Models;

namespace QLTX.ViewModels;

public class CreateUserViewModel
{
      public string Id { get; set; }
    [Required]
    [Display(Name = "Tên đầy đủ")]
    public string FullName { get; set; }

 
    [Display(Name = "Địa chỉ")]
    public string Address { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    
    [Phone]
    [Display(Name = "Số điện thoại")]
    public string PhoneNumber { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Mật khẩu")]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
    [Display(Name = "Xác nhận mật khẩu")]
    public string ConfirmPassword { get; set; }

    public string? CreatedBy { get; set; }
    public DateTime CreationTime { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdationTime { get; set; }
    public ICollection<Rental> Rentals { get; set; }
     
    [Display(Name = "Vai trò")]
    public List<string>? RoleIds { get; set; }
}
