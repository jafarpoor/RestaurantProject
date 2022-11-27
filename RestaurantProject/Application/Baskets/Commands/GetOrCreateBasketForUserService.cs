using Application.Baskets.DTO;
using Application.Interfaces;
using Application.Interfaces.Baskets;
using AutoMapper;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Baskets.Commands
{
   public class GetOrCreateBasketForUserService : IGetOrCreateBasketForUserService
    {
        private readonly IDatabaseContext _dataBaseContxt;
        private readonly IMapper _mapper;
        public GetOrCreateBasketForUserService(IDatabaseContext dataBaseContxt,  IMapper mapper)
        {
            _dataBaseContxt = dataBaseContxt;
            _mapper = mapper;
        }
        public BasketDataModel GetOrCreateBasketForUser(string BuyerId)
        {
            try
            {
                var buyerIdBasket = _dataBaseContxt.Baskets
                                   .Include(p => p.BasketItems)
                                   .ThenInclude(p => p.CategoryItem)
                                   .ThenInclude(p => p.CategoryItemImage)
                                   .SingleOrDefault(p => p.BuyerId == BuyerId);

                if (buyerIdBasket == null)
                {
                    return CreateBasketForUser(BuyerId);
                }
                else
                {
                    var ResultBasket = _mapper.Map<BasketDataModel>(buyerIdBasket);
                    var ResultBasketItem = _mapper.Map<List<BasketItemDataModel>>(ResultBasket.Items);
                    ResultBasket.Items = ResultBasketItem;
                    return ResultBasket;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private BasketDataModel CreateBasketForUser(string buyerId)
        {
            Basket NewBasket = new Basket();
            NewBasket.BuyerId = buyerId;
            _dataBaseContxt.Baskets.Add(NewBasket);
            _dataBaseContxt.SaveChanges();
            return new BasketDataModel
            {
                BuyerId = buyerId,
                Id = NewBasket.Id
            };
        }
    }
}
