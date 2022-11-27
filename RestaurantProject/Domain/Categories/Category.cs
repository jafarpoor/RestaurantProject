using Domain.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Domain.Categories
{
    [Auditable]
   public  class Category
    {
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; }

        public List<CategoryItem> categoryItems { get; set; }
    }
}
