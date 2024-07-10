using Microsoft.EntityFrameworkCore;
using QLTX.Models;

namespace QLTX.ViewModels;

public class CreateRental
{
    public int IdCustomer { get; set; }
    public Customer Customer { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreationTime { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdationTime { get; set; }
    public DateTime DateRetalFrom { get; set; }
    public DateTime DateRetalTo { get; set; }
    public string? RetalTime { get; set; }
    public RentalService Service { get; set; }
    public double KmStart { get; set; }
    public double KmEnd { get; set; }
    public double Price { get; set; }
    public IList<int> EmotorIds { get; set; }
    public RentalStatus Status { get; set; } = RentalStatus.Renting;
    public double Total { get; set; }
    public string? Note { get; set; }
    public List<EMotorbike> Emotors { get; set; }
    public bool IsDelete { get; set; }
    public Config Config { get; set; }
	
}


