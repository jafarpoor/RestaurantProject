using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DTO
{
   public class UserTokenDataModel
    {
        public int Id { get; set; }
        public string HashToken { get; set; }
        public DateTime ExpTime { get; set; }
        public string MobilModel { get; set; }
        public string RefrshToken { get; set; }
        public DateTime RefrshTokenExp { get; set; }
        public UserDataModel User { get; set; }
        public int UserId { get; set; }
    }
}
