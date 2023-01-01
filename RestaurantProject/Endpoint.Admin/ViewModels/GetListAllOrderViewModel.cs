using Application.Orders.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Admin.ViewModels
{
    public class GetListAllOrderViewModel
    {
        public List<GetListAllOrderDataModel> getListOrdersForSendDataModels { get; set; }
        public List<SelectListItem> OrderStatusItems { get; set; }
    }
}
