using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketim.Entity
{
    public class Product : Base
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public byte CategoryId { get; set; }
        public byte UnitId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
