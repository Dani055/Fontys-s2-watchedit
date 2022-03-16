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
    public partial class EditMovie : Form
    {
        private bool isMovie = true;
        private Movie movie = null;
        public EditMovie(bool isMovie, Movie movie)
        {
            InitializeComponent();
            this.isMovie = isMovie;
            this.movie = movie;
            HideUI();
            LoadInfo();
        }
        private void HideUI()
        {
            if (isMovie)
            {
                lblSeason.Visible = false;
                lblEpisode.Visible = false;
                tbEpisode.Visible = false;
                tbSeason.Visible = false;
            }
            else
            {
                lblEditMovie.Text = "Edit episode";
                btnEditMovie.Text = "Edit episode";

            }
        }
        private void LoadInfo()
        {
            tbName.Text = movie.Name;
            tbYear.Text = movie.Year.ToString("yyyy-MM-dd");
            tbUrl.Text = movie.ImageUrl;
            tbGenre.Text = movie.Genre;
            tbProd.Text = movie.Producer;
            tbDesc.Text = movie.Description;
            tbActors.Text = movie.Actors;
            tbDuration.Text = movie.Duration.ToString();
            if (movie is Episode)
            {
                tbSeason.Value = ((Episode)movie).SeasonNo;
                tbEpisode.Value = ((Episode)movie).EpisodeNo;
            }
        }

        private void btnEditMovie_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string yearStr = tbYear.Text;
            string url = tbUrl.Text;
            string genre = tbGenre.Text.Trim();
            string producers = tbProd.Text.Trim();
            string desc = tbDesc.Text.Trim();
            string actors = tbActors.Text.Trim();
            string durationStr = tbDuration.Text;

            int season = 0;
            int episode = 0;

            if (!isMovie)
            {
                season = Convert.ToInt32(tbSeason.Value);
                episode = Convert.ToInt32(tbEpisode.Value);
            }

            try
            {
                if (MovieService.EditMovieOrEpisode(movie.Id, name, yearStr, url, genre, producers, desc, actors, durationStr, isMovie, season, episode))
                {
                    if (isMovie)
                    {
                        MessageHelper.ShowInfo("Movie edited successfully!");
                    }
                    else
                    {
                        MessageHelper.ShowInfo("Episode edited successfully!");
                    }
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
