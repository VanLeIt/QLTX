﻿namespace QLTX.ViewModels;

public class UserRolesDto
{
	public string UserId { get; set; }
	public List<string> RoleIds { get; set; }

	public UserRolesDto()
	{
		RoleIds = new List<string>();
	}
}
