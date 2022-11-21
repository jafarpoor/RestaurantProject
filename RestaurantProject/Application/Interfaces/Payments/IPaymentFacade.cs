﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Payments
{
    public interface IPaymentFacade
    {
        ICreatPaymentService creatPayment { get; }
        IGetPaymentService getPayment { get; }
        IVerifyPaymentService verifyPayment { get ;}
    }
}
