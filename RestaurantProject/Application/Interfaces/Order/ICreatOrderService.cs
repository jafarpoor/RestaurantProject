using Domain.Orders;

namespace Application.Interfaces.Order
{
  public  interface ICreatOrderService
    {
       int CreatOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod);
    }
}
