using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Users
{
  public  interface ITokenValidator
    {
        Task Execute(TokenValidatedContext context);
        public bool CheckExistToken(string Token);
    }
}
