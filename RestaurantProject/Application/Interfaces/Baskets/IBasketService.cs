using Application.Baskets.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Baskets
{
   public interface IBasketService
    {
        BasketDataModel GetOrCreateBasketForUser(string BuyerId);
        void AddOrGetItemToBasket(int basketId, int catalogItemId, int Qty = 1);
        int GetCountCategoryItems(string userId , int CategoryItem);
        BasketDataModel GetBasketByBuyerId(string BuyerId);
        bool RemoveBasketItem(int ItemId);
        void TransferBasket(string anonymousId, string UserId);
    }
}
