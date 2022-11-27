using Application.Interfaces;
using Application.Interfaces.Payments;
using Application.Payments.DTO;
using Common.Helper;
using Domain.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace Application.Payments.Commands
{
   public class CreatPaymentService : ICreatPaymentService
    {
        private readonly IDatabaseContext _context;

        public CreatPaymentService(IDatabaseContext context)
        {
            _context = context;
        }

        public PaymentOfOrderDataModel PayForOrder(int OrderId)
        {
            try
            {
                var orders = _context.Orders
                          .Include(p => p.OrderItems)
                          .SingleOrDefault(p => p.Id == OrderId);
                if (orders == null)
                    throw new Exception(Messages.NotFund);

                var pay = _context.Payments.FirstOrDefault(p => p.OrderId == OrderId);
                if(pay == null)
                {
                    Payment payment = new Payment
                    {
                        Order = orders,
                        Amount = orders.TotalPrice(),
                        DatePay = DateTime.Now
                    };

                    _context.Payments.Add(payment);
                    _context.SaveChanges();
                    return new PaymentOfOrderDataModel
                    {
                        PaymentId = payment.Id,
                        Amount = payment.Amount,
                        PaymentMethod = orders.PaymentMethod
                    };
                }
                else
                {
                    return new PaymentOfOrderDataModel
                    {
                        PaymentId = pay.Id,
                        Amount = pay.Amount,
                        PaymentMethod = orders.PaymentMethod
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
