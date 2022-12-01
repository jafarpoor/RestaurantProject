using Application.DTO;
using Application.Users.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Users
{
   public interface IGetUsersService
    {
        ResultDataModel<List<ListUsersDataModel>> GetList();
        List<string> GetColumnsName();
        public ResultDataModel<EditUserDataModel> Find(string Id);
    }
}
