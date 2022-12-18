using Application.Interfaces.Order;
using Application.Interfaces.Payments;
using Domain.Orders;
using EndPoint.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [HttpGet]
        public IActionResult Index()
        {
            GetListOrdersForSendViewModel model = new GetListOrdersForSendViewModel();
            var ResultSelectItem = new List<SelectListItem>();

            foreach (var item in EnumHelper<OrderStatus>.GetValues(OrderStatus.All))
            {
                ResultSelectItem.Add(new SelectListItem
                {
                    Text = EnumHelper<OrderStatus>.GetDisplayValue(item),
                    Value = EnumHelper<OrderStatus>.Parse(item.ToString()).ToString()
                }); ;
            }
            model.OrderStatusItems = ResultSelectItem;
            model.getListOrdersForSendDataModels = _orderFacade.getListOrdersForSendService.GetList(null).Data;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string OrderStatusName)
        {
            GetListOrdersForSendViewModel model = new GetListOrdersForSendViewModel();
            var ResultSelectItem = new List<SelectListItem>();

            foreach (var item in EnumHelper<OrderStatus>.GetValues(OrderStatus.All))
            {
                ResultSelectItem.Add(new SelectListItem
                {
                    Text = EnumHelper<OrderStatus>.GetDisplayValue(item),
                    Value = EnumHelper<OrderStatus>.Parse(item.ToString()).ToString()
                }); ;
            }
            model.OrderStatusItems = ResultSelectItem;
            model.getListOrdersForSendDataModels = _orderFacade.getListOrdersForSendService.GetList(OrderStatusName).Data;
            return Json(model);
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
