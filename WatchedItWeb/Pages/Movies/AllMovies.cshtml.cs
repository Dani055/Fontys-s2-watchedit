using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibraries.models;
using ClassLibraries.services;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace WatchedItWeb.Pages.Movies
{
    public class AllMoviesModel : PageModel
    {
        private readonly INotyfService _notyf;
        public List<Movie> movies = new List<Movie>();
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 0;
        [BindProperty(SupportsGet = true)]
        public string keyword { get; set; }
        public AllMoviesModel(INotyfService notyf)
        {
            _notyf = notyf;
        }
        public void OnGet()
        {
            try
            {
                if (!string.IsNullOrEmpty(keyword))
                {
                    movies = MovieService.SearchMovies(keyword);
                }
                else
                {
                    List<Movie> loadedMovies = new List<Movie>();
                    for (int i = 0; i <= CurrentPage; i++)
                    {
                        loadedMovies = MovieService.GetMovies(i * 4);
                        movies.AddRange(loadedMovies);
                    }
                }
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
            }

        }
        public void OnPost()
        {

        }
    }
}
