using System.Collections.Generic;

namespace BurgerApp.Api.Configurations
{
	public class UploadsConfiguration
	{
		public string MediaPathRoot { get; set; }
		public string MediaPath { get; set; }
		public int MaxFileSizeBytes { get; set; }
		public List<string> AllowedContentTypes { get; set; }
	}
}
