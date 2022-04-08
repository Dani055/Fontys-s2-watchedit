using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using ClassLibraries.models;
using ClassLibraries.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibraries.interfaces;

namespace WatchedItWeb.Pages.Movies
{
    public class MovieDetailsModel : PageModel
    {
        private readonly INotyfService _notyf;
        private readonly IMovieService _movieService;
        private readonly IEpisodeService _episodeService;

        [BindProperty(SupportsGet = true)]
        public int movieId { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool m { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 0;

        [BindProperty]
        public Review review { get; set; }

        public Movie movie { get; set; }
        public List<Review> reviews { get; set; } = new List<Review>();




        public MovieDetailsModel(INotyfService notyf, IMovieService movieService, IEpisodeService episodeService)
        {
            _notyf = notyf;
            _movieService = movieService;
            _episodeService = episodeService;
        }
        public IActionResult OnGet()
        {
            try
            {
                if (m)
                {
                    movie = _movieService.GetMovieById(movieId);
                }
                else
                {
                    movie = _episodeService.GetEpisodeById(movieId);
                }
        
                if (movie == null)
                {
                    _notyf.Error("Resource not found!");
                    return RedirectToPage("/Movies/AllMovies");
                }
                if (HttpContext.Session.GetLoggedUser() != null)
                {
                    Review ownReview = ReviewService.GetReview(HttpContext.Session.GetLoggedUser(), movieId);
                    if (ownReview != null)
                    {
                        reviews.Add(ownReview);
                    }
                }
                List<Review> loadedReviews = new List<Review>();
                for (int i = 0; i <= CurrentPage; i++)
                {
                    loadedReviews = ReviewService.GetReviews(HttpContext.Session.GetLoggedUser() == null ? 0 : HttpContext.Session.GetLoggedUser().Id, movieId, i * 4);
                    reviews.AddRange(loadedReviews);
                }
                return Page();
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return RedirectToPage("/Index");
            }
        }

        public IActionResult OnPostOnDelete()
        {
            try
            {
                _movieService.DeleteMovieOrEpisode(HttpContext.Session.GetLoggedUser(), movieId);
                if (m)
                {
                    _notyf.Success("Movie deleted");
                    return RedirectToPage("/Movies/AllMovies");
                }
                else
                {
                    int seriesId = Convert.ToInt32(Request.Form["seriesId"]);
                    _notyf.Success("Episode deleted");
                    return RedirectToPage("/Serie/SeriesDetails", new { seriesId = seriesId });
                }
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return RedirectToPage($"/Movies/MovieDetails", new { m = m, movieId = movieId });
            }

        }
        public IActionResult OnPostOnSubmitReview()
        {
            try
            {
                ReviewService.PostReview(HttpContext.Session.GetLoggedUser(), movieId, review.Description, review.Rating);
                _notyf.Success("Review posted");
                return RedirectToPage($"/Movies/MovieDetails", new { m = m, movieId = movieId });
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return RedirectToPage($"/Movies/MovieDetails", new { m = m, movieId = movieId});
            }
        }
        public IActionResult OnPostOnDeleteReview()
        {
            try
            {
                int reviewId = Convert.ToInt32(Request.Form["reviewId"]);
                ReviewService.DeleteReview(HttpContext.Session.GetLoggedUser(), reviewId);
                _notyf.Success("Review deleted");
                return RedirectToPage($"/Movies/MovieDetails", new { m = m, movieId = movieId });
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return RedirectToPage($"/Movies/MovieDetails", new { m = m, movieId = movieId });
            }  
        }
    }
}
