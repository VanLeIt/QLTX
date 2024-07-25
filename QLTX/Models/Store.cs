using System.ComponentModel.DataAnnotations;

namespace QLTX.Models;

public class Store
{

    public int Id { get; set; }

    [StringLength(255,ErrorMessage = "Tên cửa hàng phải có độ dài từ {2} đến {1} ký tự.", MinimumLength = 2)]
    public string? Name { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    [Display(Name = "Số điện thoại")]
    [StringLength(15, ErrorMessage = "Số điện thoại phải có độ dài tối đa là {1} ký tự.")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Số điện thoại không hợp lệ")]
    public string? PhoneNumber { get; set; }

    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    [Display(Name = "Email")]
    [StringLength(50, ErrorMessage = "Email phải có độ dài tối đa là {1} ký tự.")]
    public string? Email { get; set; }

    [StringLength(255, ErrorMessage = "Địa chỉ phải có độ dài từ {2} đến {1} ký tự.", MinimumLength = 2)]
    public string? Address { get; set; }

/*    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Giá trị không hợp lệ. Vui lòng nhập số.")]
    public double? PriceHour { get; set; }

    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Giá trị không hợp lệ. Vui lòng nhập số.")]
    public double? PriceDay { get; set; }

    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Giá trị không hợp lệ. Vui lòng nhập số.")]
    public double? PriceWeek { get; set; }*/
    //public decimal? Tolls { get; set; }

}
