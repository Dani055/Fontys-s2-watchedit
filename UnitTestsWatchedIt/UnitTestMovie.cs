using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;
using ClassLibraries.services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsWatchedIt
{
    [TestClass]
    public class UnitTestMovie
    {
        [TestMethod]
        public void TestConstructorMovie()
        {
            Movie m = new Movie(1, "asd", DateTime.MinValue, "http", "action", "me", "description", "yes", TimeSpan.Zero);

            Assert.AreEqual(1, m.Id);
            Assert.AreEqual("asd", m.Name);
            Assert.AreEqual(DateTime.MinValue, m.Year);
            Assert.AreEqual("http", m.ImageUrl);
            Assert.AreEqual("action", m.Genre);
            Assert.AreEqual("me", m.Producer);
            Assert.AreEqual("description", m.Description);
            Assert.AreEqual(TimeSpan.Zero, m.Duration);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieUnahtorized()
        {
            UserService.Login("bust", "123");
            MovieService.AddMovie("The Incredibles", "2002-02-02", "url", "Animation", "Disney?", "whatever", "Voiceactors", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieNameShort()
        {
            UserService.Login("jrdn", "123");
            MovieService.AddMovie("T", "2002-02-02", "url", "Animation", "Disney?", "whatever", "Voiceactors", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieGenreShort()
        {
            UserService.Login("jrdn", "123");
            MovieService.AddMovie("The Incredibles", "2002-02-02", "url", "", "Disney?", "whatever", "Voiceactors", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieProducerShort()
        {
            UserService.Login("jrdn", "123");
            MovieService.AddMovie("The Incredibles", "2002-02-02", "Animation", "Animation", "" ,"whatever", "Voiceactors", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieActorsShort()
        {
            UserService.Login("jrdn", "123");
            MovieService.AddMovie("The Incredibles", "2002-02-02", "Animation", "Animation", "Prod", "whatever", "", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieIncorrectDate()
        {
            UserService.Login("jrdn", "123");
            MovieService.AddMovie("The Incredibles", "Date", "Animation", "Animation", "P", "whatever", "V", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieIncorrectDuration()
        {
            UserService.Login("jrdn", "123");
            MovieService.AddMovie("The Incredibles", "2002-02-02", "Animation", "Animation", "P", "whatever", "V", "Duration");
        }

        [TestMethod]
        public void TestAddMovie()
        {
            UserService.Login("jrdn", "123");
            MovieService.AddMovie("The Incredibles", "2002-02-02", "Animation", "Animation", "Prod", "whatever", "Voiceactors", "01:01:01");
            MovieService.DeleteLastMovie();
        }

        //NOT TESTING INPUT VALIDATION HERE BECAUSE IT SHARES THE SAME METHOD WITH ADD MOVIE
        [TestMethod]
        public void TestEditMovie()
        {
            UserService.Login("jrdn", "123");
            MovieService.AddMovie("The Incredibles", "2002-02-02", "Animation", "Animation", "Prod", "whatever", "Voiceactors", "01:01:01");
            MovieService.EditMovieOrEpisode(MovieService.GetLastMovieID(), "New name", "2022-01-01", "url@url", "New genre", "new producer", "new description", "new actors", "10:10:10", true, 0, 0);
            MovieService.DeleteLastMovie();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestEditMovieUnauthorized()
        {
            UserService.Login("bust", "123");
            MovieService.EditMovieOrEpisode(28, "New name", "2022-01-01", "url@url", "New genre", "new producer", "new description", "new actors", "10:10:10", true, 0, 0);

        }

        [TestMethod]
        public void TestGetMovies()
        {
            MovieService.GetMovies(0);
        }

        [TestMethod]
        public void TestGetMovieById()
        {
            MovieService.GetMovieById(24);
        }

        [TestMethod]
        public void TestSearchMovies()
        {
            MovieService.SearchMovies("iron");
        }

        [TestMethod]
        public void TestDeleteMovieOrEpisode()
        {
            UserService.Login("jrdn", "123");
            MovieService.AddMovie("The Incredibles", "2002-02-02", "Animation", "Animation", "Prod", "whatever", "Voiceactors", "01:01:01");
            MovieService.DeleteMovieOrEpisode(MovieService.GetLastMovieID());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDeleteMovieOrEpisodeUnauthorized()
        {
            UserService.Login("bust", "123");
            MovieService.DeleteMovieOrEpisode(28);
        }
    }
}
