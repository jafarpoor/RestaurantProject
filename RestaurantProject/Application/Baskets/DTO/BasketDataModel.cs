using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Baskets.DTO
{
  public  class BasketDataModel
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDataModel> Items { get; set; } = new List<BasketItemDataModel>();

        public Int64 TotalWithOutDiescount()
        {
            if (Items.Count > 0)
            {

                return Items.Sum(p => p.Qty * p.UnitPrice);
            }
            return 0;
        }

        //public int TotalAmountBasket()
        //{
        //    if (Items.Count > 0)
        //    {
        //        var total = Items.Sum(p => p.Qty * p.UnitPrice);
        //        total -= DiscountAmount;
        //        return total;
        //    }
        //    return 0;
        //}
    }
}
