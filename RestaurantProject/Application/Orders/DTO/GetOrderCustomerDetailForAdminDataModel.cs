using System.Collections.Generic;
using System.ComponentModel;

namespace Application.Orders.DTO
{
 public   class GetOrderCustomerDetailForAdminDataModel
    {
        [DisplayName("نام کاربر")]
        public string UserName { get; set; }
        [DisplayName("ادرس")]
        public string Address { get; set; }
        [DisplayName("شماره تلفن")]
        public string PhoneNumber { get; set;  }

        public List<OrderDetailForAdminDataModel> orderDetailForAdminDataModels { get; set; } = new();

    }
}
