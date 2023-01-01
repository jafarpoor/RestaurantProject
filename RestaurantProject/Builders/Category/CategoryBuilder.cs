using Application.Categories.DTO;
using Application.PagerConfig;
using Common.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builders.Category
{
    public class CategoryBuilder
    {
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; }

    }
}
