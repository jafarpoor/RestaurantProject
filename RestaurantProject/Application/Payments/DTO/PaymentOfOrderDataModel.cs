using Domain.Orders;
using System;

namespace Application.Payments.DTO
{
   public class PaymentOfOrderDataModel
    {
        public Guid PaymentId { get; set; }
        public long Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
