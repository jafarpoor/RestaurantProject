using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Order;
using Application.Orders.DTO;
using Common.Helper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace Application.Orders.Queries
{
   public class GetOrderCustomerDetailForUserService  : IGetOrderCustomerDetailForUserService
    {
        private readonly IDatabaseContext _contetx;
        public GetOrderCustomerDetailForUserService(IDatabaseContext contetx)
        {
            _contetx = contetx;
        }

        public ResultDataModel<List<GetOrderCustomerDetailForUserDataModel>> GetOrderDetail(int OrderID)
        {
            var orderResult = _contetx.Orders
                             .Include(p => p.OrderItems)
                             .Include(p => p.userAddress)
                             .SingleOrDefault(p => p.Id == OrderID);

            if (orderResult == null)
                return new ResultDataModel<List<GetOrderCustomerDetailForUserDataModel>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = Messages.NullMassages
                };

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

            return new ResultDataModel<List<GetOrderCustomerDetailForUserDataModel>>
            {
                Data = model,
                IsSuccess = true,
                Message = Messages.Successed
            };
        }
    }
}
