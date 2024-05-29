using QLTX.Models;

namespace QLTX.ViewModels;

public class CreateRental
{
	public string Name { get; set; }
	public string IdDocument { get; set; }
	public string PhoneNumber { get; set; }
	public string Email { get; set; }
	public string Address { get; set; }
	public string CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }
	public string? UpdatedBy { get; set; }
	public DateTime? UpdationTime { get; set; }
	public DateTime DateRetalFrom { get; set; }
	public DateTime DateRetalTo { get; set; }
	public DateTime RetalTime { get; set; }
	public RentalService Service { get; set; }
	public double Price { get; set; }
	public RentalStatus Status { get; set; } = RentalStatus.Renting;
	public double Total { get; set; }
	public string Note { get; set; }
}
