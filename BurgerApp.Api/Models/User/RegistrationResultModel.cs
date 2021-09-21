namespace BurgerApp.Api
{
	public class RegistrationResultModel
	{
		public bool IsSuccess { get; set; }

		public RegistrationResultModel(bool result)
		{
			IsSuccess = result;
		}
	}
}
