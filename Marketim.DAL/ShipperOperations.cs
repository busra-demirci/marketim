using Marketim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketim.DAL
{
    public class ShipperOperations : BaseOperation, IDbOperation<Shipper>
    {
        public int Delete(int id, int deletedBy)
        {
            throw new NotImplementedException();
        }

        public List<Shipper> List()
        {
            throw new NotImplementedException();
        }

        public int Save(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Shipper entity)
        {
            throw new NotImplementedException();
        }
    }
}
