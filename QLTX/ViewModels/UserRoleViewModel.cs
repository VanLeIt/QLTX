using Microsoft.AspNetCore.Mvc.Rendering;

namespace QLTX.ViewModels
{
	public class UserRoleViewModel
	{
		public string UserId { get; set; }
		public string UserName { get; set; }
		public List<SelectListItem> AvailableRoles { get; set; }
		public List<string> SelectedRoles { get; set; }
	}
}
