using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


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
