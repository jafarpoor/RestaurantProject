﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
   public class UserAddress
    {
        public int Id { get; set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string UserId { get; private set; }
        public string ReciverName { get; private set; }
    }
}
