using Application.Interfaces;
using Application.Interfaces.Order;
using Application.Orders.DTO;
using Common.Helper;
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

            var Result = _context.Payments
                        .Include(p => p.Order)
                        .Where(p => p.Order.UserId == UserId)
                        .Select(p => new ListOrdersCustomerDataModel
                        {
                            OrderId = p.Order.Id ,
                            PaymentAmount = p.Amount,
                            OrderCode = p.Order.OrderCode,
                            OrderStatus = p.Order.OrderStatusName,
                            PaymentDataTime = ConvertDate.ConvertMiladiToShamsi(p.DatePay , "yyyy/MM/dd")

                        }).ToList();

            return Result;
        }
    }
}
