using BurgerApp.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BurgerApp.Api
{
	[ApiController]
	[Route("api/burger")]
	[Produces("application/json")]
	public class BurgerController : ControllerBase
	{
		private IBurgerService BurgerService { get; }

		public BurgerController(IBurgerService burgerService)
		{
			BurgerService = burgerService;
		}

		[HttpPost]
		[Authorize]
		[Consumes("multipart/form-data")]
		public async Task<AddResult> UploadBurger([FromForm] BurgerUploadModel model)
			=> await BurgerService.UploadBurger(model);

		[HttpDelete("{burgerId}")]
		[Authorize]
		public void DeleteBurger(Guid burgerId)
		{
			// Here the user would be able to delete his/her own burger pictures
			// The deletion would go as below:
			// 1. Set a flag (e.g. IsActive) on the entry to be deleted
			// 2. Remove the picture file to respect the user's privacy
			// 3. Erase any comment data, again to respect the user's privacy
			// Note: oviously the user could only delete burger entries that specifically he/she has uploaded
			throw new NotImplementedException();
		}
	}
}
