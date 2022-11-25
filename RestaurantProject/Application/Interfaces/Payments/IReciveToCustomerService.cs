using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Payments
{
  public  interface IReciveToCustomerService
    {
        void ChangeStatus(int OrderId);
    }
}
