﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraries;
using ClassLibraries.interfaces;
using ClassLibraries.models;
using ClassLibraries.services;
using WatchedIT_Desktop.user_controls;
using Microsoft.Extensions.DependencyInjection;

namespace WatchedIT_Desktop.forms
{
    public partial class Home : Form
    {
        private readonly IMovieService _movieService;
        private List<Movie> movies = new List<Movie>();
        private List<Series> series = new List<Series>();
        bool closedByButton = false;
        bool filterApplied = false;
        string currentlyShowing = "Movies";

        public Home()
        {
            InitializeComponent();
            _movieService = Program.ServiceProvider.GetService<IMovieService>();
            
            lblUsername.Text = "Welcome, " + AuthClass.loggedUser.Username;
            GetMovies();
            HideUI();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuthClass.loggedUser = null;
            closedByButton = true;
            this.Dispose();
        }
        private void HideUI()
        {
            if (!AuthClass.loggedUser.IsAdmin)
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
            try
            {
                movies = _movieService.GetMovies(0);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }
            flowLayoutPanel1.Controls.Clear();
            DisplayMovies();
        }
        private void FilterMovies(string keyword, int yearMin, int yearMax, int ratingMin, int ratingMax, string genre, string sort)
        {
            try
            {
                movies = _movieService.FilterMovies(keyword, yearMin, yearMax, ratingMin, ratingMax, genre, sort);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }
            flowLayoutPanel1.Controls.Clear();
            DisplayMovies();
        }
        private void GetMoreMovies()
        {
            try
            {
                List<Movie> loadedMovies = _movieService.GetMovies(movies.Count);

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
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }

        }
        private void DisplayMovies()
        {
            if (movies != null)
            {
                foreach (Movie movie in movies)
                {
                    MovieCard card = new MovieCard(movie.Id, movie.ImageUrl, movie.Name, this, true);
                    flowLayoutPanel1.Controls.Add(card);
                }
            }
        }
        private void GetSeries()
        {
            try
            {
                series = SeriesService.GetSeries(0);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }

            flowLayoutPanel1.Controls.Clear();
            DisplaySeries();
        }
        private void GetMoreSeries()
        {

            try
            {
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
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }

        }
        private void FilterSeries(string keyword, int yearMin, int yearMax, string genre, string sort)
        {
            try
            {
                series = SeriesService.FilterSeries(keyword, yearMin, yearMax, genre, sort);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }
            
            flowLayoutPanel1.Controls.Clear();
            DisplaySeries();
        }
        private void DisplaySeries()
        {
            if (series != null)
            {
                foreach (Series s in series)
                {
                    MovieCard card = new MovieCard(s.Id, s.ImageUrl, s.Name, this, false);
                    flowLayoutPanel1.Controls.Add(card);
                }
            }
        }
        public void GoToMovieDetails(int id)
        {
            MovieDetails md = new MovieDetails(id, true);
            this.Hide();
            if (!md.IsDisposed)
            {
                md.ShowDialog();
            }
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
            if (!sd.IsDisposed)
            {
                sd.ShowDialog();
            }
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
            if (currentlyShowing != "Movies" || filterApplied)
            {
                currentlyShowing = "Movies";
                btnSearch.Text = "Search movies";
                nmRatingTo.Enabled = true;
                nmRatingFrom.Enabled = true;
                filterApplied = false;
                GetMovies();
            }
        }

        private void btnShowSeries_Click(object sender, EventArgs e)
        {
            if (currentlyShowing != "Series" || filterApplied)
            {
                currentlyShowing = "Series";
                btnSearch.Text = "Search series";
                nmRatingTo.Enabled = false;
                nmRatingFrom.Enabled = false;
                filterApplied = false;
                GetSeries();
            }
        }

        private void lblLoadMore_Click(object sender, EventArgs e)
        {
            if (filterApplied)
            {
                return;
            }
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
            int yearMin = (int)nmYearFrom.Value;
            int yearMax = (int)nmYearTo.Value;
            int ratingMin = (int)nmRatingFrom.Value;
            int ratingMax = (int)nmRatingTo.Value;
            string genre = tbGenre.Text.Trim();
            string sort = "";
            if (rbNameAsc.Checked)
            {
                sort = "order by name asc";
            }
            else if (rbNameDesc.Checked)
            {
                sort = "order by name desc";
            }
            else if (rbRatingAsc.Checked)
            {
                sort = "order by rating asc";
            }
            else
            {
                sort = "order by rating desc";
            }
            filterApplied = true;
            if (currentlyShowing == "Movies")
            {
                FilterMovies(keyword, yearMin, yearMax, ratingMin, ratingMax, genre, sort);
            }
            else
            {
                FilterSeries(keyword, yearMin, yearMax, genre, sort);
            }
        }
    }
}
