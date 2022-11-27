
namespace Application.Users.DTO
{
   public class RegisterDataModel
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string ReturnUrl { get; set; }
    }
}
