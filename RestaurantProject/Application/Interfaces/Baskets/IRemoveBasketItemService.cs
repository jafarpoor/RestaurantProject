

using Application.DTO;

namespace Application.Interfaces.Baskets
{
   public interface IRemoveBasketItemService
    {
        ResultDataModel RemoveBasketItem(int ItemId);
    }
}
