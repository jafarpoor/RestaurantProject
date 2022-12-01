
using Application.DTO;

namespace Application.Interfaces.Payments
{
  public  interface IReciveToCustomerService
    {
        ResultDataModel ChangeStatus(int OrderId);
    }
}
