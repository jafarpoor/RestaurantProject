using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.DTO
{
    public class ListOrdersCustomerDataModel
    {
        public string OrderCode { get; set; }
        public string OrderStatus { get; set; }

        public int PaymentAmount { get; set; }

       public string PaymentDataTime {  get; set; }
    }
}
