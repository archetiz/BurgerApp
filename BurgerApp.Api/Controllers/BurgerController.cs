﻿using BurgerApp.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BurgerApp.Api
{
	[ApiController]
	[Route("api/burger")]
	[Produces("application/json")]
	[Authorize]
	class BurgerController : ControllerBase
	{
		private BurgerService BurgerService { get; }

		public BurgerController(BurgerService burgerService)
		{
			BurgerService = burgerService;
		}

		[HttpPost]
		public async Task<AddResult> UploadBurger(BurgerUploadModel model)
			=> await BurgerService.UploadBurger(model);
	}
}
