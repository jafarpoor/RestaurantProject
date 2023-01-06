using Application.DTO;
using Application.Interfaces.Categories;
using Application.Interfaces.Users;
using Application.Users.DTO;
using Common.Helper;
using Domain.Users;
using Infrastructure.Api.ImageApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AccountApiController : ControllerBase
    {
        private readonly ICreatUserTokenService _userTokenRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        public AccountApiController(ICreatUserTokenService userTokenRepository ,
                                    UserManager<User> userManager, 
                                    SignInManager<User> signInManager ,
                                    IConfiguration configuration
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userTokenRepository = userTokenRepository;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult post(string Email)
        {
            var LoginResult = _userManager.FindByNameAsync(Email).Result;
            if (LoginResult == null)
            {
                return Unauthorized();
            }

            UserDataModel userData = new UserDataModel
            {
                Id = LoginResult.Id,
                Name = LoginResult.FristName +""+LoginResult.LastName,
                PhoneNumber = LoginResult.PhoneNumber
            };
            var token = CreatToken(userData);
            return Ok(token);

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
            _userTokenRepository.SaveToken(new UserTokenDataModel()
            {
                MobilModel = "Iphone pro MAx",
                ExpTime = tokenexp,
                HashToken = securityHelper.Getsha256Hash(MyJwt),
                UserId = userDto.Id,
                User = userDto
            });


            return new LoginResultDataModel
            {
                Token = MyJwt
            };
        }
    }
}
