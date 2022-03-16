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
    public class MovieDetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int movieId { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool m { get; set; }
        private readonly INotyfService _notyf;
        public Movie movie { get; set; }
        public MovieDetailsModel(INotyfService notyf)
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

        public IActionResult OnPostOnDelete()
        {
            try
            {
                MovieService.DeleteMovieOrEpisode(movieId);
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
                return Page();
            }

        }
    }
}
