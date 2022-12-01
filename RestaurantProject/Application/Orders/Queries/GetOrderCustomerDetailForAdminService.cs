using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Order;
using Application.Orders.DTO;
using Common.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Application.Orders.Queries
{
    public class GetOrderCustomerDetailForAdminService : IGetOrderCustomerDetailForAdminService
    {
        private readonly IDatabaseContext _contetx;
        public GetOrderCustomerDetailForAdminService(IDatabaseContext contetx)
        {
            _contetx = contetx;
        }

        public ResultDataModel<GetOrderCustomerDetailForAdminDataModel> GetOrderDetail(int OrderID)
        {
            var orderResult = _contetx.Orders
                                .Include(p => p.OrderItems)
                                .Include(p => p.userAddress)
                                .SingleOrDefault(p => p.Id == OrderID);

            var user = _contetx.Users.SingleOrDefault(p => p.Id == orderResult.UserId);

            if (user == null || orderResult == null)
                return new ResultDataModel<GetOrderCustomerDetailForAdminDataModel>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = Messages.NullMassages
                };

            GetOrderCustomerDetailForAdminDataModel model = new GetOrderCustomerDetailForAdminDataModel();
            foreach (var item in orderResult.OrderItems)
            {
                OrderDetailForAdminDataModel order = new OrderDetailForAdminDataModel()
                {
                    ProductOrderName = item.ProductName,
                    ProductOrderQty = item.Units
                };
                model.orderDetailForAdminDataModels.Add(order);
            }

            model.PhoneNumber = user.PhoneNumber;
            model.UserName = user.FristName + "-" + user.LastName;
            model.Address = orderResult.userAddress.City + "-" + orderResult.userAddress.PostalAddress;

            return new ResultDataModel<GetOrderCustomerDetailForAdminDataModel>
            {
                Data = model,
                IsSuccess = true,
                Message = Messages.Successed
            };
        }
    }
}
