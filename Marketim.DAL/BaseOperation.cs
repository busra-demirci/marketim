using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketim.DAL
{
    public abstract class BaseOperation : IDisposable
    {
        public string MarketimConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MarketimConnectionString"].ConnectionString;
                //return ConfigurationManager.AppSettings["MarketimConnectionString"];
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
