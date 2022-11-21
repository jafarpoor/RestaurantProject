using Application.Baskets.DTO;
using Application.Interfaces;
using Application.Interfaces.Baskets;
using Application.Interfaces.Order;
using Application.Interfaces.Payments;
using Domain.Orders;
using Domain.Users;
using EndPoint.Site.Utilities;
using EndPoint.Site.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class BasketController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IBasketFacade _basket;
        private readonly IOrderFacade _OrderService;
        private readonly IUserFacade _UserService;
        private readonly IPaymentFacade _paymentService;
        private string UserId = null;
       
        public BasketController(IBasketFacade basket , 
                                SignInManager<User> signInManager ,
                                IOrderFacade OrderService,
                                IUserFacade UserService ,
                                IPaymentFacade paymentService)
        {
            _basket = basket;
            _signInManager = signInManager;
            _OrderService = OrderService;
            _UserService = UserService;
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult Index(int categoryItemId , int Qty=1)
        {
            var result = GetOrSetBasket();
            _basket.basketService.AddOrGetItemToBasket(result.Id, categoryItemId , Qty);
            return Json(true);
        }

        private BasketDataModel GetOrSetBasket()
        {
            if (_signInManager.IsSignedIn(User))
            {
                UserId = ClaimUtility.GetUserId(User);
                return _basket.basketService.GetOrCreateBasketForUser(UserId);
            }
            else
            {
                SetCookiesForBasket();
                return _basket.basketService.GetOrCreateBasketForUser(UserId);
            }
        }

        private void SetCookiesForBasket()
        {
            if (Request.Cookies.ContainsKey(ClaimUtility.basketCookieName))
            {
                UserId = Request.Cookies[ClaimUtility.basketCookieName];
            }
            if (UserId != null) return;
            UserId = Guid.NewGuid().ToString();
            var cookieOption = new CookieOptions { IsEssential = true };
            cookieOption.Expires = DateTime.Today.AddYears(5);
            Response.Cookies.Append(ClaimUtility.basketCookieName, UserId, cookieOption);
        }

        [Authorize]
        public IActionResult ShowBasketItem()
        {
            if (_signInManager.IsSignedIn(User))
                UserId = ClaimUtility.GetUserId(User);
                 
           else if (Request.Cookies.ContainsKey(ClaimUtility.basketCookieName))
                UserId = Request.Cookies[ClaimUtility.basketCookieName];
            if (UserId == null)
                return NotFound();

            return View(_basket.basketService.GetBasketByBuyerId(UserId));
        }

        [HttpPost]
        public IActionResult RemoveItemFromBasket(int ItemId)
        {
            _basket.basketService.RemoveBasketItem(ItemId);
            return RedirectToAction("ShowBasketItem");
        }


        [Authorize]
        public IActionResult ShippingPayment()
        {
            ShippingPaymentViewModel model = new ShippingPaymentViewModel();
            var userId = ClaimUtility.GetUserId(User);
            model.Basket = _basket.basketService.GetBasketByBuyerId(userId);
            model.UserAddresses = _UserService.getUserAddressService.GetUserAddress(userId);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ShippingPayment(int Address, PaymentMethod PaymentMethod)
        {
            var userId = ClaimUtility.GetUserId(User);
            var basket = _basket.basketService.GetBasketByBuyerId(userId);
            var Order = _OrderService.creatOrderService.CreatOrder(basket.Id, Address, PaymentMethod);
            if (PaymentMethod == PaymentMethod.OnlinePaymnt)
            {
                //ثبت پرداخت
                var payment = _paymentService.creatPayment.PayForOrder(Order);
                //ارسال به درگاه پرداخت
                 return RedirectToAction("Index", "Pay", new { PaymentId = payment.PaymentId });
            }
            else
            {
                //برو به صفحه سفارشات من
                return RedirectToAction("Index", "Orders", new { area = "customers" });
            }
        }

        public IActionResult CheckOut(bool ResultPay , int OrderID )
        {
            ViewBag.ResultPay = ResultPay;
            if(OrderID !=0)
            ViewBag.OrderCode = _OrderService.getOrderCoedService.GetCode(OrderID);
                return View();
        }
    }
}
