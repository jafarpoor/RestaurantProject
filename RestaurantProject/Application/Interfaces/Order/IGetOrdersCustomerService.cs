using Application.DTO;
using Application.Orders.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Order
{
   public interface IGetOrdersCustomerService
    {
        ResultDataModel<List<ListOrdersCustomerDataModel>> GetList(string UserId);
    }
}
