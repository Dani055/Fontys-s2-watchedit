using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibraries.models;
using ClassLibraries.services;

namespace WatchedItWeb.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        private readonly INotyfService _notyf;

        public RegisterModel(INotyfService notyf)
        {
            _notyf = notyf;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            try
            {
                string confirmPass = Request.Form["confirm-password"];
                if (confirmPass != user.Password)
                {
                    throw new Exception("Passwords must match!");
                }
                UserService.Register(user.Username, user.Password, user.FirstName, user.LastName, user.Email, user.ImageUrl);
                _notyf.Success("User registered successfully!");
                return RedirectToPage("/Login");
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return Page();
            }
        }
    }
}
