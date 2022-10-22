using Application.Categories.DTO;
using Application.PagerConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Categories
{
 public interface IAddCategoryItemService
    {
        ResultServices AddCaregoryItem(AddCategoryItemDataModel model);
    }
}
