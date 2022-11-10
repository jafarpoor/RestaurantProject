using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Baskets.DTO
{
   public class BasketItemDataModel
    {
        public int Id { get; set; }
        public int CategoryItemId { get; set; }
        public string CatalogName { get; set; }
        public Int64 UnitPrice { get; set; }
        public int Qty { get; set; }
        public string ImageUrl { get; set; }
        public int Discount { get; set; }
        public Int64 TotalPrice { get; set; }
    }
}
