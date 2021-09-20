using BurgerApp.Dal.Entities;
using System.Threading.Tasks;

namespace BurgerApp.Api.Services
{
	public interface IUserService
	{
		Task<LoginResultModel> Login(LoginModel loginModel);
		Task Logout();
		Task<User> GetCurrentUser();
	}
}
