using Application.Orders.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Order
{
    public interface IGetListOrdersForSendService
    {
        List<GetListOrdersForSendDataModel> GetList();
    }
}
