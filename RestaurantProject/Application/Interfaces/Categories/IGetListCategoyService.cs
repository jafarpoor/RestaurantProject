using Application.Categories.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Categories
{
  public  interface IGetListCategoyService
    {
        List<ListCategoryDataModel> GetListCategory();
    }
}
