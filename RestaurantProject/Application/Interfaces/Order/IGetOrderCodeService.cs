
using Application.DTO;

namespace Application.Interfaces.Order
{
   public interface IGetOrderCodeService
    {
        ResultDataModel<string> GetCode(int OrderId);
    }
}
