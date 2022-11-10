using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Categories
{
   public interface IGetCategoryName
    {
        string GetName(int ParentId);
    }
}
