using Application.Baskets.DTO;
using Application.Interfaces.Baskets;
using Domain.Users;
using EndPoint.Site.Utilities;
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
        private readonly IBasket _basket;
        private string UserId = null;
       
        public BasketController(IBasket basket , SignInManager<User> signInManager)
        {
            _basket = basket;
            _signInManager = signInManager;
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
    }
}
