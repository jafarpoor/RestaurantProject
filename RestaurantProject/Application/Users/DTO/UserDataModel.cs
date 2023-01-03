using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DTO
{
  public  class UserDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<UserTokenDataModel> userTokens { get; set; } = new List<UserTokenDataModel>();
    }
}
