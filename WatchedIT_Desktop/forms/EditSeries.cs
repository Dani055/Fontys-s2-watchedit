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
            string yearStr = tbYear.Text;
            string url = tbUrl.Text;
            string genre = tbGenre.Text.Trim();
            string producers = tbProd.Text.Trim();
            string desc = tbDesc.Text.Trim();
            string actors = tbActors.Text.Trim();

            try
            {
                if (SeriesService.EditSeries(loadedSeries.Id, name, yearStr, url, genre, desc, actors, producers))
                {
                    MessageHelper.ShowInfo("Series edited successfully!");
                    Utils.UpdateContent = true;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }

            
        }
    }
}
