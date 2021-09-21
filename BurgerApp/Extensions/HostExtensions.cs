using BurgerApp.Dal.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace BurgerApp
{
	public static class HostExtensions
	{
		public async static Task<IHost> MigrateDatabase<TContext>(this IHost host) where TContext : DbContext
		{
			using var scope = host.Services.CreateScope();
			var serviceProvider = scope.ServiceProvider;
			var context = serviceProvider.GetRequiredService<TContext>();
			await context.Database.MigrateAsync();

			var roleSeeder = serviceProvider.GetRequiredService<IRoleSeedService>();
			var userSeeder = serviceProvider.GetRequiredService<IUserSeedService>();
			await roleSeeder.SeedRoleAsync();
			await userSeeder.SeedUserAsync();
			return host;
		}
	}
}
