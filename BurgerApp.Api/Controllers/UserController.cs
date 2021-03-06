using BurgerApp.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BurgerApp.Api.Controllers
{
	[ApiController]
	[Route("api/user")]
	[Produces("application/json")]
	public class UserController : ControllerBase
	{
		private IUserService UserService { get; }

		public UserController(IUserService userService)
		{
			UserService = userService;
		}

		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<LoginResultModel> Login(LoginModel loginModel)
			=> await UserService.Login(loginModel);

		[HttpPost("logout")]
		[Authorize]
		public async Task Logout()
			=> await UserService.Logout();

		[HttpPost("register")]
		[AllowAnonymous]
		public async Task<RegistrationResultModel> Register(RegistrationModel model)
			=> await UserService.RegisterUser(model);
	}
}
