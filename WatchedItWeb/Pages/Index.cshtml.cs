using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ClassLibraries;
using ClassLibraries.models;
using ClassLibraries.services;
using ClassLibraries.interfaces;

namespace WatchedItWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly INotyfService _notyf;
        private readonly IMovieService _movieService;
        public List<Movie> BestRated { get; set; } = new List<Movie>();
        public List<Movie> Newest { get; set; } = new List<Movie>();
        [BindProperty(SupportsGet = true)]
        public int CurrentPageRated { get; set; } = 0;
        [BindProperty(SupportsGet = true)]
        public int CurrentPageNew { get; set; } = 0;
        public IndexModel(ILogger<IndexModel> logger, INotyfService notyf, IMovieService movieService)
        {
            _logger = logger;
            _notyf = notyf;
            _movieService = movieService;
        }

        public void OnGet()
        {
            try
            {
                List<Movie> loadedMoviesBestRated = new List<Movie>();
                for (int i = 0; i <= CurrentPageRated; i++)
                {
                    loadedMoviesBestRated = _movieService.GetMostRatedMovies(i * 4);
                    BestRated.AddRange(loadedMoviesBestRated);
                }

                List<Movie> loadedMoviesNewest = new List<Movie>();
                for (int i = 0; i <= CurrentPageNew; i++)
                {
                    loadedMoviesNewest = _movieService.GetMovies(i * 4);
                    Newest.AddRange(loadedMoviesNewest);
                }
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
            }
        }
    }
}
