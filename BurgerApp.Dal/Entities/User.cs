using Microsoft.AspNetCore.Identity;
using System;

namespace BurgerApp.Dal.Entities
{
	public class User : IdentityUser<Guid>
	{
		public string Name { get; set; }
	}
}
