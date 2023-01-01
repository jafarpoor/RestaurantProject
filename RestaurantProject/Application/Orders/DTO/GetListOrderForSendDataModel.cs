using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.DTO
{
   public class GetListOrderForSendDataModel
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public string PayStatus { get; set; }
        public string PayDate { get; set; }
        public int PayAmount { get; set; }
        public string OrderStatus { get; set; }
    }
}
