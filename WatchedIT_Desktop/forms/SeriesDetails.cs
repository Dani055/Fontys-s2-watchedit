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
using WatchedIT_Desktop.user_controls;
using Microsoft.Extensions.DependencyInjection;
using ClassLibraries.interfaces;

namespace WatchedIT_Desktop.forms
{
    public partial class SeriesDetails : Form
    {
        private readonly IEpisodeService _episodeService;
        private Series series = null;
        private List<Episode> episodes = new List<Episode>();
        public SeriesDetails(int id)
        {
            InitializeComponent();
            _episodeService = Program.ServiceProvider.GetService<IEpisodeService>();
            PopulateInfo(id);
            HideUI();
        }
        private void HideUI()
        {
            if (!AuthClass.loggedUser.IsAdmin)
            {
                btnYeet.Visible = false;
                btnEdit.Visible = false;
                btnAddEpisode.Visible = false;
            }
        }
        private void PopulateInfo(int id)
        {
            try
            {
                series = SeriesService.GetSeriesById(id);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }

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
            else
            {
                MessageBox.Show("Series not found!");
                this.Dispose();
                return;
            }

            try
            {
                episodes = _episodeService.GetEpisodes(series.Id);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }
            
            flwEpisodes.Controls.Clear();
            if (episodes != null)
            {
                foreach (Episode episode in episodes)
                {
                    EpisodeCard card = new EpisodeCard(episode.Id, episode.Name, episode.SeasonNo, episode.EpisodeNo, this);
                    flwEpisodes.Controls.Add(card);
                }
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
            try
            {
                if (SeriesService.DeleteSeries(AuthClass.loggedUser, series.Id))
                {
                    MessageHelper.ShowInfo("Series deleted successfully!");
                    Utils.UpdateContent = true;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSeries es = new EditSeries(series);
            this.Hide();
            es.ShowDialog();
            this.Show();
            if (Utils.UpdateContent)
            {
                PopulateInfo(series.Id);
                Utils.UpdateContent = false;
            }
        }
    }
}
