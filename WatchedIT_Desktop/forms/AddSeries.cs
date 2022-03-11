using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraries;
using ClassLibraries.models;
using ClassLibraries.services;

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
            string genre = tbGenre.Text.Trim();
            string producers = tbProd.Text.Trim();
            string desc = tbDesc.Text.Trim();
            string actors = tbActors.Text.Trim();

            try
            {
                if (SeriesService.AddSeries(name, year, url, genre, desc, actors, producers))
                {
                    MessageHelper.ShowInfo("Series added successfully!");
                    Utils.UpdateContent = true;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }


        }
    }
}
