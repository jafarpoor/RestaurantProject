using Domain.Attributes;
using Domain.Categories;
using System;

namespace Domain.Baskets
{
    [Auditable]
  public  class BasketItem
    {
        public int Id { get; set; }
        public CategoryItem CategoryItem { get; set; }
        public int CategoryItemId { get; set; }
        public Basket Basket { get; set; }
        public int BasketId { get; set; }
        public Int64 UnitPrice { get; set; }
        public int Qty { get; set; }

        public string ImageUrl
        {
            get
            {
                return (CategoryItem?.CategoryItemImage?.Src ?? "");
            }
        }
    }
}
