using System.ComponentModel.DataAnnotations;

namespace QLTX.Models;

public class TypeMotorbike
{
	[Key]
	public int Id { get; set; }

	[Required(ErrorMessage = "Tên loại xe là bắt buộc")]
	[StringLength(255, ErrorMessage = "Tên loại xe phải có độ dài từ {2} đến {1} ký tự.", MinimumLength = 2)]
	[Display(Name = "Tên đầy đủ")]
	public string Name { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    [StringLength(100)]
    public string? Power {  get; set; }

    [StringLength(100)]
    public string? Speed { get; set; }

    [StringLength(100)]
    public string? Distance {  get; set; }

    [StringLength(100)]
    public string? Charging { get; set; }
	public int CompanyId { get; set; }
	public Company Company { get; set; }

	[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Giá trị không hợp lệ. Vui lòng nhập số.")]
	public double? Price { get; set; }

	[StringLength(100)]
    public string CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }

    [StringLength(100)]
    public string? UpdatedBy { get; set; }
	public DateTime? UpdationTime { get; set; }
    public bool IsDelete { get; set; }
    public List<EMotorbike> EMotorbikes { get; set; }

}
