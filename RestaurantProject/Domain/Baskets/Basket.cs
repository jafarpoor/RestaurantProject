using Domain.Attributes;
using Domain.BaseEntities;
using System.Collections.Generic;

namespace Domain.Baskets
{
    [Auditable]
    public  class Basket : BaseEntity
    {
        public string BuyerId { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
