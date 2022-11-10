using Application.Baskets.DTO;
using Application.Interfaces;
using Application.Interfaces.Baskets;
using Application.UriComposer;
using AutoMapper;
using Common.Helper;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Baskets.Commands
{
  public  class BasketService : IBasketService
    {
        private readonly IDatabaseContext _dataBaseContxt;
        private readonly IUriComposerService _uriComposerService;
        private readonly IMapper _mapper;

        public BasketService(IDatabaseContext dataBaseContxt , IUriComposerService uriComposerService, IMapper mapper)
        {
            _dataBaseContxt = dataBaseContxt;
            _uriComposerService = uriComposerService;
            _mapper = mapper;
        }

        public void AddOrGetItemToBasket(int basketId, int catalogItemId, int Qty)
        {
            try
            {
                var BasketResult = _dataBaseContxt.Baskets.FirstOrDefault(p => p.Id == basketId);
                if (BasketResult == null)
                    throw new Exception(Messages.NotFund);

                var BasketItemResult = _dataBaseContxt.BasketItems
                                        .Include(p => p.Basket)
                                        .Where(p => p.Basket.Id == basketId && p.CategoryItemId == catalogItemId).FirstOrDefault();
                if (BasketItemResult != null)
                    BasketItemResult.Qty = Qty;

                else
                {
                    var CategoryResult = _dataBaseContxt.CategoryItems.FirstOrDefault(p => p.Id == catalogItemId);
                    BasketItem basketItem = new BasketItem()
                    {
                        Basket = BasketResult,
                        CategoryItem = CategoryResult,
                        Qty = Qty,
                        UnitPrice = CategoryResult.Price,
                    };
                    _dataBaseContxt.BasketItems.Add(basketItem);
                }
             
                _dataBaseContxt.SaveChanges();             
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int GetCountCategoryItems(string userId, int CategoryItem)
        {
            if(userId != null && CategoryItem != 0)
            {
                int Result = _dataBaseContxt.BasketItems
                           .Include(p => p.Basket)
                           .Where(p => p.Basket.BuyerId == userId && p.CategoryItemId == CategoryItem)
                           .Select(p => p.Qty).FirstOrDefault();

                return Result;
            }          
            return 0;

        }

        public BasketDataModel GetOrCreateBasketForUser(string BuyerId)
        {
            try
            {
                var buyerIdBasket = _dataBaseContxt.Baskets
                                   .Include(p => p.BasketItems)
                                   .ThenInclude(p => p.CategoryItem)
                                   .ThenInclude(p => p.CategoryItemImage)
                                   .Where(p => p.BuyerId == BuyerId).SingleOrDefault();

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

        public BasketDataModel GetBasketByBuyerId(string BuyerId)
        {
            try
            {
                var Result = _dataBaseContxt.Baskets
                                   .Include(p => p.BasketItems)
                                   .ThenInclude(p => p.CategoryItem)
                                   .ThenInclude(p => p.CategoryItemImage)
                                   .Where(p => p.BuyerId == BuyerId).SingleOrDefault();

                if (Result == null)
                    throw new Exception(Messages.NotFund);
                BasketDataModel BasketItemDto = new BasketDataModel()
                {
                    BuyerId = Result.BuyerId,
                    Id = Result.Id,
                    Items = Result.BasketItems.Select(p => new BasketItemDataModel
                    {
                        Id = p.Id,
                        CatalogName = p.CategoryItem.Name,
                        ImageUrl = _uriComposerService.ComposeImageUri(p.ImageUrl) ,
                        Qty = p.Qty,
                        UnitPrice = p.UnitPrice ,
                        TotalPrice = p.UnitPrice * p.Qty ,
                        CategoryItemId = p.CategoryItemId
                        
                    }).ToList()
                };
                    return BasketItemDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveBasketItem(int ItemId)
        {
            try
            {
                var Result = _dataBaseContxt.BasketItems.SingleOrDefault(p => p.Id == ItemId);
                if (Result == null)
                    throw new Exception(Messages.NotFund);
                _dataBaseContxt.BasketItems.Remove(Result);
                _dataBaseContxt.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public void TransferBasket(string anonymousId, string UserId)
        {
            var anonymousBasket = _dataBaseContxt.Baskets
             .Include(p => p.BasketItems)
             .SingleOrDefault(p => p.BuyerId == anonymousId);

            if (anonymousBasket == null) return;

            var userBasket = _dataBaseContxt.Baskets.SingleOrDefault(p => p.BuyerId == UserId);
            if (userBasket == null)
            {
                userBasket = new Basket() { BuyerId = UserId};

                _dataBaseContxt.Baskets.Add(userBasket);
            }
            List<BasketItem> basketItemsList = new List<BasketItem>();
            foreach (var item in anonymousBasket.BasketItems)
            {
                BasketItem basketItem = new BasketItem()
                {
                    CategoryItemId = item.CategoryItemId,
                    Qty = item.Qty,
                    UnitPrice = item.UnitPrice
                };
                basketItemsList.Add(basketItem);
              
            }
            userBasket.BasketItems = basketItemsList;
            //if (anonymousBasket.DiscountAmount != null)
            //{
            //    userBasket.ApplyDiscountCode(anonymousBasket.AppliedDiscount);
            //}
            _dataBaseContxt.Baskets.Remove(anonymousBasket);

            _dataBaseContxt.SaveChanges();
        }
    }
}
