using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Application.Users.DTO
{
    public class EditUserDataModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "نام را وارد نمایید")]
        [DisplayName("نام")]
        public string FristName { get; set; }
        [Required(ErrorMessage = "نام خانوادگی را وارد نمایید")]
        [DisplayName( "نام خانوادگی ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [EmailAddress]
        [DisplayName("ایمیل")]
        public string Email { get; set; }
        [Required(ErrorMessage = "شماره تلفن را وارد کنید ")]
        [DisplayName("شماره تلفن")]
        public string PhoneNumber { get; set; }
        [DisplayName("نام کاربری")]
        public string UserName { get; set; }
       
    }
}
