
namespace Application.Interfaces.Baskets
{
   public interface IAddOrGetItemToBasketService
    {
        void AddOrGetItemToBasket(int basketId, int catalogItemId, int Qty = 1);
 
    }
}
