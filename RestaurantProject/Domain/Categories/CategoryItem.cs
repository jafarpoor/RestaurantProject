using Domain.Attributes;
using Domain.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Categories
{
    [Auditable]
    public class CategoryItem : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Note { get; set; }
        //public int AvailableStock { get; set; }
        [Required]
        public int Price { get; set; }
        public int? DiscountPercentage { get; set; }
        public CategoryItemImage CategoryItemImage { get; set; }

        public int CategoryItemImageId { get; set; }

    }
}
