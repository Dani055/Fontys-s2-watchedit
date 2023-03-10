using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.data_access;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.services
{
    public static class UserService
    {
        public static User loggedUser { get; set; } = null;

        public static bool Login(string username, string password)
        {
            User user = DataAccessUser.LoginQuery(username, password);
            loggedUser = user;
            return true;
        }

        public static bool Register(string username, string password, string firstname, string lastname, string email, string imageurl)
        {
            ValidateUser(username, password, firstname, lastname, email, imageurl);
            return DataAccessUser.RegisterQuery(username, password, firstname, lastname, email, imageurl);

        }

        public static bool DeleteUser(string username)
        {
            return DataAccessUser.DeleteQuery(username);
        }
        public static bool ValidateUser(string username, string password, string firstname, string lastname, string email, string imageurl)
        {
            if (username.Length < 3)
            {
                throw new Exception("Username must be at least 3 characters long!");
            }
            else if (password.Length < 3)
            {
                throw new Exception("Password must be at least 3 characters long!");
            }
            else if (String.IsNullOrEmpty(firstname))
            {
                throw new Exception("You must enter a first name!");
            }
            else if (String.IsNullOrEmpty(lastname))
            {
                throw new Exception("You must enter a last name!");
            }
            else if (email.Length <= 5)
            {
                throw new Exception("Email must be valid!");
            }
            return true;
        }
    }
 }
