using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseADORepository
    {
        protected readonly string _connStr;

        public BaseADORepository()
        {
            _connStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }

    }

}
