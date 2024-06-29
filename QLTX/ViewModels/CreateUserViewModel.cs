using System.ComponentModel.DataAnnotations;
using QLTX.Models;

namespace QLTX.ViewModels;

public class CreateUserViewModel
{
    public string Id { get; set; }

	[Required(ErrorMessage = "Tên đầy đủ là bắt buộc")]
	[StringLength(100, ErrorMessage = "Tên đầy đủ phải có độ dài từ {2} đến {1} ký tự.", MinimumLength = 2)]
	[Display(Name = "Tên đầy đủ")]
    public string FullName { get; set; }
     
    [Display(Name = "Địa chỉ")]
	[StringLength(255, ErrorMessage = "Địa chỉ phải có độ dài tối đa là {1} ký tự.")] 
	public string? Address { get; set; }

	[Required(ErrorMessage = "Email là bắt buộc")]
	[EmailAddress(ErrorMessage = "Email không hợp lệ")]
	[Display(Name = "Email")]
	[StringLength(50, ErrorMessage = "Email phải có độ dài tối đa là {1} ký tự.")]
	public string Email { get; set; }
     
	[Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
	[Display(Name = "Số điện thoại")]
	[StringLength(15, ErrorMessage = "Số điện thoại phải có độ dài tối đa là {1} ký tự.")]
	[RegularExpression(@"^\d+$", ErrorMessage = "Số điện thoại không hợp lệ")]
	public string? PhoneNumber { get; set; }

	[Required(ErrorMessage = "Mật khẩu là bắt buộc")]
	[DataType(DataType.Password)]
	[Display(Name = "Mật khẩu")]
	[StringLength(100, ErrorMessage = "Mật khẩu phải có độ dài từ {2} đến {1} ký tự.", MinimumLength = 6)]
	public string Password { get; set; }

	[Required(ErrorMessage = "Xác nhận mật khẩu là bắt buộc")]
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
