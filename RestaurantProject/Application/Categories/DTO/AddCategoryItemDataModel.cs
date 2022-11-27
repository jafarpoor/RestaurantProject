using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Categories.DTO
{
   public class AddCategoryItemDataModel
    {
        [Required(ErrorMessage ="نام را وارد کنید")]
        [DisplayName("نام")]
        public string Name { get; set; }

        [Required(ErrorMessage ="دسته بندی را انتخاب کنید")]
        [DisplayName("نام دسته بندی")]
        public int CategoryId { get; set; }

        [DisplayName("توضیحات")]
        public string Note { get; set; }

        [Required(ErrorMessage = "قیمت را وارد کنید")]
        [DisplayName("قیمت")]
        public Int64 Price { get; set; }

        [DisplayName("درصد تخفیف")]
        public int? DiscountPercentage { get; set; }

        public AddNewCategoryItemImageDataModel addNewCatalogItemImageDataModel { get; set; }
    }
}
