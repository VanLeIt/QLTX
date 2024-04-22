using System.ComponentModel.DataAnnotations;

namespace QLTX.Models;

public class Rental
{
	[Key]
	public int Id { get; set; }
	public int CustomerId { get; set; }
	public Customer Customer { get; set; }
	public string UserId { get; set; }
	public User User { get; set; }
	public DateTime DateRetalFrom { get; set; }
	public DateTime DateRetalTo { get; set; }
	public DateTime RetalTime { get; set; }
	public RentalService Service {  get; set; }
	public double Price {  get; set; }
	public RentalStatus Status { get; set; } = RentalStatus.Renting;
	public double Total { get; set; }
	public string Note { get; set; }
	public string CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }
	public string? UpdatedBy { get; set; }
	public DateTime? UpdationTime { get; set; }

}
public enum RentalService
{
	Hour = 0,
	Day = 1,
}
public enum RentalStatus
{
	Renting=0,
	Success =1,
	Cancel=2
}
