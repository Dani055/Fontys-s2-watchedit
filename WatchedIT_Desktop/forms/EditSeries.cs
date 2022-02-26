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
using WatchedIT_Desktop.logic.models;
using WatchedIT_Desktop.logic.services;

namespace WatchedIT_Desktop.forms
{
    public partial class EditSeries : Form
    {
        private Series loadedSeries;
        public EditSeries(Series s)
        {
            InitializeComponent();
            loadedSeries = s;
            LoadInfo();
        }
        private void LoadInfo()
        {
            tbName.Text = loadedSeries.Name;
            tbYear.Text = loadedSeries.Year.ToString("yyyy-MM-dd");
            tbUrl.Text = loadedSeries.ImageUrl;
            tbDesc.Text = loadedSeries.Description;
            tbGenre.Text = loadedSeries.Genre;
            tbProd.Text = loadedSeries.Producer;
            tbActors.Text = loadedSeries.Actors;
        }
        private void btnEditSeries_Click(object sender, EventArgs e)
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

            if (SeriesService.EditSeries(loadedSeries.Id, name, year, url, genre, desc, actors, producers))
            {
                Utils.UpdateContent = true;
                this.Dispose();
            }
            
        }
    }
}
