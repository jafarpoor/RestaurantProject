using Application.Interfaces;
using Application.Interfaces.Users;
using Common.Helper;
using Domain.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Token
{
    public class TokenValidator : ITokenValidator
    {
        private readonly UserManager<User> _userManager;
        private readonly ICreatUserTokenService _userTokenRepository;
        private readonly IDatabaseContext _contetxt;
        public TokenValidator(UserManager<User> user, ICreatUserTokenService userToken , IDatabaseContext contetxt)
        {
            _userManager = user;
            _userTokenRepository = userToken;
            _contetxt = contetxt;

        }
        public async Task Execute(TokenValidatedContext context)
        {
            var claimsidentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsidentity == null)
            {
                context.Fail("claim not fund...");
                return;
            }
            var userId = claimsidentity.FindFirst("Id").Value;
            var userFind = _userManager.FindByIdAsync(userId);
            if (!(context.SecurityToken is JwtSecurityToken Token) || !(CheckExistToken(Token.RawData)))
            {
                context.Fail("token not exsist ....");
                return;
            }
        }

        public bool CheckExistToken(string Token)
        {
            SecurityHelper MySecurityHelper = new SecurityHelper();
            var RefreshToknHash = MySecurityHelper.Getsha256Hash(Token);
            var TokenResult = _contetxt.UserTokens.Where(p => p.HashToken == RefreshToknHash).FirstOrDefault();
            return TokenResult == null ? false : true;
        }
    }
}
