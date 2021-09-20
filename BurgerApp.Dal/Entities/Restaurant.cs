using System;
using System.Collections.Generic;

namespace BurgerApp.Dal.Entities
{
	public class Restaurant
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public DateTime OpeningTime { get; set; }
		public DateTime ClosingTime { get; set; }

		public IEnumerable<Burger> Burgers { get; set; }
		public IEnumerable<Rating> Ratings { get; set; }
	}
}
