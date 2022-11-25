using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Baskets
{
  public  interface IBasketFacade
    {
        IAddOrGetItemToBasketService basketService { get; }

        IGetCountCategoryItemsService getCountCategoryItemsService { get; }

        IGetBasketByBuyerIdService getBasketByBuyerIdService { get; }

        ITransferBasketService transferBasketService { get; }

        IRemoveBasketItemService removeBasketItemService { get; }

        IGetOrCreateBasketForUserService  getOrCreateBasketForUserService { get; }

        IAddOrGetItemToBasketService addOrGetItemToBasketService { get; }
    }
}
