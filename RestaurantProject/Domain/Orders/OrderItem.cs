using Domain.Attributes;
using Domain.BaseEntities;
using Domain.Categories;

namespace Domain.Orders
{
    [Auditable]
  public  class OrderItem : BaseEntity
    {
        public CategoryItem CateoryItem { get; set; }
        public int CategoryItemId { get;  set; }
        public string ProductName { get;  set; }
        public string PictureUri { get;  set; }
        public int UnitPrice { get;  set; }
        public int Units { get;  set; }

    }
}
