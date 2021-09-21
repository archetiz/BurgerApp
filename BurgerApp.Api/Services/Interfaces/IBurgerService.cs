using System.Threading.Tasks;

namespace BurgerApp.Api.Services
{
	public interface IBurgerService
	{
		Task<AddResult> UploadBurger(BurgerUploadModel model);
	}
}
