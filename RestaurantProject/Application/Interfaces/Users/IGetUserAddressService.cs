using Application.Users.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Users
{
  public  interface IGetUserAddressService
    {
        List<GetUserAddressDataModel> GetUserAddress(string UserId);
    }
}
