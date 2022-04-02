using System;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using ClassLibraries.models;
using ClassLibraries.services;

namespace WatchedItWeb.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        private readonly INotyfService _notyf;
        public User loggedUser { get; set; }
        public LoginModel (INotyfService notyf)
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
                User result = UserService.Login(user.Username, user.Password);
                if (result != null)
                {
                    HttpContext.Session.SetObject("loggedUser", result);
/*                    HttpContext.Session.SetInt32("userId", result.Id);*/
                    return RedirectToPage("/Index");
                }
                else
                {
                    return Page();
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
