using Application.DTO;
using Application.Interfaces.Categories;
using Application.Interfaces.Users;
using Application.Users.DTO;
using Common.Helper;
using Infrastructure.Api.ImageApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly IImageUploadService _imageUploadService;
        private readonly ICategoryFacade _category;
        public CategoryApiController(ICategoryFacade category, 
                                    IImageUploadService imageUploadService 
            )
        {
            _category = category;
            _imageUploadService = imageUploadService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_category.getListCategoyService.GetListCategory());
        }

       
    }
}
