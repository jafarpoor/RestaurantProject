
namespace Application.Interfaces.Order
{
   public interface IOrderFacade
    {
        ICreatOrderService creatOrderService { get; }
        IGetOrdersCustomerService getOrdersCustomer { get; }
        IGetOrderCodeService getOrderCoedService { get; }
        IGetListOrdersForSendService getListOrdersForSendService { get; }

        IGetOrderCustomerDetailForAdminService  getOrderCustomerDetailForAdminService { get; }
        IGetOrderCustomerDetailForUserService getOrderCustomerDetailForUserService { get; }
    }
}
