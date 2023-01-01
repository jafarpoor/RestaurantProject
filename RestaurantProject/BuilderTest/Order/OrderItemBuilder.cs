using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builders.Order
{
    public class OrderItemBuilder
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Units { get; set; }
    }
}
