using Application.Orders.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Order
{
   public interface IGetOrdersCustomerService
    {
        List<ListOrdersCustomerDataModel> GetList(string UserId);
    }
}
