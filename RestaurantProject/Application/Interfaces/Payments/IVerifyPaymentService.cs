using Application.DTO;
using System;

namespace Application.Interfaces.Payments
{
    public interface IVerifyPaymentService
    {
        ResultDataModel VerifyPayment (Guid Id, string Authority, long RefId);
    }
}
