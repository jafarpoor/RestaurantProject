using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Order
{
   public interface IOrderFacade
    {
        ICreatOrderService creatOrderService { get; }
    }
}
