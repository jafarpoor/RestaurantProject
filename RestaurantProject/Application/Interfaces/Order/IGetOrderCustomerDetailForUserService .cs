using Application.DTO;
using Application.Orders.DTO;
using System.Collections.Generic;


namespace Application.Interfaces.Order
{
   public interface IGetOrderCustomerDetailForUserService
    {
        ResultDataModel<List<GetOrderCustomerDetailForUserDataModel>> GetOrderDetail(int OrderID);
    }
}
