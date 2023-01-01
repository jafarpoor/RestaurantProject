
using System.Collections.Generic;

namespace Application.Orders.DTO
{
   public class GetListAllOrderDataModel
    {

        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public string PayStatus { get; set; }
        public string PayDate { get; set; }
        public int PayAmount { get; set; }
        public string OrderStatus { get; set; }
 
    }
}
