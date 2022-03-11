using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibraries.models;
using ClassLibraries.services;

namespace WatchedItWeb.Pages.Movies
{
    public class AllMoviesModel : PageModel
    {
        public void OnGet()
        {
            UserService.loggedUser = new User(1, true, "jrdn", "123", "yes", "doy", "yes@yes.yes", "");
        }
    }
}
