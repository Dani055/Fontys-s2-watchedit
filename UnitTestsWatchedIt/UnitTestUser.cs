using System;
using ClassLibraries.models;
using ClassLibraries.services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsWatchedIt
{
    [TestClass]
    public class UnitTestUser
    {
        [TestMethod]
        public void TestConstructorUser()
        {
            User u = new User(1, false, "jrdn", "123", "Yordan", "Doykov", "email@email.com", "www.com");

            Assert.AreEqual(1, u.Id);
            Assert.AreEqual(false, u.IsAdmin);
            Assert.AreEqual("jrdn", u.Username);
            Assert.AreEqual("123", u.Password);
            Assert.AreEqual("Yordan", u.FirstName);
            Assert.AreEqual("Doykov", u.LastName);
            Assert.AreEqual("email@email.com", u.Email);
            Assert.AreEqual("www.com", u.ImageUrl);
        }
        [TestMethod]
        public void TestLogin()
        {
            UserService.Login("jrdn", "123");
            Assert.IsNotNull(UserService.loggedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestLoginIncorrect()
        {
            UserService.Login("asd", "asd");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RegisterUsernameShort()
        {
            UserService.Register("","123","123","123","123", "123");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RegisterPasswordShort()
        {
            UserService.Register("123", "", "123", "123", "123", "123");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RegisterFirstnameShort()
        {
            UserService.Register("123", "123", "", "123", "123", "123");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RegisterLastnameShort()
        {
            UserService.Register("123", "123", "123", "", "123", "123");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RegisterEmailInvalid()
        {
            UserService.Register("123", "123", "123", "123", "", "123");
        }

        [TestMethod]
        public void Register()
        {
            UserService.Register("123", "123", "123", "123", "123@123", "123");
            UserService.DeleteUser("123");
        }
    }
}
