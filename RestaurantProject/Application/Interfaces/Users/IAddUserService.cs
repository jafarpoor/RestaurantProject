using Application.PagerConfig;
using Application.Users.DTO;
using Infrastructure.PagerConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.AddUser
{
   public interface IAddUserService 
    {
        ResultServices Creat(RegisterDataModel model);
    }
}
