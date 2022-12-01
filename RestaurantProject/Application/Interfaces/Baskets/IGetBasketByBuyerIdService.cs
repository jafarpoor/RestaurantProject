using Application.Baskets.DTO;
using Application.DTO;

namespace Application.Interfaces.Baskets
{
  public  interface IGetBasketByBuyerIdService
    {
       ResultDataModel<BasketDataModel> GetBasketByBuyerId(string BuyerId);
    }
}
