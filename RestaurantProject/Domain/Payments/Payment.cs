using Domain.Attributes;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payments
{
    [Auditable]
    public class Payment
    {
        public Guid Id { get; set; }
        public int Amount { get;  set; }
        public bool IsPay { get;  set; } = false;
        public DateTime? DatePay { get;  set; } = null;
        public string Authority { get;  set; }
        public long RefId { get;  set; } = 0;
        public Order Order { get;  set; }
        public int OrderId { get;  set; }

        public void PaymentIsDone(string authority, long refId)
        {
            IsPay = true;
            DatePay = DateTime.Now;
            Authority = authority;
            RefId = refId;
        }
    }
}
