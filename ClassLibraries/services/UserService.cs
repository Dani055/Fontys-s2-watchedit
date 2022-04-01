using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClassLibraries.data_access;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.services
{
    public static class UserService
    {

        public static User Login(string username, string password)
        {
            User user = DataAccessUser.LoginQuery(username);
            bool match = Utils.Verify(password, user.Password);
            if (!match)
            {
                throw new Exception("Wrong username or password!");
            }
            return user;
        }
        
        public static bool Register(string username, string password, string firstname, string lastname, string email, string imageurl)
        {
            ValidateUser(username, password, firstname, lastname, email, imageurl);
            string hashedPass = Utils.Hash(password);
            return DataAccessUser.RegisterQuery(username, hashedPass, firstname, lastname, email, imageurl);

        }
        public static bool IsAuth(User user)
        {
            if (user == null)
            {
                throw new Exception("You are not authenticated");
            }
            return true;
        }
        public static bool IsAdmin(User user)
        {
            if (user == null || user.IsAdmin == false)
            {
                throw new Exception("You are not authorized");
            }
            return true;
        }
        public static bool DeleteUser(string username)
        {
            return DataAccessUser.DeleteQuery(username);
        }
        public static bool ValidateUser(string username, string password, string firstname, string lastname, string email, string imageurl)
        {
            if (String.IsNullOrEmpty(username) || username.Length < 3)
            {
                throw new Exception("Username must be at least 3 characters long!");
            }
            else if (String.IsNullOrEmpty(username) || password.Length < 3)
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
            else if (!Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
            {      
                throw new Exception("Email must be valid!");
            }
            return true;
        }
    }
 }
