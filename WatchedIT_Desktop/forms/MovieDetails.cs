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
    public partial class MovieDetails : Form
    {
        private Movie movie = null;
        private bool isMovie = true;
        public MovieDetails(int id, bool ismovie)
        {
            InitializeComponent();
            isMovie = ismovie;
            if (!isMovie)
            {
                movie = EpisodeService.GetEpisodeById(id);
            }
            else
            {
                movie = MovieService.GetMovieById(id);
            }

            PopulateInfo();
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
                if (movie.ImageUrl != null)
                {
                    pbPhoto.Load(movie.ImageUrl);
                }

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
            MovieService.DeleteMovieOrEpisode(movie.Id);
            Utils.UpdateContent = true;
            this.Dispose();
        }
    }
}
