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
    public class GetOrdersCustomerService : IGetOrdersCustomerService
    {

        private readonly IDatabaseContext _context;
        
        public GetOrdersCustomerService(IDatabaseContext context)
        {
            _context = context;
        }
        public List<ListOrdersCustomerDataModel> GetList(string UserId)
        {

            //var Result = _context.Orders
            //            .Include(p => p.OrderItems)
            //            .Where(p => p.UserId == UserId)
            //            .Select(p=> new ListOrdersCustomerDataModel
            //            {
            //                OrderCode = p.OrderCode, 
            //                OrderStatus = p.OrderStatus. ,
            //                PaymentAmount = p.Payment?.Amount? ?? p.Payment?.Amount ,
            //                PaymentDataTime  = 
            //            }).ToList();


            throw new NotImplementedException();
        }
    }
}
