using System;

namespace BurgerApp.Api
{
	public class RestaurantBurgerListModel
	{
		public Guid Id { get; set; }
		public string Photo { get; set; }
		public string Comment { get; set; }
		public DateTime UploadTime { get; set; }
	}
}
