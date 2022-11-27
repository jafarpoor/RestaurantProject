using Application.Payments.DTO;

namespace Application.Interfaces.Payments
{
   public interface ICreatPaymentService
    {
        PaymentOfOrderDataModel PayForOrder(int OrderId);
    }
}
