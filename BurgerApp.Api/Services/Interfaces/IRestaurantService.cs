using System;
using System.Threading.Tasks;

namespace BurgerApp.Api.Services
{
	public interface IRestaurantService
	{
		Task<PagedResult<ResturantListModel>> GetRestaurantsAtLocation(string location, int page);
		Task<AddResult> AddRating(RestaurantRateModel model);
		Task<PagedResult<RestaurantRatingListModel>> GetRestaurantRatings(Guid restaurantId, int page);
		Task<AddResult> AddRestaurant(RestaurantAddModel model);
		Task<PagedResult<RestaurantBurgerListModel>> GetRestaurantBurgers(Guid restaurantId, int page);
	}
}
