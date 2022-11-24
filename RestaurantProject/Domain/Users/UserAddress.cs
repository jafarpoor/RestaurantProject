using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    [Auditable]
    public class UserAddress
    {
        public int Id { get; set; }
        public string State { get;  set; }
        public string City { get;  set; }
        public string ZipCode { get;  set; }
        public string PostalAddress { get; set; }
        public string UserId { get;  set; }
        public string ReciverName { get;  set; }
    }
}
