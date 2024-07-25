using System.ComponentModel.DataAnnotations;
using QLTX.Models;

namespace QLTX.ViewModels;

public class DasboadDto
{
    public string? Name { get; set; } 
    public string? Description { get; set; } 
    public string? PhoneNumber { get; set; } 
    public string? Email { get; set; } 
    public string? Address { get; set; }
    public int? eMotor { get; set; }
    public int? eMotorReady { get; set; }
    public int? eMotorRenting { get; set; }
    public int? renting { get; set; }
    public int? rentalSuccess { get; set; }

}
