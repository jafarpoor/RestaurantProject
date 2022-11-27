using System;

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
