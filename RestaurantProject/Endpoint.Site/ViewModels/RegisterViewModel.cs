using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "نام را وارد نمایید")]
        [Display(Name = "نام ")]
        [MaxLength(100, ErrorMessage = "نام نباید بیش از 100 کاراکتر باشد")]
        public string FristName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد نمایید")]
        [Display(Name = "نام خانوادگی ")]
        [MaxLength(100, ErrorMessage = "نام خانوادگی نباید بیش از 200 کاراکتر باشد")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار پسورد را وارد نمایید")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "پسورد و تکرار آن باید برابر باشد")]
        [Display(Name = "تکرار پسورد")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "شماره تلفن را وارد کنید ")]
        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string ReturnUrl { get; set; }
    }
}
