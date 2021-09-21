using System.Threading.Tasks;
using BurgerApp.Dal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BurgerApp
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var host = await CreateHostBuilder(args)
											.Build()
											.MigrateDatabase<BurgerAppDbContext>();
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
