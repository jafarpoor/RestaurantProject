using Application.Categories.DTO;
using Application.PagerConfig;

namespace Application.Interfaces.Categories
{
 public interface IAddCategoryItemService
    {
        ResultServices AddCaregoryItem(AddCategoryItemDataModel model);
    }
}
