
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
