using BurgerApp.Dal;
using BurgerApp.Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.Api.Services
{
	public class UserService : IUserService
	{
		private SignInManager<User> SignInManager { get; }
		private UserManager<User> UserManager { get; }
		private IHttpContextAccessor HttpContextAccessor { get; }
		private BurgerAppDbContext DbContext { get; }

		public UserService(SignInManager<User> signInManager, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, BurgerAppDbContext dbContext)
		{
			SignInManager = signInManager;
			UserManager = userManager;
			HttpContextAccessor = httpContextAccessor;
			DbContext = dbContext;
		}

		public async Task<LoginResultModel> Login(LoginModel loginModel)
		{
			LoginResultModel loginResult = new LoginResultModel();
			var user = await UserManager.FindByNameAsync(loginModel.UserName);

			if (user == null)
				throw new ArgumentException("No user exists with the given credentials.");

			var signInResult = await SignInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, false);
			if (signInResult.Succeeded)
			{
				loginResult.IsSuccess = true;
			}
			else
			{
				loginResult.IsSuccess = false;
			}
			return loginResult;
		}

		public async Task Logout()
		{
			await SignInManager.SignOutAsync();
		}

		public async Task<User> GetCurrentUser()
			=> await UserManager.GetUserAsync(HttpContextAccessor.HttpContext.User);

		public async Task<RegistrationResultModel> RegisterUser(RegistrationModel model)
		{
			if ((await DbContext.Users.CountAsync(u => u.UserName == model.UserName || u.Email == model.Email)) > 0)
				throw new ArgumentException("A user with the given credentials already exists.");

			var user = new User
			{
				UserName = model.UserName,
				Email = model.Email,
				Name = model.Name,
				SecurityStamp = Guid.NewGuid().ToString()
			};

			var createResult = await UserManager.CreateAsync(user, model.Password);
			var addToRoleResult = await UserManager.AddToRoleAsync(user, Roles.User);

			if (!createResult.Succeeded || !addToRoleResult.Succeeded)
				throw new ApplicationException("Error registering new user.");

			return new RegistrationResultModel(true);
		}
	}
}
