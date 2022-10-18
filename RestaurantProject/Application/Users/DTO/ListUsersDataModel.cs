
using Common.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DTO
{
   public class ListUsersDataModel
    {
        public string Id { get; set; }
        [DisplayName("نام")]
        public string FristName { get; set; }
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }
        [DisplayName("ایمیل")]
        public string Email { get; set; }
        [DisplayName("شماره تلفن")]
        public string PhoneNumber { get; set; }        
    }
}
