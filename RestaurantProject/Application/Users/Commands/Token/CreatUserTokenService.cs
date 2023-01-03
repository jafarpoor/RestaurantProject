using Application.Interfaces;
using Application.Interfaces.Users;
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
    }
}
