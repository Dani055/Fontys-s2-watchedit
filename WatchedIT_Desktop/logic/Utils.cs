using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchedIT_Desktop.logic
{
    public static class Utils
    {
        public static string conString { get; } = "server=studmysql01.fhict.local;database=dbi476740;uid=dbi476740;password=123rty;";
        public static bool UpdateContent { get; set; } = false;

        public static void ShowError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(string text)
        {
            MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
