using Application.Categories.DTO;
using Application.DTO;

namespace Application.Interfaces.Categories
{
 public interface IAddCategoryItemService
    {
        ResultDataModel AddCaregoryItem(AddCategoryItemDataModel model);
    }
}
