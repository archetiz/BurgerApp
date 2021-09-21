using BurgerApp.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BurgerApp.Api
{
	[ApiController]
	[Route("api/restaurant")]
	[Produces("application/json")]
	public class RestaurantController : ControllerBase
	{
		public IRestaurantService RestaurantService { get; set; }

		public RestaurantController(IRestaurantService restaurantService)
		{
			RestaurantService = restaurantService;
		}

		[HttpGet("{location}")]
		[HttpGet("{location}/{page}")]
		[Authorize]
		public async Task<PagedResult<ResturantListModel>> GetRestaurants(string location, int page = 1)
			=> await RestaurantService.GetRestaurantsAtLocation(location, page);

		[HttpPost("rate")]
		[Authorize]
		public async Task<AddResult> RateRestaurant(RestaurantRateModel model)
			=> await RestaurantService.AddRating(model);

		[HttpGet("{restaurantId}/ratings")]
		[HttpGet("{restaurantId}/ratings/{page}")]
		[Authorize]
		public async Task<PagedResult<RestaurantRatingListModel>> GetRestaurantRatings(Guid restaurantId, int page = 1)
			=> await RestaurantService.GetRestaurantRatings(restaurantId, page);

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<AddResult> AddRestaurant(RestaurantAddModel model)
			=> await RestaurantService.AddRestaurant(model);

		[HttpGet("{restaurantId}/burgers")]
		[HttpGet("{restaurantId}/burgers/{page}")]
		[Authorize]
		public async Task<PagedResult<RestaurantBurgerListModel>> GetRestaurantBurgers(Guid restaurantId, int page = 1)
			=> await RestaurantService.GetRestaurantBurgers(restaurantId, page);

		[HttpDelete("{ratingId}")]
		[Authorize]
		public void DeleteRating(Guid ratingId)
		{
			// Here the user would be able to delete his/her own ratings
			// The deletion would go as below:
			// 1. Set a flag (e.g. IsActive) on the entry to be deleted
			// 2. Erase any comment data to respect the user's privacy
			// Note: oviously the user could only delete rating entries that specifically he/she has created
			throw new NotImplementedException();
		}

		[HttpDelete("{restaurantId}")]
		[Authorize(Roles = "Admin")]
		public void DeleteRestaurant(Guid restaurantId)
		{
			// Here administrators would be able to delete restaurants (e.g. because they no longer exist)
			// The deletion would only mean setting a flag (e.g. IsActive)
			// on the entry to be deleted to preserve the consistency of the database
			throw new NotImplementedException();
		}
	}
}
