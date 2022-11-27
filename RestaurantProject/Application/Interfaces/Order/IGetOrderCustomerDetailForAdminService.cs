using Application.Orders.DTO;

namespace Application.Interfaces.Order
{
   public interface IGetOrderCustomerDetailForAdminService
    {
        GetOrderCustomerDetailForAdminDataModel GetOrderDetail(int OrderID);
    }
}
