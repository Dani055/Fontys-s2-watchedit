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
    public partial class MovieDetails : Form
    {
        private Movie movie = null;
        public MovieDetails(int id)
        {
            InitializeComponent();
            movie = MovieService.GetMovieById(id);
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
                lblYear.Text = movie.Year.ToString("YYYY");
                pbPhoto.Load(movie.ImageUrl);
            }
        }
    }
}
