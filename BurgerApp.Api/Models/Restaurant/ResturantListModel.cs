using System;

namespace BurgerApp.Api
{
	public class ResturantListModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public DateTime OpeningTime { get; set; }
		public DateTime ClosingTime { get; set; }
	}
}
