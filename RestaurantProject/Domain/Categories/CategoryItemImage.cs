using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
