
namespace Application.Interfaces.Order
{
   public interface IOrderFacade
    {
        ICreatOrderService creatOrderService { get; }
        IGetOrdersCustomerService getOrdersCustomer { get; }
        IGetOrderCodeService getOrderCoedService { get; }
        IGetListAllOrderService getListAllOrderService { get; }

        IGetOrderCustomerDetailForAdminService  getOrderCustomerDetailForAdminService { get; }
        IGetOrderCustomerDetailForUserService getOrderCustomerDetailForUserService { get; }

        IGetOrdersListForSendService getOrdersListForSendService { get; }
    }
}
