using Domain.Attributes;
using Domain.BaseEntities;

namespace Domain.Users
{
    [Auditable]
    public class UserAddress : BaseEntity
    {
        public string State { get;  set; }
        public string City { get;  set; }
        public string ZipCode { get;  set; }
        public string PostalAddress { get; set; }
        public string UserId { get;  set; }
        public string ReciverName { get;  set; }
    }
}
