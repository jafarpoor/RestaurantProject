using Application.Orders.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Payments
{
  public  interface IGetPaymentService
    {
        PaymentDataModel GetPaymentById(Guid Id);
        bool VerifyPayment(Guid Id, string Authority, long RefId);
    }
}
