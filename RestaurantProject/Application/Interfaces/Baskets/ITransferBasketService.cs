﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Baskets
{
  public  interface ITransferBasketService
    {
        void TransferBasket(string anonymousId, string UserId);
    }
}
