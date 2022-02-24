using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchedIT_Desktop.logic.models;
using WatchedIT_Desktop.logic.services;

namespace WatchedIT_Desktop.forms
{
    public partial class SeriesDetails : Form
    {
        private Series series = null;
        public SeriesDetails(int id)
        {
            InitializeComponent();
            series = SeriesService.GetSeriesById(id);
            PopulateInfo();
        }
        private void PopulateInfo()
        {
            if (series != null)
            {
                lblName.Text = series.Name;
                lblDesc.Text = series.Description;
                lblActors.Text = series.Actors;
                lblGenre.Text = series.Genre;
                lblProdValue.Text = series.Producer;
                lblYear.Text = series.Year.ToString("yyyy");
                pbPhoto.Load(series.ImageUrl);
            }
        }
    }
}
