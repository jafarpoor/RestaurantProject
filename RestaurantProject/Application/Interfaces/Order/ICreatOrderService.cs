using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Order
{
  public  interface ICreatOrderService
    {
       int CreatOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod);
    }
}
