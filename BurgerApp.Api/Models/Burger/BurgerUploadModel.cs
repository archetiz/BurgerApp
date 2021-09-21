using Microsoft.AspNetCore.Http;
using System;

namespace BurgerApp.Api
{
	public class BurgerUploadModel
	{
		public IFormFile Photo { get; set; }
		public string Comment { get; set; }
		public Guid RestaurantId { get; set; }
	}
}
