using Application.Interfaces;
using Application.Interfaces.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries
{
    public class GetOrderCodeService : IGetOrderCodeService
    {
        private readonly IDatabaseContext _context;

        public GetOrderCodeService(IDatabaseContext contex) 
        {
            _context = contex;
        }
        public string GetCode(int OrderId)
        {
            var OrderCode = _context.Orders.SingleOrDefault(p => p.Id == OrderId).OrderCode;
            return OrderCode;
        }
    }
}
