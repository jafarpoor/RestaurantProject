using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.DTO
{
 public   class GetOrderCustomerDetailForUserDataModel
    {
        public string ProductOrderName { get; set; }
        public int ProductOrderQty { get; set; }
        public int Price { get; set; }

    }
}
