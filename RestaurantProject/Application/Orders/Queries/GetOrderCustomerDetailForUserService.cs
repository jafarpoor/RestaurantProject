using Application.Interfaces;
using Application.Interfaces.Order;
using Application.Orders.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries
{
   public class GetOrderCustomerDetailForUserService  : IGetOrderCustomerDetailForUserService
    {
        private readonly IDatabaseContext _contetx;
        public GetOrderCustomerDetailForUserService(IDatabaseContext contetx)
        {
            _contetx = contetx;
        }

        public List<GetOrderCustomerDetailForUserDataModel> GetOrderDetail(int OrderID)
        {
            var orderResult = _contetx.Orders
                             .Include(p => p.OrderItems)
                             .Include(p => p.userAddress)
                             .SingleOrDefault(p => p.Id == OrderID);

            List<GetOrderCustomerDetailForUserDataModel> model = new List<GetOrderCustomerDetailForUserDataModel>();
            foreach (var item in orderResult.OrderItems)
            {
                var orderItm = new GetOrderCustomerDetailForUserDataModel
                {
                    Price = item.UnitPrice * item.Units,
                    ProductOrderName = item.ProductName,
                    ProductOrderQty = item.Units ,
                    
                };
                model.Add(orderItm);
            }
            return model;
        }
    }
}
