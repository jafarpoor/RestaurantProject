using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.DTO
{
  public  class ListCategoryItemDataModel
    {
        public int Id { get; set; }
        [DisplayName("نام محصول")]
        public string Name { get; set; }
        [DisplayName("توضیحات")]
        public string Note { get; set; }
        [DisplayName("قیمت")]
        public Int64 Price { get; set; }
        public int? DiscountPercentage { get; set; }
        public string SrcImage { get; set; }
        public double? TotlalPrice
        {
            get
            {
                if (DiscountPercentage != null)
                {
                    return ((Price * DiscountPercentage) / 100);
                }

                else return null;
            }
        }
}
}
