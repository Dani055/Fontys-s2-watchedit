using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using ClassLibraries.models;
using ClassLibraries.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WatchedItWeb.Pages.Movies
{
    public class EditMovieModel : PageModel
    {
        [BindProperty]
        public Movie movie { get; set; }
        private readonly INotyfService _notyf;
        [BindProperty(SupportsGet = true)]
        public bool m { get; set; }

        [BindProperty(SupportsGet = true)]
        public int movieId { get; set; }
        public EditMovieModel(INotyfService notyf)
        {
            _notyf = notyf;
        }
        public IActionResult OnGet()
        {
            try
            {
                if (m)
                {
                    movie = MovieService.GetMovieById(movieId);
                }
                else
                {
                    movie = EpisodeService.GetEpisodeById(movieId);
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
                int episode = Convert.ToInt32(Request.Form["episode"]);
                int season = Convert.ToInt32(Request.Form["season"]);
                MovieService.EditMovieOrEpisode(movieId, movie.Name, movie.Year.ToString(), movie.ImageUrl, movie.Genre, movie.Producer, movie.Description, movie.Actors, movie.Duration.ToString(), m, season, episode);
                if (m)
                {
                    _notyf.Success("Movie edited.");
                }
                else
                {
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
