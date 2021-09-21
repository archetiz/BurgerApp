using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BurgerApp.Dal.Seed
{
	public class RoleSeedService : IRoleSeedService
	{
		private readonly RoleManager<IdentityRole<Guid>> roleManager;

		public RoleSeedService(RoleManager<IdentityRole<Guid>> roleManager)
		{
			this.roleManager = roleManager;
		}

		public async Task SeedRoleAsync()
		{
			if (!await roleManager.RoleExistsAsync(Roles.Admin))
				await roleManager.CreateAsync(new IdentityRole<Guid> { Name = Roles.Admin });

			if (!await roleManager.RoleExistsAsync(Roles.User))
				await roleManager.CreateAsync(new IdentityRole<Guid> { Name = Roles.User });
		}
	}
}
