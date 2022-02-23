using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchedIT_Desktop.logic.models
{
    public class User
    {
        public int Id { get; }
        public bool IsAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        public User(int id, bool isadmin, string username, string pass, string firstname, string lastname, string email, string imageurl)
        {
            Id = id;
            IsAdmin = isadmin;
            Username = username;
            Password = pass;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            if (imageurl == "")
            {
                imageurl = null;
            }
            ImageUrl = imageurl;
        }

    }
}
