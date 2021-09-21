using System;

namespace BurgerApp.Api
{
	public class RestaurantAddModel
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public DateTime OpeningTime { get; set; }
		public DateTime ClosingTime { get; set; }
	}
}
