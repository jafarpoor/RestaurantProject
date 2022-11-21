using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Payments
{
    public interface IVerifyPaymentService
    {
        bool VerifyPayment (Guid Id, string Authority, long RefId);
    }
}
