using Domain.Attributes;
using Domain.Categories;

namespace Domain.Orders
{
    [Auditable]
  public  class OrderItem
    {
        public int Id { get; set; }
        public CategoryItem CateoryItem { get; set; }
        public int CategoryItemId { get;  set; }
        public string ProductName { get;  set; }
        public string PictureUri { get;  set; }
        public int UnitPrice { get;  set; }
        public int Units { get;  set; }

    }
}
