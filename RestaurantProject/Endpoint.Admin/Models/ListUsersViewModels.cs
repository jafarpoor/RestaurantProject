using Application.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Admin.Models
{
    public class ListUsersViewModels
    {
        public  List<ListUsersDataModel> listUsersDataModels { get; set; }
        public  List<string> columnsName { get; set; }
    }
}
