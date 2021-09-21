using BurgerApp.Dal;
using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using BurgerApp.Dal.Entities;
using BurgerApp.Api.Configurations;
using Microsoft.Extensions.Options;

namespace BurgerApp.Api.Services
{
	public class BurgerService : IBurgerService
	{
		private BurgerAppDbContext DbContext { get; }
		private IUserService UserService { get; }
		private UploadsConfiguration UploadsConfig { get; }

		public BurgerService(BurgerAppDbContext dbContext, IUserService userService, IOptions<UploadsConfiguration> uploadsConfig)
		{
			DbContext = dbContext;
			UserService = userService;
			UploadsConfig = uploadsConfig.Value;
		}

		public async Task<AddResult> UploadBurger(BurgerUploadModel model)
		{
			try
			{
				string photoFilePath = await SavePhoto(model.Photo);

				var burger = DbContext.Burgers.Add(new Burger
				{
					Id = Guid.NewGuid(),
					Photo = photoFilePath,
					Comment = model.Comment,
					UploadTime = DateTime.Now,
					RestaurantId = model.RestaurantId,
					UserId = (await UserService.GetCurrentUser()).Id
				});

				await DbContext.SaveChangesAsync();

				return new AddResult(burger.Entity.Id);
			}
			catch(Exception)
			{
				return new AddResult(Guid.Empty, false);
			}
		}

		private async Task<string> SavePhoto(IFormFile file)
		{
			if (file.Length > UploadsConfig.MaxFileSizeBytes)
				throw new ArgumentException("Invalid image size.");

			var extension = UploadHelper.GetExtensionsForContentType(file.ContentType);

			if(!UploadsConfig.AllowedContentTypes.Contains(file.ContentType) || extension == null)
				throw new ArgumentException("Invalid image type.");

			byte[] imageBytes = await file.GetBytes();

			StringBuilder filePathBuilder = new StringBuilder(UploadsConfig.MediaPath);
			filePathBuilder.Append(Guid.NewGuid());
			filePathBuilder.Append('.');
			filePathBuilder.Append(extension);

			string filePath = filePathBuilder.ToString();

			filePathBuilder.Insert(0, UploadsConfig.MediaPathRoot);	//Add media root to save path only

			await File.WriteAllBytesAsync(filePathBuilder.ToString(), imageBytes);

			return filePath;
		}
	}
}
