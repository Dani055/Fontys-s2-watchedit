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
using WatchedIT_Desktop.user_controls;

namespace WatchedIT_Desktop.forms
{
    public partial class Home : Form
    {
        private List<Movie> movies = new List<Movie>();
        private List<Series> series = new List<Series>();
        bool closedByButton = false;
        string currentlyShowing = "Movies";

        public Home()
        {
            InitializeComponent();
            lblRole.Text = UserService.loggedUser.Username;
            lblUsername.Text = UserService.loggedUser.IsAdmin.ToString();
            GetMovies();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserService.loggedUser = null;
            closedByButton = true;
            this.Dispose();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closedByButton)
            {
                this.Close();
            }
            else
            {
                Application.Exit();
            }
        }
        private void GetMovies()
        {
            movies = MovieService.GetMovies();
            flowLayoutPanel1.Controls.Clear();
            foreach (Movie movie in movies)
            {
                MovieCard card = new MovieCard(movie.Id, movie.ImageUrl, movie.Name, this, true);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private void GetSeries()
        {
            series = SeriesService.GetSeries();
            flowLayoutPanel1.Controls.Clear();
            foreach (Series s in series)
            {
                MovieCard card = new MovieCard(s.Id, s.ImageUrl, s.Name, this, false);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        public void GoToMovieDetails(int id)
        {
            MovieDetails md = new MovieDetails(id);
            this.Hide();
            md.ShowDialog();
            this.Show();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            AddMovie am = new AddMovie();
            this.Hide();
            am.ShowDialog();
            this.Show();
        }

        private void btnAddSeries_Click(object sender, EventArgs e)
        {
            AddSeries addseries = new AddSeries();
            this.Hide();
            addseries.ShowDialog();
            this.Show();
        }

        private void btnShowMovies_Click(object sender, EventArgs e)
        {
            if (currentlyShowing != "Movies")
            {
                currentlyShowing = "Movies";
                GetMovies();
            }
        }

        private void btnShowSeries_Click(object sender, EventArgs e)
        {
            if (currentlyShowing != "Series")
            {
                currentlyShowing = "Series";
                GetSeries();
            }
        }
    }
}
