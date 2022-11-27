using System;

namespace Application.Interfaces.Payments
{
    public interface IVerifyPaymentService
    {
        bool VerifyPayment (Guid Id, string Authority, long RefId);
    }
}
