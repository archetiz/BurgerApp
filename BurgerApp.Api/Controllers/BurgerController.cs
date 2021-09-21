using BurgerApp.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
	}
}
