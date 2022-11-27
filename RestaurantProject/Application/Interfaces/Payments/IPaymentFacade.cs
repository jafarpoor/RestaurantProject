
namespace Application.Interfaces.Payments
{
    public interface IPaymentFacade
    {
        ICreatPaymentService creatPayment { get; }
        IGetPaymentService getPayment { get; }
        IVerifyPaymentService verifyPayment { get ;}

        IReciveToCustomerService reciveToCustomerService { get; }
    }
}
