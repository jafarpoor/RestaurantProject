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
  public  class AddOrGetItemToBasketService : IAddOrGetItemToBasketService
    {
        private readonly IDatabaseContext _dataBaseContxt;

        public AddOrGetItemToBasketService(IDatabaseContext dataBaseContxt )
        {
            _dataBaseContxt = dataBaseContxt;
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
  

      

    }
}
