using Application.Categories.DTO;
using Application.PagerConfig;

namespace Application.Interfaces.Categories
{
  public  interface IAddCategoryService
    {
            ResultServices Add(AddCategoryDataModel model);
    }
}
