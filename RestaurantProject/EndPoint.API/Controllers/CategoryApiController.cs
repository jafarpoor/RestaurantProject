using Application.DTO;
using Application.Interfaces.Categories;
using Application.Users.DTO;
using Common.Helper;
using Infrastructure.Api.ImageApi;
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
        private readonly IConfiguration _configuration;
        public CategoryApiController(ICategoryFacade category, IImageUploadService imageUploadService , IConfiguration configuration)
        {
            _category = category;
            _imageUploadService = imageUploadService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_category.getListCategoyService.GetListCategory());
        }

        private LoginResultDataModel CreatToken(UserDataModel userDto)
        {
            SecurityHelper securityHelper = new SecurityHelper();
            var claims = new List<Claim>
                {
                    new Claim ("Id", userDto.Id.ToString()),
                    new Claim ("Name",  userDto?.Name??""),
                };
            string key = _configuration["JWtConfig:Key"];
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenexp = DateTime.Now.AddMinutes(int.Parse(_configuration["JWtConfig:expires"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWtConfig:issuer"],
                audience: _configuration["JWtConfig:audience"],
                expires: tokenexp,
                notBefore: DateTime.Now,
                claims: claims,
                signingCredentials: credentials
                );


            var MyJwt = new JwtSecurityTokenHandler().WriteToken(token);
            var RefrshToken = Guid.NewGuid();
            //userTokenRepository.SaveToken(new UserTokenDataModel()
            //{
            //    MobilModel = "Iphone pro MAx",
            //    ExpTime = tokenexp,
            //    HashToken = securityHelper.Getsha256Hash(MyJwt),
            //    UserId = userDto.Id,
            //    RefrshToken = securityHelper.Getsha256Hash(RefrshToken.ToString()),
            //    RefrshTokenExp = DateTime.Now.AddDays(30),
            //    User = userDto
            //});


            return new LoginResultDataModel
            {
               // RefreshToken = RefrshToken.ToString(),
                Token = MyJwt
            };
        }
    }
}
