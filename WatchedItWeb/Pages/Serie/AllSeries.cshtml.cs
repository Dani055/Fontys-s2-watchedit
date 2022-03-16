using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using ClassLibraries.models;
using ClassLibraries;
using ClassLibraries.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WatchedItWeb.Pages.Serie
{
    public class AllSeriesModel : PageModel
    {
        private readonly INotyfService _notyf;
        public List<Series> series = new List<Series>();
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 0;
        [BindProperty(SupportsGet = true)]
        public string keyword { get; set; }

        public AllSeriesModel(INotyfService notyf)
        {
            _notyf = notyf;
        }
        public void OnGet()
        {
            try
            {
                if (!string.IsNullOrEmpty(keyword))
                {
                    series = SeriesService.SearchSeries(keyword);
                }
                else
                {
                    List<Series> loadedSeries = new List<Series>();
                    for (int i = 0; i <= CurrentPage; i++)
                    {
                        loadedSeries = SeriesService.GetSeries(i * 4);
                        series.AddRange(loadedSeries);
                    }
                }
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
            }
        }
    }
}
