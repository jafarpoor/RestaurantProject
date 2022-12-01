using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Baskets;
using Common.Helper;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application.Baskets.Commands
{
  public  class AddOrGetItemToBasketService : IAddOrGetItemToBasketService
    {
        private readonly IDatabaseContext _dataBaseContxt;

        public AddOrGetItemToBasketService(IDatabaseContext dataBaseContxt )
        {
            _dataBaseContxt = dataBaseContxt;
        }
        public ResultDataModel AddOrGetItemToBasket(int basketId, int catalogItemId, int Qty)
        {
            try
            {
                var BasketResult = _dataBaseContxt.Baskets.FirstOrDefault(p => p.Id == basketId);
                if (BasketResult == null)
                    return new ResultDataModel
                    {
                        IsSuccess = false,
                        Message = Messages.NullMassages
                    };

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
                return new ResultDataModel
                {
                    IsSuccess = true,
                    Message = Messages.Successed
                };
            }
            catch (Exception)
            {
                return new ResultDataModel
                {
                    IsSuccess = false,
                    Message = Messages.UnexpectedError
                };
                
            }
           
        }   

    }
}
