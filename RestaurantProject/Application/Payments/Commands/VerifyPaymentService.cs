using Application.Interfaces;
using Application.Interfaces.Payments;
using Common.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payments.Commands
{
    public class VerifyPaymentService : IVerifyPaymentService
    {
        private readonly IDatabaseContext _context;

        public VerifyPaymentService(IDatabaseContext context)
        {
            _context = context;
        }

        public bool VerifyPayment(Guid Id, string Authority, long RefId)
        {
            try
            {
                var payment = _context.Payments
                       .Include(p => p.Order)
                       .SingleOrDefault(p => p.Id == Id);

                if (payment == null)
                    throw new Exception(Messages.NotFund);

                payment.Order.PaymentDone();
                payment.Order.Payment = payment;
                payment.PaymentIsDone(Authority, RefId);

                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
