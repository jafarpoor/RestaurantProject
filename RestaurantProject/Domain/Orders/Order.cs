using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    [Auditable]
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get;  set; }
        public DateTime OrderDate { get;  set; } = DateTime.Now;
        [NotMapped]
        public Address Address { get; set; }
        public PaymentMethod PaymentMethod { get;  set; }
        public PaymentStatus PaymentStatus { get;  set; }
        public OrderStatus OrderStatus { get;  set; }
        public  List<OrderItem> OrderItems = new List<OrderItem>();


    
        /// <summary>
        /// پرداخت انجام شد
        /// </summary>
        public void PaymentDone()
        {
            PaymentStatus = PaymentStatus.Paid;
        }


        /// <summary>
        /// کالا تحویل داده شد
        /// </summary>
        public void OrderDelivered()
        {
            OrderStatus = OrderStatus.Delivered;
        }

        /// <summary>
        /// ثبت مرجوعی کالا
        /// </summary>
        public void OrderReturned()
        {
            OrderStatus = OrderStatus.Returned;
        }


        /// <summary>
        /// لغو سفارش
        /// </summary>
        public void OrderCancelled()
        {
            OrderStatus = OrderStatus.Cancelled;
        }
    }


    public enum PaymentMethod
    {
        /// <summary>
        /// پرداخت آنلاین
        /// </summary>
        OnlinePaymnt = 0,
        /// <summary>
        /// پرداخت در محل
        /// </summary>
        PaymentOnTheSpot = 1,
    }

    public enum PaymentStatus
    {
        /// <summary>
        /// منتظر پرداخت
        /// </summary>
        WaitingForPayment = 0,
        /// <summary>
        /// پرداخت انجام شد
        /// </summary>
        Paid = 1,
    }

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
}
