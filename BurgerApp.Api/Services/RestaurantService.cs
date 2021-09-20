using BurgerApp.Api.Configurations;
using BurgerApp.Dal;
using BurgerApp.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerApp.Api.Services
{
	public class RestaurantService : IRestaurantService
	{
		private BurgerAppDbContext DbContext { get; }
		private PagingConfiguration PagingConfig { get; }

		public RestaurantService(BurgerAppDbContext dbContext, IOptions<PagingConfiguration> pagingConfig)
		{
			DbContext = dbContext;
			PagingConfig = pagingConfig.Value;
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
				Taste = model.TasteRating ?? 0,
				Texture = model.TextureRating ?? 0,
				VisualPresentation = model.VisualPresentationRating ?? 0,
				Comment = model.Comment,
				RestaurantId = model.RestaurantId,
				//TODO: User
			});

			await DbContext.SaveChangesAsync();

			return new AddResult(rating.Entity.Id);
		}
	}
}
