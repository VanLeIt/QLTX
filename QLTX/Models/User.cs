using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QLTX.Models;

public class User : IdentityUser
{
    [Required, StringLength(100)]
    public string? FullName { get; set; }
    [StringLength(255)]
    public string? Address { get; set; } 
	public string? CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }
	public string? UpdatedBy { get; set; }
	public DateTime? UpdationTime { get; set; }
	public ICollection<Rental> Rentals { get; set; }

	public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
	public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
	public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
	public virtual ICollection<UserRoles> UserRoles { get; set; }
}
