using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
