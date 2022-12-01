using Application.DTO;
using Application.Orders.DTO;
using Application.Payments.DTO;
using System;

namespace Application.Interfaces.Payments
{
  public  interface IGetPaymentService
    {
        ResultDataModel<PaymentDataModel> GetPaymentById(Guid Id);
       
    }
}
