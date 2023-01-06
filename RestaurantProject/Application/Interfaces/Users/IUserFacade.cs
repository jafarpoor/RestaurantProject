using Application.Interfaces.Users;
using Application.Users.Commands.AddUser;

namespace Application.Interfaces
{
    public interface IUserFacade
    {
        IAddUserService addUserService { get; }
        IGetUsersService getUsers{get;}
        IEditUserService editUser { get; }
        IGetUserAddressService getUserAddressService { get; }
        IAddUserAddressService addUserAddressService { get; }
        IEditUserAddressService editUserAddressService { get; }
        ICreatUserTokenService creatUserTokenService { get; }
        ITokenValidator tokenValidator { get; }
    }
}
