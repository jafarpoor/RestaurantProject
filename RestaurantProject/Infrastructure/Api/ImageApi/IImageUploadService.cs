using Microsoft.AspNetCore.Http;

namespace Infrastructure.Api.ImageApi
{
   public interface IImageUploadService
    {
        string Upload(IFormFile formFile);
    }
}
