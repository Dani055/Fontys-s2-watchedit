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
    public class EditSeriesModel : PageModel
    {
        [BindProperty]
        public Series series { get; set; }

        [BindProperty(SupportsGet = true)]
        public int seriesId { get; set; }
        private readonly INotyfService _notyf;

        public EditSeriesModel(INotyfService notyf)
        {
            _notyf = notyf;
        }
        public IActionResult OnGet()
        {
            if (UserService.loggedUser?.IsAdmin == false || UserService.loggedUser == null)
            {
                return RedirectToPage("/Index");
            }
            series = SeriesService.GetSeriesById(seriesId);
            if (series == null)
            {
                _notyf.Error("Series not found.");
                return RedirectToPage("/Index");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            try
            {
                SeriesService.EditSeries(seriesId, series.Name, series.Year.ToString(), series.ImageUrl, series.Genre, series.Description, series.Actors, series.Producer);
                _notyf.Success("Series Edited!");
                return RedirectToPage("/Serie/SeriesDetails", new { seriesId = seriesId });
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return Page();
            }
        }
    }
}
