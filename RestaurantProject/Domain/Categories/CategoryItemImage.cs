using Domain.Attributes;

namespace Domain.Categories
{
    [Auditable]
    public class CategoryItemImage
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public CategoryItem CategoryItem { get; set; }
        public int CatlogItemId { get; set; }
    }
}
