using System;

namespace BurgerApp.Api
{
	public class AddResult
	{
		public Guid Id { get; set; }
		public bool IsSuccess { get; set; }

		public AddResult(Guid id, bool success = true)
		{
			Id = id;
			IsSuccess = success;
		}
	}
}
