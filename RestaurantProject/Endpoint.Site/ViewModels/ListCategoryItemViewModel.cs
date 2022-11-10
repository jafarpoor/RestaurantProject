using Application.Baskets.DTO;
using Application.Categories.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewModels
{
    public class ListCategoryItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public Int64 Price { get; set; }
        public int? DiscountPercentage { get; set; }
        public string SrcImage { get; set; }
        public int CountCategoryInBasket { get; set; }
    }
}
