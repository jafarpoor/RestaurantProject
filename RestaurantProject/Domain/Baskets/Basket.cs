using Domain.Attributes;
using System.Collections.Generic;

namespace Domain.Baskets
{
    [Auditable]
    public  class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
