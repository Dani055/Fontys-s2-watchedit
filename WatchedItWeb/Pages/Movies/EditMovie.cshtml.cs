using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using ClassLibraries.interfaces;
using ClassLibraries.models;
using ClassLibraries.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WatchedItWeb.Pages.Movies
{
    public class EditMovieModel : PageModel
    {
        private readonly INotyfService _notyf;
        private readonly IMovieService _movieService;
        private readonly IEpisodeService _episodeService;

        [BindProperty]
        public Movie movie { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool m { get; set; }

        [BindProperty(SupportsGet = true)]
        public int movieId { get; set; }
        public EditMovieModel(INotyfService notyf, IMovieService movieService, IEpisodeService episodeService)
        {
            _notyf = notyf;
            _movieService = movieService;
            _episodeService = episodeService;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetLoggedUser() == null || HttpContext.Session.GetLoggedUser().IsAdmin == false)
            {
                _notyf.Error("You are not authorized");
                return RedirectToPage("/Index");
            }
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
                return Page();
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return RedirectToPage("/Index");
            }
        }
        public IActionResult OnPost()
        {
            try
            {                
                if (m)
                {
                    _movieService.EditMovieOrEpisode(HttpContext.Session.GetLoggedUser(), movieId, movie.Name, movie.Year.ToString(), movie.ImageUrl, movie.Genre, movie.Producer, movie.Description, movie.Actors, movie.Duration.ToString(), m, 0, 0);
                    _notyf.Success("Movie edited.");
                }
                else
                {
                    if (String.IsNullOrEmpty(Request.Form["episode"]))
                    {
                        throw new Exception("You must enter an episode");
                    }
                    if (String.IsNullOrEmpty(Request.Form["season"]))
                    {
                        throw new Exception("You must enter an episode");
                    }

                    int episode = Convert.ToInt32(Request.Form["episode"]);
                    int season = Convert.ToInt32(Request.Form["season"]);
                    _movieService.EditMovieOrEpisode(HttpContext.Session.GetLoggedUser(), movieId, movie.Name, movie.Year.ToString(), movie.ImageUrl, movie.Genre, movie.Producer, movie.Description, movie.Actors, movie.Duration.ToString(), m, season, episode);
                    _notyf.Success("Episode edited.");
                }
                return RedirectToPage("/Movies/MovieDetails", new { m = m, movieId = movieId });
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return Page();
            }
        }
    }
}
