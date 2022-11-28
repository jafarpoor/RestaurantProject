using Domain.Attributes;
using Domain.Payments;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Domain.Orders
{
    [Auditable]
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public UserAddress userAddress { get; set; }
        public int userAddressId { get; set; } 
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string OrderCode { get; set; }

        public int TotalPrice()
        {
            int totalPrice = OrderItems.Sum(p => p.UnitPrice * p.Units);
            //if (DiscountAmount != null)
            //    totalPrice -= AppliedDiscount.GetDiscountAmount(totalPrice);
            return totalPrice;
        }

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
        /// لغو سفارش
        /// </summary>
        public void OrderCancelled()
        {
            OrderStatus = OrderStatus.Cancelled;
        }

        public string OrderStatusName
        {
            get{
                string Name = "";
                switch ((int)OrderStatus)
                {
                    case 1:
                        Name = " در حال پردازش";
                        break;
                    case 2:
                        Name = "تحویل داده شد";
                        break;        
                    case 3:
                        Name = "کنسل شد";
                        break;
                    default:
                        Name = "";
                        break;
                }
                return Name;
            }
            
        }

        public string PaymentMethodName
        {
            get
            {
                if (this.PaymentMethod == PaymentMethod.OnlinePaymnt)
                    return "پرداخت آنلاین";
                else if (this.PaymentMethod == PaymentMethod.PaymentOnTheSpot)
                    return "پرداخت در محل";

                else
                    return "";

            }
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
        [Display(Name = "همه")]
        All = 0 ,

       [Display(Name ="در حال پردازش")]
        Processing = 1,
        
        [Display(Name ="تحویل داده شد")]
        Delivered = 2,

        [Display(Name ="کنسل شد")]
        Cancelled = 3

       
    }
}
