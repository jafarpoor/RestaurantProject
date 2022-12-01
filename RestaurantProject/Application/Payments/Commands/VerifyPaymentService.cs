using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Payments;
using Common.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace Application.Payments.Commands
{
    public class VerifyPaymentService : IVerifyPaymentService
    {
        private readonly IDatabaseContext _context;

        public VerifyPaymentService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDataModel VerifyPayment(Guid Id, string Authority, long RefId)
        {
            try
            {
                var payment = _context.Payments
                       .Include(p => p.Order)
                       .SingleOrDefault(p => p.Id == Id);

                if (payment == null)
                    return new ResultDataModel
                    {
                        IsSuccess = false,
                        Message = Messages.NullMassages
                    };

                payment.Order.PaymentDone();
                payment.PaymentIsDone(Authority, RefId);

                _context.SaveChanges();
                return new ResultDataModel
                {
                    IsSuccess = true,
                    Message = Messages.Successed
                };
            }
            catch (Exception)
            {
                return new ResultDataModel
                {
                    IsSuccess = false,
                    Message = Messages.UnexpectedError
                };
            }

        }
    }
}
