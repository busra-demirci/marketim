using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketim.Entity
{
    public class Customer : Base
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public int TownId { get; set; }
        public string Address { get; set; }
        public decimal Balance { get; set; }
    }
}
