using BurgerApp.Dal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.Api.Services
{
	public class BurgerService : IBurgerService
	{
		private BurgerAppDbContext DbContext { get; }

		public BurgerService(BurgerAppDbContext dbContext)
		{
			DbContext = dbContext;
		}
	}
}
