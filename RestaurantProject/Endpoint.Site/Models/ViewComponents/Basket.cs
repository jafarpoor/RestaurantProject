using Application.Interfaces.Baskets;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Models.ViewComponents
{
    public class Basket : ViewComponent
    {
        private readonly IBasket _basket;
        string UserId = null;
        public Basket(IBasket basket )
        {
            _basket = basket;
        }

        public IViewComponentResult Invoke()
        {
            GetUserIdInBasket();
            var Result = _basket.basketService.GetOrCreateBasketForUser(UserId);
            return View(viewName: "Basket", model: Result);
        }

        private void GetUserIdInBasket()
        {
            string basketCookieName = "BasketId";
            if (Request.Cookies.ContainsKey(basketCookieName))
                UserId = Request.Cookies[basketCookieName];
        }
    }
}
