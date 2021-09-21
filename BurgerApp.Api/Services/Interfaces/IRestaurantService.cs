using System.Threading.Tasks;

namespace BurgerApp.Api.Services
{
	public interface IRestaurantService
	{
		Task<PagedResult<ResturantListModel>> GetRestaurantsAtLocation(string location, int page);
		Task<AddResult> AddRating(RestaurantRateModel model);
		Task<AddResult> AddRestaurant(RestaurantAddModel model);
	}
}
