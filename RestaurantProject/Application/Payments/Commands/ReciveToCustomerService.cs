using Application.Interfaces;
using Application.Interfaces.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payments.Commands
{
  public  class ReciveToCustomerService : IReciveToCustomerService
    {
        private readonly IDatabaseContext _contetx;
        public ReciveToCustomerService(IDatabaseContext contetx)
        {
            _contetx = contetx;
        }

        public void ChangeStatus(int OrderId)
        {
            var Result = _contetx.Payments
                        .Include(p => p.Order)
                        .SingleOrDefault(p => p.OrderId == OrderId);

             Result.Order.OrderDelivered();
            if (Result.Order.PaymentMethod == Domain.Orders.PaymentMethod.PaymentOnTheSpot)
                Result.Order.PaymentDone();
            _contetx.SaveChanges();
        }
    }
}
