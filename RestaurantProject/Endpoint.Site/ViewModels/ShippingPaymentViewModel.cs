using Application.Baskets.DTO;
using Application.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewModels
{
    public class ShippingPaymentViewModel
    {
        public BasketDataModel Basket { get; set; }
        public List<GetUserAddressDataModel> UserAddresses { get; set; }
    }
}
