using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraries.interfaces
{
    public interface IDBSettings
    {
        public string GetConString();
        public string MovieTable();

        public string SeriesTable();

        public string ReviewTable();

        public string UserTable();

    }
}
