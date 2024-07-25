using System.ComponentModel.DataAnnotations;

namespace QLTX.Models;

public class Customer
{
	[Key]
	public int Id { get; set; }

    [Required(ErrorMessage = "Tên đầy đủ là bắt buộc")]
    [StringLength(100, ErrorMessage = "Tên đầy đủ phải có độ dài từ {2} đến {1} ký tự.", MinimumLength = 2)]
    public string Name { get; set; }
	public TypeDocument TypeDocument { get; set; }
	public string IdDocument { get; set; }

    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
    [Display(Name = "Số điện thoại")]
    [StringLength(15, ErrorMessage = "Số điện thoại phải có độ dài tối đa là {1} ký tự.")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Số điện thoại không hợp lệ")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Email là bắt buộc")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    [Display(Name = "Email")]
    [StringLength(50, ErrorMessage = "Email phải có độ dài tối đa là {1} ký tự.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
    [StringLength(255, ErrorMessage = "Địa chỉ phải có độ dài từ {2} đến {1} ký tự.", MinimumLength = 2)]
    public string Address { get; set; }

    [StringLength(100)]
    public string CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }

    [StringLength(100)]
    public string? UpdatedBy { get; set; }
	public DateTime? UpdationTime { get; set; }
    public bool IsDelete { get; set; }
}

public enum TypeDocument
{
	[Display(Name = "Bằng lái xe")]
	Bang_Lai_Xe,
	[Display(Name = "Căn cước công dân")]
	CCCD,
	[Display(Name = "Hộ chiếu")]
	Ho_Chieu,

}
