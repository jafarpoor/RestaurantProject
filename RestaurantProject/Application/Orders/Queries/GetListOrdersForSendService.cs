using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Order;
using Application.Orders.DTO;
using Common.Helper;
using Domain.Payments;
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

        public ResultDataModel<List<GetListOrdersForSendDataModel>> GetList(string OrderStatus)
        {
           IQueryable<Payment> Result = _dataBaseContext.Payments
                                       .Include(p => p.Order)
                                       .ThenInclude(p => p.OrderItems);

            if (Result == null)
                return new ResultDataModel<List<GetListOrdersForSendDataModel>>
                {
                    Data = null ,
                    IsSuccess = false ,
                    Message = Messages.NullMassages
                };

            if(!string.IsNullOrEmpty(OrderStatus))
            if (OrderStatus.Contains("Processing"))
            {
              Result = Result.Where(p => p.Order.OrderStatus == Domain.Orders.OrderStatus.Processing);
            }

            else if (OrderStatus.Contains("Delivered"))
            {
                Result = Result.Where(p => p.Order.OrderStatus == Domain.Orders.OrderStatus.Delivered);
            }

            else if (OrderStatus.Contains("Cancelled"))
            {
                Result = Result.Where(p => p.Order.OrderStatus == Domain.Orders.OrderStatus.Cancelled);
            }

          var model =  Result.Select(p => new GetListOrdersForSendDataModel
                         {
                             OrderId = p.Order.Id,
                             PayAmount = p.Amount,
                             OrderStatus = p.Order.OrderStatusName,
                             OrderCode = p.Order.OrderCode,
                             PayStatus = p.Order.PaymentMethodName,
                             PayDate = ConvertDate.ConvertMiladiToShamsi(p.DatePay , "yyyy/MM/dd")
                         }).ToList();

            return new ResultDataModel<List<GetListOrdersForSendDataModel>>
            {
                Data = model,
                IsSuccess = true,
                Message = Messages.Successed
            };
                
        }
    }
}
