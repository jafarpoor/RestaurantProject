using Application.Users.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Users
{
   public interface IGetUsersService
    {
        List<ListUsersDataModel> GetList();
        List<string> GetColumnsName();
        public EditUserDataModel Find(string Id);
    }
}
