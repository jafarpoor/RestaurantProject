using Application.Baskets.DTO;
using Application.DTO;

namespace Application.Interfaces.Baskets
{
   public interface IGetOrCreateBasketForUserService
    {
        ResultDataModel<BasketDataModel> GetOrCreateBasketForUser(string BuyerId);
    }
}
