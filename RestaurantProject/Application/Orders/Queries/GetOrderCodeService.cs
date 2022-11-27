using Application.Interfaces;
using Application.Interfaces.Order;
using System.Linq;


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
