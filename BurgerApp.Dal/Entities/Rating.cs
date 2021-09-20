using System;

namespace BurgerApp.Dal.Entities
{
	public class Rating
	{
		public Guid Id { get; set; }
		public int Taste { get; set; }
		public int Texture { get; set; }
		public int VisualPresentation { get; set; }
		public string Comment { get; set; }
		public DateTime RatingTime { get; set; }

		public Guid RestaurantId { get; set; }
		public Restaurant Restaurant { get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; }
	}
}
