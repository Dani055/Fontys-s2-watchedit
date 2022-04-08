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

namespace WatchedItWeb.Pages.Serie
{
    public class SeriesDetailsModel : PageModel
    {
        private readonly INotyfService _notyf;
        private readonly IEpisodeService _episodeService;

        [BindProperty(SupportsGet = true)]
        public int seriesId { get; set; }
        public Series series { get; private set; }
        public List<Episode> episodes { get; private set; }
        public SeriesDetailsModel(INotyfService notyf, IEpisodeService episodeService)
        {
            _notyf = notyf;
            _episodeService = episodeService;
        }
        public IActionResult OnGet()
        {
            try
            {
                series = SeriesService.GetSeriesById(seriesId);
                if (series == null)
                {
                    _notyf.Error("Series not found!");
                    return RedirectToPage("/Serie/AllSeries");
                }
                episodes = _episodeService.GetEpisodes(series.Id);
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
                SeriesService.DeleteSeries(HttpContext.Session.GetLoggedUser(), seriesId);
                _notyf.Success("Series deleted");
                return RedirectToPage("/Serie/AllSeries");
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return Page();
            }

        }
    }
}
