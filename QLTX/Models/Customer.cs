using System.ComponentModel.DataAnnotations;

namespace QLTX.Models;

public class Customer
{
	[Key]
	public int Id { get; set; }
	public string Name { get; set; }
	public string IdDocument { get; set; }
	public string PhoneNumber { get; set; }
	public string Email { get; set; }
	public string Address { get; set; }
	public string CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }
	public string? UpdatedBy { get; set; }
	public DateTime? UpdationTime { get; set; }
}
