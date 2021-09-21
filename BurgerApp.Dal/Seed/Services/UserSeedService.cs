using BurgerApp.Dal.Configurations;
using BurgerApp.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerApp.Dal.Seed
{
	public class UserSeedService : IUserSeedService
	{
		private readonly UserManager<User> userManager;
		private readonly DefaultAdministratorConfiguration defaultAdminConfiguration;

		public UserSeedService(UserManager<User> userManager, IOptions<DefaultAdministratorConfiguration> config)
		{
			this.userManager = userManager;
			this.defaultAdminConfiguration = config.Value;
		}

		public async Task SeedUserAsync()
		{
			if (!(await userManager.GetUsersInRoleAsync(Roles.Admin)).Any())
			{
				var user = new User
				{
					UserName = defaultAdminConfiguration.UserName,
					Email = defaultAdminConfiguration.Email,
					SecurityStamp = Guid.NewGuid().ToString()
				};

				var createResult = await userManager.CreateAsync(user, defaultAdminConfiguration.Password);
				var addToRoleResult = await userManager.AddToRoleAsync(user, Roles.Admin);

				if (!createResult.Succeeded || !addToRoleResult.Succeeded)
					throw new ApplicationException("Seeding error: Couldn't create admin!");
			}
		}
	}
}
