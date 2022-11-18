using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payments.DTO
{
   public class PaymentOfOrderDataModel
    {
        public Guid PaymentId { get; set; }
        public long Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
