
using System;
using System.Collections.Generic;
using System.Linq;

namespace Builders.Order
{
    public class OrderBuilder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus orderStatus { get; set; }
        public string OrderCode { get; set; }
        public List<OrderItemBuilder> OrderItems { get; set; }

        public enum OrderStatus
        {

            /// <summary>
            /// در حال پردازش
            /// </summary>
            Processing = 0,
            /// <summary>
            /// تحویل داده شد
            /// </summary>
            Delivered = 1,
            /// <summary>
            /// مرجوعی
            /// </summary>
            Returned = 2,
            /// <summary>
            /// لغو شد
            /// </summary>
            Cancelled = 3,
        }

        public int TotalPrice()
        {
            int totalPrice = OrderItems.Sum(p => p.UnitPrice * p.Units);
            return totalPrice;
        }
    }
}

