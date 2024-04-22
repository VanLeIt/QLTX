namespace QLTX.Models;

public class Bill
{
	public int Id { get; set; }
	public string StoreName { get; set; }
	public string Address { get; set; }
	public int RentalId { get; set; }
	public Rental Rental { get; set; }
	public bool Status { get; set; }
	public DateTime DatePay { get; set; }
	public int SumEMotor { get; set; }
	public double SumAmount { get; set; }
	public string CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }
	public string? UpdatedBy { get; set; }
	public DateTime? UpdationTime { get; set; }


}
