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
	public string? Description { get; set; }
	public string? Power {  get; set; }
	public string? Speed { get; set; }	
	public string? Battery {  get; set; }
	public string? Charging { get; set; }
	public int CompanyId { get; set; }
	public Company Company { get; set; }
	public string CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }
	public string? UpdatedBy { get; set; }
	public DateTime? UpdationTime { get; set; }
    public bool IsDelete { get; set; }
    public List<EMotorbike> EMotorbikes { get; set; }

}
