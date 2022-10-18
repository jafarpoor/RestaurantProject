using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
