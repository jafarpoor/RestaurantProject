using Application.Interfaces;
using Application.Interfaces.Order;
using Application.UriComposer;
using AutoMapper;
using Common.Helper;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int CreatOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod)
        {
            try
            {
                var basket = _contetx.Baskets
                     .Include(p => p.BasketItems)
                     .SingleOrDefault(p => p.Id == BasketId);

                if (basket == null)
                    throw new Exception(Messages.NotFund);

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

                //if (basket.DiscountAmount != null)
                //{
                //    discountHistoryService.InsertDiscountUsageHistory(basket.Id, order.Id);
                //}

                return order.Id;
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
