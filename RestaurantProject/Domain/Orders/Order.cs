using Domain.Attributes;
using Domain.Payments;
using Domain.Users;
using System;
using System.Collections.Generic;
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

        public string OrderStatusName
        {
            get{
                string Name = "";
                switch ((int)OrderStatus)
                {
                    case 0:
                        Name = " در حال پردازش";
                        break;
                    case 1:
                        Name = "تحویل داده شد";
                        break;
                    case 2:
                        Name = "مرجوعی";
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
