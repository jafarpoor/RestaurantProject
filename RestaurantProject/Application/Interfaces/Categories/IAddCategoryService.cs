using Application.Categories.DTO;
using Application.DTO;


namespace Application.Interfaces.Categories
{
  public  interface IAddCategoryService
    {
        ResultDataModel<string> Add(AddCategoryDataModel model);
    }
}
