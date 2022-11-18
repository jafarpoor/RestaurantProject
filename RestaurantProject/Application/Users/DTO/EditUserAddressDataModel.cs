using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DTO
{
  public  class EditUserAddressDataModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PostalAddress { get; set; }
        public string ReciverName { get; set; }
    }
}
