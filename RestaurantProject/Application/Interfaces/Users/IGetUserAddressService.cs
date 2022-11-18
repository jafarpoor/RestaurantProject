using Application.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Users
{
  public  interface IGetUserAddressService
    {
        List<GetUserAddressDataModel> GetUserAddress(string UserId);
    }
}
