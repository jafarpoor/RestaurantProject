using Domain.Attributes;
using Domain.BaseEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Domain.Categories
{
    [Auditable]
   public  class Category : BaseEntity
    {
        [Required]
        public string TypeName { get; set; }

        public List<CategoryItem> categoryItems { get; set; }
    }
}
