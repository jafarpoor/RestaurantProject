using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.DTO
{
    public class ListCategoryDataModel
    {
        public int Id { get; set; }
        [DisplayName("نام ")]
        [Required(ErrorMessage ="نام را وارد کنید")]
        public string Name { get; set; }

    }
}
