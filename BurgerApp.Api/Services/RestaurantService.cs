using BurgerApp.Dal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.Api.Services
{
	public class RestaurantService
	{
		private BurgerAppDbContext DbContext { get; }

		public RestaurantService(BurgerAppDbContext dbContext)
		{
			DbContext = dbContext;
		}
	}
}
