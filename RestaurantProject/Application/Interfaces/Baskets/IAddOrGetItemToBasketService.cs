
using Application.DTO;

namespace Application.Interfaces.Baskets
{
   public interface IAddOrGetItemToBasketService
    {
        ResultDataModel AddOrGetItemToBasket(int basketId, int catalogItemId, int Qty = 1);
 
    }
}
