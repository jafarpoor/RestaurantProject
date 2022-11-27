using Application.Baskets.DTO;

namespace Application.Interfaces.Baskets
{
   public interface IGetOrCreateBasketForUserService
    {
        BasketDataModel GetOrCreateBasketForUser(string BuyerId);
    }
}
