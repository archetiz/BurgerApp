using BurgerApp.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BurgerApp.Api
{
	[ApiController]
	[Route("api/restaurant")]
	public class RestaurantController : ControllerBase
	{
		public IRestaurantService RestaurantService { get; set; }

		public RestaurantController(IRestaurantService restaurantService)
		{
			RestaurantService = restaurantService;
		}

		[HttpGet("{location}")]
		[HttpGet("{location}/{page}")]
		public async Task<PagedResult<ResturantListModel>> GetRestaurants(string location, int page = 1)
			=> await RestaurantService.GetRestaurantsAtLocation(location, page);

		[HttpPost("rate")]
		public async Task<AddResult> RateRestaurant(RestaurantRateModel model)
			=> await RestaurantService.AddRating(model);
	}
}
