using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Payments;
using Common.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Application.Payments.Commands
{
  public  class ReciveToCustomerService : IReciveToCustomerService
    {
        private readonly IDatabaseContext _contetx;
        public ReciveToCustomerService(IDatabaseContext contetx)
        {
            _contetx = contetx;
        }

        public ResultDataModel ChangeStatus(int OrderId)
        {
            try
            {
                var Result = _contetx.Payments
                     .Include(p => p.Order)
                     .SingleOrDefault(p => p.OrderId == OrderId);

                Result.Order.OrderDelivered();
                if (Result.Order.PaymentMethod == Domain.Orders.PaymentMethod.PaymentOnTheSpot)
                    Result.Order.PaymentDone();
                _contetx.SaveChanges();

                return new ResultDataModel
                {
                    IsSuccess = true,
                    Message = Messages.Successed
                };
            }
            catch (System.Exception)
            {
                return new ResultDataModel
                {
                    IsSuccess = false,
                    Message = Messages.NotFund
                };
            }
         
        }
    }
}
