using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketim.Entity
{
    public class Employee : Base
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public short PositionId { get; set; }
        public decimal Salary { get; set; }

        public string PositionName { get; set; }
        public string RecordStatusName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
    }
}
