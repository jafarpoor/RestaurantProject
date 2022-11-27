using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Application.Categories.DTO
{
   public class AddCategoryDataModel
    {
        [DisplayName("نام")]
        [Required]
        public string Name { get; set; }
    }
}
