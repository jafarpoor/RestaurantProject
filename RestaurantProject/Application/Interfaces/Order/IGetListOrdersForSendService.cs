using Application.DTO;
using Application.Orders.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Order
{
    public interface IGetListOrdersForSendService
    {
        ResultDataModel<List<GetListOrdersForSendDataModel>> GetList(string OrderStatus);
    }
}
