using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace QLTX.Models;

public class Role : IdentityRole
{
    [StringLength(100)]
    public string? Description { get; set; }

    [StringLength(100)]
    public string? CreatedBy { get; set; }
	public DateTime CreationTime { get; set; }

    [StringLength(100)]
    public string? UpdatedBy { get; set; }
	public DateTime? UpdationTime { get; set; }
    public bool IsDelete { get; set; }
    public virtual ICollection<UserRoles>? UserRoles { get; set; }
}
