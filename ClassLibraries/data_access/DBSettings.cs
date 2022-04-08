using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.interfaces;

namespace ClassLibraries.data_access
{
    public class DBSettings : IDBSettings
    {
        private string conString = "server=studmysql01.fhict.local;database=dbi476740;uid=dbi476740;password=123rty;";
        public string GetConString()
        {
            return conString;
        }
    }
}
