using Microsoft.AspNetCore.Identity;

namespace QLTX.Models
{
	public class UserRoles : IdentityUserRole<string>
	{
		public virtual User User { get; set; }
		public virtual Role Role { get; set; }
	}
}
