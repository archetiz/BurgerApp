using BurgerApp.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Api
{
	[ApiController]
	[Route("api/burger")]
	class BurgerController : ControllerBase
	{
		private BurgerService BurgerService { get; }

		public BurgerController(BurgerService burgerService)
		{
			BurgerService = burgerService;
		}

		[HttpPost]
		public void UploadBurger(BurgerUploadModel model)
		{

		}
	}
}
