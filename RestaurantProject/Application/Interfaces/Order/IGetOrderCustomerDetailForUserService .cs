using Application.Orders.DTO;
using System.Collections.Generic;


namespace Application.Interfaces.Order
{
   public interface IGetOrderCustomerDetailForUserService
    {
        List<GetOrderCustomerDetailForUserDataModel> GetOrderDetail(int OrderID);
    }
}
