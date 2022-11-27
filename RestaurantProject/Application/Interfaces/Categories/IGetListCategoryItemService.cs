using Application.Categories.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Categories
{
   public interface IGetListCategoryItemService
    {
        List<ListCategoryItemDataModel> GetList(int ParentId);
        List<string> GetColumnsName();
    }
}
