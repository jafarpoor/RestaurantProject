using Application.DTO;
using Application.Users.DTO;

namespace Application.Interfaces.Users
{
  public  interface IEditUserAddressService
    {
        ResultDataModel EditAddress(EditUserAddressDataModel editUser);
        ResultDataModel<EditUserAddressDataModel> FindUserAddress(int Id);
    }
}
