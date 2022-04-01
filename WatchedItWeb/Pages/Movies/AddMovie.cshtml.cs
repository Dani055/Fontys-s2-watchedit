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
    public class AddMovieModel : PageModel
    {
        [BindProperty]
        public Movie movie { get; set; }
        private readonly INotyfService _notyf;
        [BindProperty(SupportsGet = true)]
        public bool m { get; set; }

        [BindProperty(SupportsGet = true)]
        public int seriesId { get; set; }
        public AddMovieModel(INotyfService notyf)
        {
            _notyf = notyf;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.IsAdmin() != true)
            {
                return RedirectToPage("/Index");
            }
            try
            {
                if (seriesId <= 0 && !m)
                {
                    return RedirectToPage("/Index");
                }
                else if (seriesId > 0 && !m)
                {
                    Series foundSeries = SeriesService.GetSeriesById(seriesId);
                    if (foundSeries == null)
                    {
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        return Page();
                    }
                }
                else
                {
                    return Page();
                }
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
                    MovieService.AddMovie(HttpContext.Session.GetLoggedUser(), movie.Name, movie.Year.ToString(), movie.ImageUrl, movie.Genre, movie.Producer, movie.Description, movie.Actors, movie.Duration.ToString());
                    _notyf.Success("Movie added!");
                    return RedirectToPage("/Movies/AllMovies");
                }
                else
                {
                    if (String.IsNullOrEmpty(Request.Form["episode"]))
                    {
                        throw new Exception("You must enter an episode.");
                    }
                    if (String.IsNullOrEmpty(Request.Form["season"]))
                    {
                        throw new Exception("You must enter a season.");
                    }
                    int episode = Convert.ToInt32(Request.Form["episode"]);
                    int season = Convert.ToInt32(Request.Form["season"]);
                    EpisodeService.AddEpisode(HttpContext.Session.GetLoggedUser(), movie.Name, movie.Year.ToString(), movie.ImageUrl, movie.Genre, movie.Producer, movie.Description, movie.Actors, movie.Duration.ToString(), season, episode, seriesId); ;
                    _notyf.Success("Episode added!");
                    return RedirectToPage("/Serie/SeriesDetails" , new { seriesId = seriesId });
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
