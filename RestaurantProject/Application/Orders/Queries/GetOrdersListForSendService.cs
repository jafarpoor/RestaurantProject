using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Order;
using Application.Orders.DTO;
using Common.Helper;
using Domain.Orders;
using Domain.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries
{
    public class GetOrdersListForSendService : IGetOrdersListForSendService
    {
        private readonly IDatabaseContext _dataBaseContext;

        public GetOrdersListForSendService(IDatabaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ResultDataModel<List<GetListOrderForSendDataModel>> GetResultData()
        {
            IQueryable<Payment> Result = _dataBaseContext.Payments
                                        .Include(p => p.Order)
                                        .ThenInclude(p => p.OrderItems);

            if (Result == null)
                return new ResultDataModel<List<GetListOrderForSendDataModel>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = Messages.NullMassages
                };

                    Result = Result.Where(p => p.Order.OrderStatus == Domain.Orders.OrderStatus.Processing);

            var model = Result.Select(p => new GetListOrderForSendDataModel
            {
                OrderId = p.Order.Id,
                PayAmount = p.Amount,
                OrderStatus = p.Order.OrderStatusName,
                OrderCode = p.Order.OrderCode,
                PayStatus = p.Order.PaymentMethodName,
                PayDate = ConvertDate.ConvertMiladiToShamsi(p.DatePay, "yyyy/MM/dd")
            }).ToList();

            return new ResultDataModel<List<GetListOrderForSendDataModel>>
            {
                Data = model,
                IsSuccess = true,
                Message = Messages.Successed
            };

        }
    }
}
