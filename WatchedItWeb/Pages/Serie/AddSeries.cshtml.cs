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
    public class AddSeriesModel : PageModel
    {
        [BindProperty]
        public Series series { get; set; }
        private readonly INotyfService _notyf;

        public AddSeriesModel(INotyfService notyf)
        {
            _notyf = notyf;
        }
        public IActionResult OnGet()
        {
            if (UserService.loggedUser?.IsAdmin == false || UserService.loggedUser == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            try
            {
                SeriesService.AddSeries(series.Name, series.Year.ToString(), series.ImageUrl, series.Genre, series.Description, series.Actors, series.Producer);
                _notyf.Success("Series addded!");
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return Page();
            }
        }
    }
}
