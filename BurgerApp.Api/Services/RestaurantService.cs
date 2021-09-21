﻿using BurgerApp.Api.Configurations;
using BurgerApp.Dal;
using BurgerApp.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerApp.Api.Services
{
	public class RestaurantService : IRestaurantService
	{
		private BurgerAppDbContext DbContext { get; }
		private PagingConfiguration PagingConfig { get; }
		private IUserService UserService { get; }

		public RestaurantService(BurgerAppDbContext dbContext, IOptions<PagingConfiguration> pagingConfig, IUserService userService)
		{
			DbContext = dbContext;
			PagingConfig = pagingConfig.Value;
			UserService = userService;
		}

		public async Task<PagedResult<ResturantListModel>> GetRestaurantsAtLocation(string location, int page = 1)
		{
			return (await DbContext.Restaurants
									.Where(r => r.Location.Equals(location))
									.OrderBy(r => r.Name)
									.GetPaged(page, PagingConfig.PageSize, out int totalPages)
									.Select(restaurant => new ResturantListModel
									{
										Id = restaurant.Id,
										Name = restaurant.Name,
										Location = restaurant.Location,
										OpeningTime = restaurant.OpeningTime,
										ClosingTime = restaurant.ClosingTime
									})
									.ToListAsync())
									.GetPagedResult(page, PagingConfig.PageSize, totalPages);
		}

		public async Task<AddResult> AddRating(RestaurantRateModel model)
		{
			var rating = DbContext.Ratings.Add(new Rating()
			{
				Id = Guid.NewGuid(),
				Taste = model.TasteRating ?? 0,
				Texture = model.TextureRating ?? 0,
				VisualPresentation = model.VisualPresentationRating ?? 0,
				Comment = model.Comment,
				RatingTime = DateTime.Now,
				RestaurantId = model.RestaurantId,
				UserId = (await UserService.GetCurrentUser()).Id
			});

			await DbContext.SaveChangesAsync();

			return new AddResult(rating.Entity.Id);
		}

		public async Task<AddResult> AddRestaurant(RestaurantAddModel model)
		{
			var restaurant = DbContext.Restaurants.Add(new Restaurant()
			{
				Id = Guid.NewGuid(),
				Name = model.Name,
				Location = model.Location,
				OpeningTime = model.OpeningTime,
				ClosingTime = model.ClosingTime
			});

			await DbContext.SaveChangesAsync();

			return new AddResult(restaurant.Entity.Id);
		}
	}
}
