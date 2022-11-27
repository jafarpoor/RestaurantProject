using Application.Interfaces;
using Application.Interfaces.Baskets;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Baskets.Commands
{
    public class TransferBasketService : ITransferBasketService
    {
        private readonly IDatabaseContext _dataBaseContxt;

        public TransferBasketService(IDatabaseContext dataBaseContxt)
        {
            _dataBaseContxt = dataBaseContxt;
        }
        public void TransferBasket(string anonymousId, string UserId)
        {
            var anonymousBasket = _dataBaseContxt.Baskets
                                  .Include(p => p.BasketItems)
                                  .ThenInclude(p => p.CategoryItem)
                                  .SingleOrDefault(p => p.BuyerId == anonymousId);

            if (anonymousBasket == null) return;

            var userBasket = _dataBaseContxt.Baskets
                            .Include(p => p.BasketItems)
                             .SingleOrDefault(p => p.BuyerId == UserId);
            if (userBasket == null)
            {
                userBasket = new Basket() { BuyerId = UserId };

                _dataBaseContxt.Baskets.Add(userBasket);
            }

            if (userBasket.BasketItems != null && userBasket.BasketItems.Count != 0)
            {
                int[] categoryResultId = userBasket.BasketItems.Select(p => p.CategoryItemId).ToArray();
                var ResultAnonymous = anonymousBasket.BasketItems.Where(t => categoryResultId.Contains(t.CategoryItemId));
                if (ResultAnonymous != null)
                    foreach (var item in ResultAnonymous)
                    {
                        var BaskItem = userBasket.BasketItems
                                             .SingleOrDefault(p => p.CategoryItemId == item.CategoryItemId);

                        var AnonymousItemCount = item.Qty;

                        var ResultCountBasktItem = AnonymousItemCount + BaskItem.Qty;

                        userBasket.BasketItems.SingleOrDefault(p => p.Id == BaskItem.Id).Qty = ResultCountBasktItem;
                    }
            }

            else
            {
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
            }

            //if (anonymousBasket.DiscountAmount != null)
            //{
            //    userBasket.ApplyDiscountCode(anonymousBasket.AppliedDiscount);
            //}
            _dataBaseContxt.Baskets.Remove(anonymousBasket);

            _dataBaseContxt.SaveChanges();
        }
    }
}
