using Application.Interfaces.Order;
using Application.Interfaces.Payments;
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
        private readonly IPaymentFacade _paymentFacade;

        public OrderController(IOrderFacade orderFacade , IPaymentFacade paymentFacade)
        {
            _orderFacade = orderFacade;
            _paymentFacade = paymentFacade;
        }
        public IActionResult Index()
        {
            return View(_orderFacade.getListOrdersForSendService.GetList());
        }

        public IActionResult OrderDetail(int Id)
        {
            return View(_orderFacade.getOrderCustomerDetailForAdminService.GetOrderDetail(Id));
        }

        public IActionResult OrderDelivered(int Id)
        {
            _paymentFacade.reciveToCustomerService.ChangeStatus(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
