using Application.Interfaces.Order;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class CustomerController : Controller
    {
        private readonly IOrderFacade _orderFacade;
        public CustomerController(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var UserId = ClaimUtility.GetUserId(User);
            return View(_orderFacade.getOrdersCustomer.GetList(UserId));
        }

        public IActionResult OrderCustomerDetail(int Id)
        {
            return View(_orderFacade.getOrderCustomerDetailForUserService.GetOrderDetail(Id));
        }
    }
}
