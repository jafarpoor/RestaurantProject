using Application.Orders.DTO;
using Application.Payments.DTO;
using System;

namespace Application.Interfaces.Payments
{
  public  interface IGetPaymentService
    {
        PaymentDataModel GetPaymentById(Guid Id);
       
    }
}
