using Domain.Attributes;
using Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    [Auditable]
  public  class OrderItem
    {
        public int Id { get; set; }
        public CategoryItem CateoryItem { get; set; }
        public int CatalogItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }
        public int UnitPrice { get; private set; }
        public int Units { get; private set; }
    }
}
