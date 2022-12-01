using Application.DTO;
using Application.Users.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Users
{
  public  interface IGetUserAddressService
    {
      ResultDataModel<List<GetUserAddressDataModel>> GetUserAddress(string UserId);
    }
}
