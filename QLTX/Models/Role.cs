using Microsoft.AspNetCore.Identity;


namespace QLTX.Models;

public class Role : IdentityRole
{
	public string? Description { get; set; }
	public string? CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }
	public string? UpdatedBy { get; set; }
	public DateTime? UpdationTime { get; set; }
	public virtual ICollection<UserRoles> UserRoles { get; set; }
}
