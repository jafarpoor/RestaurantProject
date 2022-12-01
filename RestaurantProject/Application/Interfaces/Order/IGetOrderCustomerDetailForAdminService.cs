using Application.DTO;
using Application.Orders.DTO;

namespace Application.Interfaces.Order
{
   public interface IGetOrderCustomerDetailForAdminService
    {
        ResultDataModel<GetOrderCustomerDetailForAdminDataModel> GetOrderDetail(int OrderID);
    }
}
