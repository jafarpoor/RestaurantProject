using Application.Interfaces.Order;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Admin.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderFacade _orderFacade;

        public OrderController(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }
        public IActionResult Index()
        {
            return View(_orderFacade.getListOrdersForSendService.GetList());
        }

        public IActionResult OrderDetail(int Id)
        {
            // ویو ایجاد شده
            return View();
        }
    }
}
