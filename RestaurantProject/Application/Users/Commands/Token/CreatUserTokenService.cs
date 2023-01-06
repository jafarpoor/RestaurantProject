using Application.Interfaces;
using Application.Interfaces.Users;
using Application.Users.DTO;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Token
{
   public class CreatUserTokenService : ICreatUserTokenService
    {
        private readonly IDatabaseContext _context;

        public CreatUserTokenService(IDatabaseContext context)
        {
            _context = context;
        }

        public void SaveToken(UserTokenDataModel userTokenDto)
        {
            //Find user

            UserToken MyUserToken = new UserToken
            {
                //   Id = userTokenDto.Id,
                ExpTime = userTokenDto.ExpTime,
                HashToken = userTokenDto.HashToken,
                MobilModel = userTokenDto.HashToken,
                UserId = userTokenDto.UserId
            };
            _context.UserTokens.Add(MyUserToken);
            _context.SaveChanges();

        }
    }
}
