using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketim.Entity
{
    public class Position
    {
        public short PositionId { get; set; }
        public string PositionName { get; set; }
        public byte DepartmentId { get; set; }
    }
}
