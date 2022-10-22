using Endpoint.StaticFile.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.StaticFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;

        public ImagesController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Post(string Apikey)
        {
            if (Apikey != "mysecretkey")
                return BadRequest();

            try
            {
                var MyFiles = Request.Form.Files;
                var FolderName = Path.Combine("Resources", "Images");
                var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);
                if(MyFiles != null)
                {
                    return Ok(UploadFile(MyFiles));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private UploadDto UploadFile(IFormFileCollection myFiles)
        {
            string NewName = Guid.NewGuid().ToString();
            var Date = DateTime.Now;
            string Folder = $@"Resources\images\{Date.Year}\{Date.Month}\";
            var UploadsRootFolder = Path.Combine(_environment.WebRootPath, Folder);
            if (!Directory.Exists(UploadsRootFolder))
            {
                Directory.CreateDirectory(UploadsRootFolder);
            }
                string AddressImage = null;
                foreach (var item in myFiles)
                {
                    if (item != null)
                    {
                        string FileName = NewName + item.FileName;
                        var FilePath = Path.Combine(UploadsRootFolder, FileName);
                        using (var FileStream = new FileStream(FilePath , FileMode.Create))
                        {
                            item.CopyTo(FileStream);
                        }
                        AddressImage = (Folder + FileName);
                    }
                }
                return new UploadDto()
                {
                    FileNameAddress = AddressImage,
                    Status = true
                };
            }
        }
}
