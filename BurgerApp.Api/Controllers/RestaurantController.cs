using BurgerApp.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BurgerApp.Api
{
	[ApiController]
	[Route("api/restaurant")]
	public class RestaurantController : ControllerBase
	{
		public RestaurantService RestaurantService { get; set; }

		public RestaurantController(RestaurantService restaurantService)
		{
			RestaurantService = restaurantService;
		}

		[HttpGet("{location}")]
		public void GetRestaurants(string location)
		{

		}

		[HttpPost("rate")]
		public void RateRestaurant(RestaurantRateModel model)
		{

		}
	}
}
