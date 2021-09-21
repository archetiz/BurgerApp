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
	}
}
