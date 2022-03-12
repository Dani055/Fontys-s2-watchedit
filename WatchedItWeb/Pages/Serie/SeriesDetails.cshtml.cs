using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using ClassLibraries.models;
using ClassLibraries.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WatchedItWeb.Pages.Serie
{
    public class SeriesDetailsModel : PageModel
    {
        private readonly INotyfService _notyf;
        [BindProperty(SupportsGet = true)]
        public int seriesId { get; set; }
        public Series series { get; private set; }
        public List<Episode> episodes { get; private set; }
        public SeriesDetailsModel(INotyfService notyf)
        {
            _notyf = notyf;
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
                episodes = EpisodeService.GetEpisodes(series.Id);
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
                SeriesService.DeleteSeries(seriesId);
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
