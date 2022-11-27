
using System.ComponentModel;


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
