using Application.Orders.Queries;
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
        IGetOrdersCustomerService getOrdersCustomer { get; }
        IGetOrderCodeService getOrderCoedService { get; }
        IGetListOrdersForSendService getListOrdersForSendService { get; }
    }
}
