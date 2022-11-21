using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helper
{
 public static  class CreatOrderCode
    {
        public static string GetOrderCode()
        {
            Random rn = new Random();
            var OrderNumber = rn.Next(1000, 9999);
            return ("RGB-" + OrderNumber);

        }
    }
}
