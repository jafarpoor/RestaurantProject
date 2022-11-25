﻿using Application.Baskets.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Baskets
{
  public  interface IGetBasketByBuyerIdService
    {
        BasketDataModel GetBasketByBuyerId(string BuyerId);
    }
}