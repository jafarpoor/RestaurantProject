using Application.DTO;
using Application.Orders.DTO;
using System.Collections.Generic;

namespace Application.Interfaces.Order
{
    public interface IGetListAllOrderService
    {
        ResultDataModel<List<GetListAllOrderDataModel>> GetList(string OrderStatus);
    }
}
