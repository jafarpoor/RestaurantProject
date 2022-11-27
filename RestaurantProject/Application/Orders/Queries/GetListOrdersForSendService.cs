using Application.Interfaces;
using Application.Interfaces.Order;
using Application.Orders.DTO;
using Common.Helper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Orders.Queries
{
  public  class GetListOrdersForSendService : IGetListOrdersForSendService
    {

        private readonly IDatabaseContext _dataBaseContext;

        public GetListOrdersForSendService(IDatabaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public List<GetListOrdersForSendDataModel> GetList()
        {
            var Result = _dataBaseContext.Payments
                         .Include(p => p.Order)
                         .ThenInclude(p => p.OrderItems)
                         .Where(p => p.Order.OrderStatus == Domain.Orders.OrderStatus.Processing)
                         .Select(p => new GetListOrdersForSendDataModel
                         {
                             OrderId = p.Order.Id,
                             PayAmount = p.Amount,
                             OrderStatus = p.Order.OrderStatusName,
                             OrderCode = p.Order.OrderCode,
                             PayStatus = p.Order.PaymentMethodName,
                             PayDate = ConvertDate.ConvertMiladiToShamsi(p.DatePay , "yyyy/MM/dd")
                         }).ToList();

            return Result;
        }
    }
}
