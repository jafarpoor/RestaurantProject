using Application.Baskets.DTO;

namespace Application.Interfaces.Baskets
{
  public  interface IGetBasketByBuyerIdService
    {
        BasketDataModel GetBasketByBuyerId(string BuyerId);
    }
}
