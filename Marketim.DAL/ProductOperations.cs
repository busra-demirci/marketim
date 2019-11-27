using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketim.Entity;

namespace Marketim.DAL
{
    public class ProductOperations : IDbOperation<Product>
    {
        public int Delete(int id, int deletedBy)
        {
            throw new NotImplementedException();
        }

        public List<Product> List()
        {
            throw new NotImplementedException();
        }

        public int Save(Product entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
