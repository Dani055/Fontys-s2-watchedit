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
using WatchedIT_Desktop.user_controls;

namespace WatchedIT_Desktop.forms
{
    public partial class SeriesDetails : Form
    {
        private Series series = null;
        private List<Episode> episodes = new List<Episode>();
        public SeriesDetails(int id)
        {
            InitializeComponent();
            PopulateInfo(id);
        }
        private void PopulateInfo(int id)
        {
            series = SeriesService.GetSeriesById(id);
            episodes = EpisodeService.GetEpisodes(series.Id);
            if (series != null)
            {
                lblName.Text = series.Name;
                lblDesc.Text = series.Description;
                lblActors.Text = series.Actors;
                lblGenre.Text = series.Genre;
                lblProdValue.Text = series.Producer;
                lblYear.Text = series.Year.ToString("yyyy");
                if (series.ImageUrl != null)
                {
                    pbPhoto.Load(series.ImageUrl);
                }
            }
            flwEpisodes.Controls.Clear();
            foreach (Episode episode in episodes)
            {
                EpisodeCard card = new EpisodeCard(episode.Id, episode.Name, episode.SeasonNo, episode.EpisodeNo, this);
                flwEpisodes.Controls.Add(card);
            }
        }

        private void btnAddEpisode_Click(object sender, EventArgs e)
        {
            AddMovie am = new AddMovie(false, series.Id);
            am.ShowDialog();
            if (Utils.UpdateContent)
            {
                PopulateInfo(series.Id);
                Utils.UpdateContent = false;
            }
        }

        public void goToEpisodeDetails(int id)
        {
            MovieDetails md = new MovieDetails(id, false);
            md.ShowDialog();
            if (Utils.UpdateContent)
            {
                PopulateInfo(series.Id);
                Utils.UpdateContent = false;
            }
        }

        private void btnYeet_Click(object sender, EventArgs e)
        {
            SeriesService.DeleteSeries(series.Id);
            Utils.UpdateContent = true;
            this.Dispose();
        }
    }
}
