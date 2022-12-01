using Application.DTO;
using Domain.Orders;

namespace Application.Interfaces.Order
{
  public  interface ICreatOrderService
    {
       ResultDataModel<int> CreatOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod);
    }
}
