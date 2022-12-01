using Application.Categories.DTO;
using Application.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Categories
{
  public  interface IGetListCategoyService
    {
        ResultDataModel<List<ListCategoryDataModel>> GetListCategory();
    }
}
