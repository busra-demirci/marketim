using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketim.DAL
{
    //Generic Interface
    public interface IDbOperation<T> where T : class
    {
        List<T> List();
        int Save(T entity);
        int Update(T entity);
        int Delete(int id, int deletedBy);
    }
}
