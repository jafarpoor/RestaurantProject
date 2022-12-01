using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Order;
using Application.UriComposer;
using AutoMapper;
using Common.Helper;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace Application.Orders.Commands
{
   public class CreatOrderService : ICreatOrderService
    {

        private readonly IDatabaseContext _contetx;
        private readonly IUriComposerService _uriComposerService;
        private readonly IMapper _mapper;
        public CreatOrderService(IDatabaseContext context , IUriComposerService uriComposerService ,IMapper mapper)
        {
            _contetx = context;
            _uriComposerService = uriComposerService;
            _mapper = mapper;
        }

        public ResultDataModel<int> CreatOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod)
        {
            try
            {
                var basket = _contetx.Baskets
                             .Include(p => p.BasketItems)
                             .SingleOrDefault(p => p.Id == BasketId);

                if (basket == null)
                    return new ResultDataModel<int>
                    {
                         IsSuccess =false ,
                         Message = Messages.NotFund
                    };

                int[] Ids = basket.BasketItems.Select(p => p.CategoryItemId).ToArray();
                var categoryItems = _contetx.CategoryItems
                                     .Include(p => p.CategoryItemImage)
                                     .Where(p => Ids.Contains(p.Id));

                var orderItems = basket.BasketItems.Select(basketItem =>
                {
                    var categoryItem = categoryItems.First(c => c.Id == basketItem.CategoryItemId);

                    var orderitem = new OrderItem() {
                      CategoryItemId = categoryItem.Id ,
                      ProductName = categoryItem.Name ,
                      PictureUri = _uriComposerService.ComposeImageUri(categoryItem?.CategoryItemImage?.Src ?? ""),
                      UnitPrice =categoryItem.Price ,
                      Units=basketItem.Qty
                    };
                    return orderitem;

                }).ToList();

                var userAddress = _contetx.UserAddresses.SingleOrDefault(p => p.Id == UserAddressId);
                var address = _mapper.Map<Address>(userAddress);
                var order = new Order() { 
                    UserId= basket.BuyerId ,
                    userAddress= userAddress,
                    PaymentMethod =paymentMethod ,
                    OrderItems = orderItems ,
                    OrderCode = CreatOrderCode.GetOrderCode()
                };

                _contetx.Orders.Add(order);
                _contetx.Baskets.Remove(basket);
                _contetx.SaveChanges();

                return new ResultDataModel<int>
                {
                    Data = order.Id ,
                    IsSuccess = true,
                    Message = Messages.Successed
                };
            }
            catch (Exception)
            {
                return new ResultDataModel<int>
                {
                    IsSuccess = false,
                    Message = Messages.UnexpectedError
                };
            }
          
        }
    }
}
