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
    public partial class Home : Form
    {
        private List<Movie> movies = new List<Movie>();
        private List<Series> series = new List<Series>();
        bool closedByButton = false;
        string currentlyShowing = "Movies";

        public Home()
        {
            InitializeComponent();
            lblUsername.Text = "Welcome, " + UserService.loggedUser.Username;
            GetMovies();
            HideUI();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserService.loggedUser = null;
            closedByButton = true;
            this.Dispose();
        }
        private void HideUI()
        {
            if (!UserService.loggedUser.IsAdmin)
            {
                btnAddSeries.Visible = false;
                btnAddMovie.Visible = false;
            }
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
            movies = MovieService.GetMovies(0);
            flowLayoutPanel1.Controls.Clear();
            foreach (Movie movie in movies)
            {
                MovieCard card = new MovieCard(movie.Id, movie.ImageUrl, movie.Name, this, true);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private void SearchMovies(string keyword)
        {
            movies = MovieService.SearchMovies(keyword);
            flowLayoutPanel1.Controls.Clear();
            foreach (Movie movie in movies)
            {
                MovieCard card = new MovieCard(movie.Id, movie.ImageUrl, movie.Name, this, true);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private void GetMoreMovies()
        {
            if (tbSearch.Text != "")
            {
                return;
            }
            List<Movie> loadedMovies = MovieService.GetMovies(movies.Count);
            foreach (Movie m in loadedMovies)
            {
                movies.Add(m);
            }
            foreach (Movie movie in loadedMovies)
            {
                MovieCard card = new MovieCard(movie.Id, movie.ImageUrl, movie.Name, this, true);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private void GetSeries()
        {
            series = SeriesService.GetSeries(0);
            flowLayoutPanel1.Controls.Clear();
            foreach (Series s in series)
            {
                MovieCard card = new MovieCard(s.Id, s.ImageUrl, s.Name, this, false);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private void GetMoreSeries()
        {
            if (tbSearch.Text != "")
            {
                return;
            }
            List<Series> loadedSeries = SeriesService.GetSeries(series.Count);
            foreach (Series s in loadedSeries)
            {
                series.Add(s);
            }
            foreach (Series s in loadedSeries)
            {
                MovieCard card = new MovieCard(s.Id, s.ImageUrl, s.Name, this, false);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private void SearchSeries(string keyword)
        {
            series = SeriesService.SearchSeries(keyword);
            flowLayoutPanel1.Controls.Clear();
            foreach (Series s in series)
            {
                MovieCard card = new MovieCard(s.Id, s.ImageUrl, s.Name, this, false);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        public void GoToMovieDetails(int id)
        {
            MovieDetails md = new MovieDetails(id, true);
            this.Hide();
            md.ShowDialog();
            this.Show();
            if (Utils.UpdateContent)
            {
                GetMovies();
                Utils.UpdateContent = false;
            }
        }
        public void GoToSeriesDetails(int id)
        {
            SeriesDetails sd = new SeriesDetails(id);
            this.Hide();
            sd.ShowDialog();
            this.Show();
            if (Utils.UpdateContent)
            {
                GetSeries();
                Utils.UpdateContent = false;
            }

        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            AddMovie am = new AddMovie();
            this.Hide();
            am.ShowDialog();
            this.Show();
            if (Utils.UpdateContent)
            {
                currentlyShowing = "Movies";
                this.GetMovies();
                Utils.UpdateContent = false;
            }
        }

        private void btnAddSeries_Click(object sender, EventArgs e)
        {
            AddSeries addseries = new AddSeries();
            this.Hide();
            addseries.ShowDialog();
            this.Show();
            if (Utils.UpdateContent)
            {
                currentlyShowing = "Series";
                this.GetSeries();
                Utils.UpdateContent = false;
            }
        }

        private void btnShowMovies_Click(object sender, EventArgs e)
        {
            if (currentlyShowing != "Movies")
            {
                currentlyShowing = "Movies";
                movies.Clear();
                GetMovies();
            }
        }

        private void btnShowSeries_Click(object sender, EventArgs e)
        {
            if (currentlyShowing != "Series")
            {
                currentlyShowing = "Series";
                series.Clear();
                GetSeries();
            }
        }

        private void lblLoadMore_Click(object sender, EventArgs e)
        {
            if (currentlyShowing == "Movies")
            {
                GetMoreMovies();
            }
            else
            {
                GetMoreSeries();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = tbSearch.Text.Trim();
            if (currentlyShowing == "Movies")
            {
                SearchMovies(keyword);
            }
            else
            {
                SearchSeries(keyword);
            }
        }
    }
}
