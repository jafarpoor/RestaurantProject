using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure.Api.ImageApi
{
    public class ImageUploadService : IImageUploadService
    {
        public string Upload(IFormFile formFile)
        {
            var client = new RestClient("https://localhost:44331/api/Images?apikey=mysecretkey");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                formFile.CopyToAsync(ms);
                    bytes = ms.ToArray();
                }
                request.AddFile(formFile.FileName, bytes, formFile.FileName, formFile.ContentType);

            IRestResponse response = client.Execute(request);
            UploadDto upload = JsonConvert.DeserializeObject<UploadDto>(response.Content);
            return upload.FileNameAddress;
        }
    }
}
