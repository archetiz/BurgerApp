using BurgerApp.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BurgerApp.Dal
{
	public class BurgerAppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
	{
		public DbSet<Burger> Burgers { get; set; }
		public DbSet<Rating> Ratings { get; set; }
		public DbSet<Restaurant> Restaurants { get; set; }

		public BurgerAppDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Restaurant>(builder =>
			{
				builder.Property(r => r.Name).IsRequired();
				builder.Property(r => r.Location).IsRequired();
				builder.Property(r => r.OpeningTime).IsRequired();
				builder.Property(r => r.ClosingTime).IsRequired();
			});

			modelBuilder.Entity<Rating>(builder =>
			{
				builder.HasCheckConstraint("CK_TasteRating", "Taste >= 0 AND Taste <= 5");
				builder.HasCheckConstraint("CK_TextureRating", "Texture >= 0 AND Texture <= 5");
				builder.HasCheckConstraint("CK_VisualPresentationRating", "VisualPresentation >= 0 AND VisualPresentation <= 5");
			});

			modelBuilder.Entity<Restaurant>().HasMany(restaurant => restaurant.Burgers).WithOne(burger => burger.Restaurant);
			modelBuilder.Entity<Restaurant>().HasMany(restaurant => restaurant.Ratings).WithOne(rating => rating.Restaurant);
		}
	}
}
