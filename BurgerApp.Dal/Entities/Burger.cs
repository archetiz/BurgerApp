using System;

namespace BurgerApp.Dal.Entities
{
	public class Burger
	{
		public Guid Id { get; set; }
		public string Photo { get; set; }
		public string Comment { get; set; }
		public DateTime UploadTime { get; set; }

		public Guid RestaurantId { get; set; }
		public Restaurant Restaurant { get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; }
	}
}
