using System.Collections.Generic;

namespace BurgerApp.Api
{
	public static class UploadHelper
	{
		private static IDictionary<string, string> ContentTypeExtensions = new Dictionary<string, string>
			{
				{ "image/bmp", "bmp" },
				{ "image/gif", "gif" },
				{ "image/jpeg", "jpg" },
				{ "image/png", "png" },
				{ "image/tiff", "tiff" },
				{ "image/webp", "webp" }
			};

		public static string GetExtensionsForContentType(string contentType)
		{
			if (!ContentTypeExtensions.ContainsKey(contentType))
				return null;

			return ContentTypeExtensions[contentType];
		}
	}
}
