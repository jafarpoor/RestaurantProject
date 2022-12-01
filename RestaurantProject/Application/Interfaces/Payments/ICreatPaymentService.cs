using Application.DTO;
using Application.Payments.DTO;

namespace Application.Interfaces.Payments
{
   public interface ICreatPaymentService
    {
        ResultDataModel<PaymentOfOrderDataModel> PayForOrder(int OrderId);
    }
}
