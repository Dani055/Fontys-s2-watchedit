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
using ClassLibraries.interfaces;
using ClassLibraries.models;
using ClassLibraries.services;
using WatchedIT_Desktop.user_controls;
using Microsoft.Extensions.DependencyInjection;

namespace WatchedIT_Desktop.forms
{
    public partial class MovieDetails : Form
    {
        private readonly IMovieService _movieService;
        private readonly IEpisodeService _episodeService;
        private Movie movie = null;
        private List<Review> reviews = new List<Review>();
        private bool isMovie = true;
        public MovieDetails(int id, bool ismovie)
        {
            InitializeComponent();
            _movieService = Program.ServiceProvider.GetService<IMovieService>();
            _episodeService = Program.ServiceProvider.GetService<IEpisodeService>();
            isMovie = ismovie;
            try
            {
                if (!isMovie)
                {
                    movie = _episodeService.GetEpisodeById(id);
                }
                else
                {
                    movie = _movieService.GetMovieById(id);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }            
            PopulateInfo();
            HideUI();

        }
        private void HideUI()
        {
            if (!AuthClass.loggedUser.IsAdmin)
            {
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }
            if (reviews.Count == 0)
            {
                if (movie is Episode)
                {
                    lblNoRev.Text = "This episode currently has no reviews";
                }
                else
                {
                    lblNoRev.Text = "This movie currently has no reviews";
                }
                lblLoadReviews.Visible = false;
            }
            else
            {
                lblNoRev.Text = "";
                lblLoadReviews.Visible = true;
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
            LoadReviews();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_movieService.DeleteMovieOrEpisode(AuthClass.loggedUser, movie.Id))
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
                        movie = _episodeService.GetEpisodeById(movie.Id);
                    }
                    else
                    {
                        movie = _movieService.GetMovieById(movie.Id);
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError(ex.Message);
                }


                PopulateInfo();
            }
        }
        private void LoadReviews()
        {
            try
            {
                Review ownReview = ReviewService.GetReview(AuthClass.loggedUser, movie.Id);
                if (ownReview != null)
                {
                    reviews.Add(ownReview);
                }
                reviews.AddRange(ReviewService.GetReviews(AuthClass.loggedUser.Id, movie.Id, 0));
                flwReviews.Controls.Clear();
                foreach (Review r in reviews)
                {
                    ReviewCard card = new ReviewCard(r.Id, r.UserId, r.FirstName, r.LastName, r.UserImg, r.Description, r.Rating);
                    flwReviews.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }
        }
        private void LoadMoreReviews()
        {
            try
            {
                List<Review> loadedReviews = ReviewService.GetReviews(AuthClass.loggedUser.Id, movie.Id, reviews.Count);
                reviews.AddRange(loadedReviews);
                foreach (Review r in loadedReviews)
                {
                    ReviewCard card = new ReviewCard(r.Id, r.UserId, r.FirstName, r.LastName, r.UserImg, r.Description, r.Rating);
                    flwReviews.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }
        }

        private void lblLoadReviews_Click(object sender, EventArgs e)
        {
            LoadMoreReviews();
        }
    }
}
