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
    public class CategoryItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Category ParentCategory { get; set; }
        public int ParentId { get; set; }
        public string Note { get; set; }
        //public int AvailableStock { get; set; }
        [Required]
        public Int64 Price { get; set; }
        public int DiscountPercentage { get; set; }
        public CategoryItemImage CategoryItemImage { get; set; }

        public int CategoryItemImageId { get; set; }

    }
}
