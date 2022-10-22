using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Categories
{
    public interface ICategory
    {
        IAddCategoryService addCategory { get; }
        IGetListCategoyService getListCategoyService { get; }
        IAddCategoryItemService addCategoryItemService  {get;}
        IGetListCategoryItemService getListCategoryItemService { get; }
        IGetCategoryName getCategoryName { get; }
    }
}
