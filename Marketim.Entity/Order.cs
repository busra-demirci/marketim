using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketim.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ShipperId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Freight { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte RecordStatusId { get; set; }
    }
}
