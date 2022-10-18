using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.DTO
{
   public class AddCategoryItemDataModel
    {
        [Required(ErrorMessage ="نام را وارد کنید")]
        [DisplayName("نام")]
        public string Name { get; set; }

        [Required(ErrorMessage ="")]
        [DisplayName("نام دسته بندی")]
        public int ParentId { get; set; }

        [DisplayName("توضیحات")]
        public string Note { get; set; }

        [Required(ErrorMessage = "قیمت را وارد کنید")]
        [DisplayName("قیمت")]
        public Int64 Price { get; set; }

        [Required(ErrorMessage = "")]
        [DisplayName("درصد تخفیف")]
        public int DiscountPercentage { get; set; }

        public AddNewCatalogItemImageDataModel AddNewCatalogItemImageDataModel { get; set; }
    }
}
