using Application.Interfaces.Users;
using Application.Users.Commands.AddUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsers
    {
        IAddUserService addUserService { get; }
        IGetUsersService getUsers{get;}
        IEditUserService editUser { get; }
    }
}
