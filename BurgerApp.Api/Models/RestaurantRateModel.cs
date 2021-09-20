using System;

namespace BurgerApp.Api
{
	public class RestaurantRateModel
	{
		public Guid RestaurantId { get; set; }
		public int? TasteRating { get; set; }
		public int? TextureRating { get; set; }
		public int? VisualPresentationRating { get; set; }
		public string Comment { get; set; }
	}
}
