using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchedIT_Desktop.logic;
using WatchedIT_Desktop.logic.services;

namespace WatchedIT_Desktop.forms
{
    public partial class AddSeries : Form
    {
        public AddSeries()
        {
            InitializeComponent();
        }

        private void btnAddSeries_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            DateTime year;
            bool s = DateTime.TryParse(tbYear.Text, out year);
            if (!s)
            {
                MessageBox.Show("Date not in correct format");
                return;
            }
            string url = tbUrl.Text;
            string genre = tbGenre.Text;
            string producers = tbProd.Text;
            string desc = tbDesc.Text;
            string actors = tbActors.Text;
            SeriesService.AddSeries(name, year, url, genre, desc, actors, producers);
            Utils.UpdateContent = true;
        }
    }
}
