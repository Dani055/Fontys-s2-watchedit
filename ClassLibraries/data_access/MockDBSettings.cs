using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.interfaces;

namespace ClassLibraries.data_access
{
    public class MockDBSettings : IDBSettings
    {
        private string conString = "server=studmysql01.fhict.local;database=dbi476740;uid=dbi476740;password=123rty;";
        private string movieTable = "mock_movie";
        private string seriesTable = "mock_series";
        private string reviewTable = "mock_review";
        private string userTable = "mock_user";

        public string GetConString()
        {
            return conString;
        }
        public string MovieTable()
        {
            return movieTable;
        }
        public string SeriesTable()
        {
            return seriesTable;
        }
        public string ReviewTable()
        {
            return reviewTable;
        }
        public string UserTable()
        {
            return userTable;
        }
    }
}
