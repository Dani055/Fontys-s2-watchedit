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
    public partial class MovieDetails : Form
    {
        private Movie movie = null;
        private bool isMovie = true;
        public MovieDetails(int id, bool ismovie)
        {
            InitializeComponent();
            isMovie = ismovie;
            try
            {
                if (!isMovie)
                {
                    movie = EpisodeService.GetEpisodeById(id);
                }
                else
                {
                    movie = MovieService.GetMovieById(id);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }

            HideUI();
            PopulateInfo();
        }
        private void HideUI()
        {
            if (!AuthClass.loggedUser.IsAdmin)
            {
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }
        }
        private void PopulateInfo()
        {
            if (movie != null)
            {
                lblName.Text = movie.Name;
                lblDesc.Text = movie.Description;
                lblActors.Text = movie.Actors;
                lblDuration.Text = movie.Duration.ToString();
                lblGenre.Text = movie.Genre;
                lblProdValue.Text = movie.Producer;
                lblYear.Text = movie.Year.ToString("yyyy");
                lblRating.Text = movie.Rating.ToString() + " / 5";
                if (movie.ImageUrl != null)
                {
                    pbPhoto.Load(movie.ImageUrl);
                }

            }
            else
            {
                MessageBox.Show("Movie not found!");
                this.Dispose();
            }
            if (!isMovie)
            {
                if (movie is Episode)
                {
                    lblName.Text = movie.Name + ": Season " + ((Episode)movie).SeasonNo + " - Episode " + ((Episode)movie).EpisodeNo;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MovieService.DeleteMovieOrEpisode(AuthClass.loggedUser, movie.Id))
                {
                    if (isMovie)
                    {
                        MessageHelper.ShowInfo("Movie deleted successfully!");
                    }
                    else
                    {
                        MessageHelper.ShowInfo("Episode deleted successfully!");
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditMovie em = new EditMovie(isMovie, movie);
            this.Hide();
            em.ShowDialog();
            this.Show();
            if (Utils.UpdateContent)
            {
                try
                {
                    if (!isMovie)
                    {
                        movie = EpisodeService.GetEpisodeById(movie.Id);
                    }
                    else
                    {
                        movie = MovieService.GetMovieById(movie.Id);
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError(ex.Message);
                }


                PopulateInfo();
            }
        }
    }
}
