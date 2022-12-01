using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Order;
using Common.Helper;
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
        public ResultDataModel<string> GetCode(int OrderId)
        {
            var OrderCode = _context.Orders.SingleOrDefault(p => p.Id == OrderId).OrderCode;
            if (!string.IsNullOrEmpty(OrderCode))
                return new ResultDataModel<string>
                {
                    Data = OrderCode,
                    IsSuccess = true,
                    Message = Messages.Successed
                };

            else
                return new ResultDataModel<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = Messages.NotFund
                };

        }
    }
}
