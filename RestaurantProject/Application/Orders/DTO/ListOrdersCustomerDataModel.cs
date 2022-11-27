
namespace Application.Orders.DTO
{
    public class ListOrdersCustomerDataModel
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public string OrderStatus { get; set; }

        public int PaymentAmount { get; set; }

       public string PaymentDataTime {  get; set; }
    }
}
