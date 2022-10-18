using Application.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Users
{
   public interface IGetUsersService
    {
        List<ListUsersDataModel> GetList();
        List<string> GetColumnsName();
        public EditUserDataModel Find(string Id);
    }
}
