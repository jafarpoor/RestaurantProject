using Domain.Users;
using System;

namespace Domain.Users
{
    public class UserToken
    {
        public int Id { get; set; }
        public string HashToken { get; set; }
        public DateTime ExpTime { get; set; }
        public string MobilModel { get; set; }
        public string RefrshToken { get; set; }
        public DateTime RefrshTokenExp { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
