using Application.Categories.DTO;
using Application.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Categories
{
   public interface IGetListCategoryItemService
    {
        ResultDataModel<List<ListCategoryItemDataModel>> GetList(int ParentId);
        List<string> GetColumnsName();
    }
}
