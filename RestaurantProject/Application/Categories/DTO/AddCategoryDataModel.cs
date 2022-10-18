using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.DTO
{
   public class AddCategoryDataModel
    {
        [DisplayName("نام")]
        [Required]
        public string Name { get; set; }
    }
}
