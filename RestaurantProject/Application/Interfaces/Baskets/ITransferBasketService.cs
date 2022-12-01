

using Application.DTO;

namespace Application.Interfaces.Baskets
{
  public  interface ITransferBasketService
    {
        ResultDataModel TransferBasket(string anonymousId, string UserId);
    }
}
