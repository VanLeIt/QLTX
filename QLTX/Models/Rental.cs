using System.ComponentModel.DataAnnotations;

namespace QLTX.Models;

public class Rental
{
	[Key]
	public int Id { get; set; }
	public int CustomerId { get; set; }
	public Customer Customer { get; set; }
/*	public string UserId { get; set; }
	public User User { get; set; }*/
	public DateTime DateRetalFrom { get; set; }
	public DateTime DateRetalTo { get; set; }
	public string? RetalTime { get; set; }
	public RentalService Service {  get; set; }
	public double Price {  get; set; } 
	//public double KmStart { get; set; }
	//public double KmEnd { get; set; }
	public RentalStatus Status { get; set; } = RentalStatus.Renting;
	public ICollection<RentalDetail> RentlDetails { get; set; } = new List<RentalDetail>();
	public double Total { get; set; }
	public string? Note { get; set; }
	public string CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }
	public string? UpdatedBy { get; set; }
	public DateTime? UpdationTime { get; set; }
    public bool IsDelete { get; set; }
}
public enum RentalService
{
	[Display(Name = "Giờ")]
	Hour = 1 ,
	[Display(Name = "Ngày")]
	Day = 2,
	[Display(Name = "Tuần")]
	Week = 3
}
public enum RentalStatus
{
	[Display(Name = "Đang thuê")]
	Renting =0,
	[Display(Name = "Hoàn thành")]
	Success =1,
	[Display(Name = "Hủy")]
	Cancel =2
}
