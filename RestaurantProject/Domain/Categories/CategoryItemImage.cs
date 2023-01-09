using Domain.Attributes;
using Domain.BaseEntities;

namespace Domain.Categories
{
    [Auditable]
    public class CategoryItemImage : BaseEntity
    {
        public string Src { get; set; }
        public CategoryItem CategoryItem { get; set; }
        public int CatlogItemId { get; set; }
    }
}
