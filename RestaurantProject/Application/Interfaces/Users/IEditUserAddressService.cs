using Application.Users.DTO;

namespace Application.Interfaces.Users
{
  public  interface IEditUserAddressService
    {
        void EditAddress(EditUserAddressDataModel editUser);
        EditUserAddressDataModel FindUserAddress(int Id);
    }
}
