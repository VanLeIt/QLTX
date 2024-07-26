using System.ComponentModel.DataAnnotations;

namespace QLTX.Models;

public class Rental
{
	[Key]
	public int Id { get; set; }
	public int CustomerId { get; set; }
	public Customer Customer { get; set; }

	public DateTime DateRetalFrom { get; set; }
	public DateTime DateRetalTo { get; set; }
	public float? RetalTime { get; set; }
	public RentalService Service {  get; set; }
	public float Price {  get; set; } 
	//public double KmStart { get; set; }
	//public double KmEnd { get; set; }
	public RentalStatus Status { get; set; } = RentalStatus.Renting;
	public virtual ICollection<RentalDetail> RentlDetails { get; set; } 
    public float? LateFee { get; set; }
    //public int IdEmotor { get; set; }
    //public EMotorbike EMotorbike { get; set; }
    public float Total { get; set; }

    [StringLength(255)]
    public string? Note { get; set; }

    [StringLength(100)]
    public string CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }

    [StringLength(100)]
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
	Cancel =2,
    [Display(Name = "Quá hạn")]
    Expired = 3
}
