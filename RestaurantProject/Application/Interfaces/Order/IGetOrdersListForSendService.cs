using Application.DTO;
using Application.Orders.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Order
{
  public  interface IGetOrdersListForSendService
    {
        ResultDataModel<List<GetListOrderForSendDataModel>> GetResultData();
    }
}
