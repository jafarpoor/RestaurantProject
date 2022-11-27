
using System.ComponentModel.DataAnnotations;


namespace Application.Users.DTO
{
  public  class AddUserAddressDataModel
    {
        [Required(ErrorMessage = "نام استان را وارد کنید")]
        [Display(Name = "استان")]
        public string State { get; set; }

        [Required(ErrorMessage = "نام شهر را وارد کنید")]
        [Display(Name = "شهر")]
        public string City { get; set; }

        [Display(Name = "کدپستی")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "آدرس پستی را وارد کنید")]
        [Display(Name = "آدرس پستی ")]
        public string PostalAddress { get; set; }

        public string UserId { get; set; }

        [Display(Name = "نام تحویل گیرنده")]
        public string ReciverName { get; set; }
    }
}
