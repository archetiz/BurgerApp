using System;

namespace BurgerApp.Api
{
	public class RestaurantRatingListModel
	{
		public Guid Id { get; set; }
		public int TasteRating { get; set; }
		public int TextureRating { get; set; }
		public int VisualPresentationRating { get; set; }
		public string Comment { get; set; }
		public DateTime RatingTime { get; set; }
	}
}
