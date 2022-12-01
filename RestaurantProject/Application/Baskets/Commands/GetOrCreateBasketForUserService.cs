using Application.Baskets.DTO;
using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Baskets;
using AutoMapper;
using Common.Helper;
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
        public GetOrCreateBasketForUserService(IDatabaseContext dataBaseContxt, IMapper mapper)
        {
            _dataBaseContxt = dataBaseContxt;
            _mapper = mapper;
        }
        public ResultDataModel<BasketDataModel> GetOrCreateBasketForUser(string BuyerId)
        {
            try
            {
                BasketDataModel basketDataModel = new BasketDataModel();
                var buyerIdBasket = _dataBaseContxt.Baskets
                                   .Include(p => p.BasketItems)
                                   .ThenInclude(p => p.CategoryItem)
                                   .ThenInclude(p => p.CategoryItemImage)
                                   .SingleOrDefault(p => p.BuyerId == BuyerId);

                if (buyerIdBasket == null)
                {
                    basketDataModel = CreateBasketForUser(BuyerId);
                }
                else
                {
                    var ResultBasket = _mapper.Map<BasketDataModel>(buyerIdBasket);
                    var ResultBasketItem = _mapper.Map<List<BasketItemDataModel>>(ResultBasket.Items);
                    ResultBasket.Items = ResultBasketItem;
                    basketDataModel = ResultBasket;
                }

                return new ResultDataModel<BasketDataModel>
                {
                    Data = basketDataModel,
                    IsSuccess = true,
                    Message = Messages.Successed
                };
            }
            catch (Exception)
            {

                return new ResultDataModel<BasketDataModel>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = Messages.UnexpectedError
                };
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
