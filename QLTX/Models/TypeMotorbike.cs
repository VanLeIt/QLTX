using System.ComponentModel.DataAnnotations;

namespace QLTX.Models;

public class TypeMotorbike
{
	[Key]
	public int Id { get; set; }
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
	public List<EMotorbike> EMotorbikes { get; set; }

}
