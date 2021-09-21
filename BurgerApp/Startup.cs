using System;
using BurgerApp.Api.Configurations;
using BurgerApp.Api.Services;
using BurgerApp.Dal;
using BurgerApp.Dal.Configurations;
using BurgerApp.Dal.Entities;
using BurgerApp.Dal.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BurgerApp
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IWebHostEnvironment environment)
		{
			Configuration = configuration;
			Environment = environment;
		}

		public IConfiguration Configuration { get; }
		public IWebHostEnvironment Environment { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<BurgerAppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

			services.AddIdentity<User, IdentityRole<Guid>>().AddEntityFrameworkStores<BurgerAppDbContext>().AddDefaultTokenProviders();

			services.AddScoped<IRoleSeedService, RoleSeedService>();
			services.AddScoped<IUserSeedService, UserSeedService>();

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IRestaurantService, RestaurantService>();
			services.AddScoped<IBurgerService, BurgerService>();

			services.Configure<DefaultAdministratorConfiguration>(options => Configuration.GetSection("DefaultAdministrator").Bind(options));
			services.Configure<PagingConfiguration>(options => Configuration.GetSection("Paging").Bind(options));
			services.Configure<UploadsConfiguration>(options => Configuration.GetSection("Uploads").Bind(options));

			services.AddControllers();
			services.AddRazorPages();

			if (Environment.IsDevelopment())
			{
				services.AddSwaggerGen();
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Doc");
				});
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapRazorPages();
			});
		}
	}
}
