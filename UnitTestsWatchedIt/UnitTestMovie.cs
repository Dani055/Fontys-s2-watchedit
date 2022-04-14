using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.data_access;
using ClassLibraries.interfaces;
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
            Movie m = new Movie(1, "asd", DateTime.MinValue, "http", "action", "me", "description", "yes", TimeSpan.Zero, 5);

            Assert.AreEqual(1, m.Id);
            Assert.AreEqual("asd", m.Name);
            Assert.AreEqual(DateTime.MinValue, m.Year);
            Assert.AreEqual("http", m.ImageUrl);
            Assert.AreEqual("action", m.Genre);
            Assert.AreEqual("me", m.Producer);
            Assert.AreEqual("description", m.Description);
            Assert.AreEqual(TimeSpan.Zero, m.Duration);
            Assert.AreEqual(5, m.Rating);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieUnahtorized()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            User user = new User(0, false, "", "", "", "", "", "");
            movieService.AddMovie(user, "The Incredibles", "2002-02-02", "url", "Animation", "Disney?", "whatever", "Voiceactors", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieNameShort()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            movieService.ValidateMovie("T", "Animation", "Producer", "Actors", "2002-02-02", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieGenreShort()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            User user = new User(0, true, "", "", "", "", "", "");
            movieService.AddMovie(user, "The Incredibles", "2002-02-02", "url", "", "Disney?", "whatever", "Voiceactors", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieProducerShort()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            User user = new User(0, true, "", "", "", "", "", "");
            movieService.AddMovie(user, "The Incredibles", "2002-02-02", "Animation", "Animation", "", "whatever", "Voiceactors", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieActorsShort()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            User user = new User(0, true, "", "", "", "", "", "");
            movieService.AddMovie(user, "The Incredibles", "2002-02-02", "Animation", "Animation", "Prod", "whatever", "", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieIncorrectDate()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            User user = new User(0, true, "", "", "", "", "", "");
            movieService.AddMovie(user, "The Incredibles", "Date", "Animation", "Animation", "P", "whatever", "V", "1:52:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddMovieIncorrectDuration()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            User user = new User(0, true, "", "", "", "", "", "");
            movieService.AddMovie(user, "The Incredibles", "2002-02-02", "Animation", "Animation", "P", "whatever", "V", "Duration");
        }

        [TestMethod]
        public void TestAddMovie()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            User user = new User(0, true, "", "", "", "", "", "");
            bool result = movieService.AddMovie(user, "The Incredibles", "2002-02-02", "Animation", "Animation", "Prod", "whatever", "Voiceactors", "01:01:01");
            Assert.IsTrue(result);
        }

        //NOT TESTING INPUT VALIDATION HERE BECAUSE IT SHARES THE SAME METHOD WITH ADD MOVIE
        [TestMethod]
        public void TestEditMovie()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            User user = new User(0, true, "", "", "", "", "", "");
            bool result = movieService.EditMovieOrEpisode(user, 1, "New name", "2022-01-01", "url@url", "New genre", "new producer", "new description", "new actors", "10:10:10", true, 0, 0);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestEditMovieUnauthorized()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            User user = new User(0, false, "", "", "", "", "", "");
            movieService.EditMovieOrEpisode(user, 28, "New name", "2022-01-01", "url@url", "New genre", "new producer", "new description", "new actors", "10:10:10", true, 0, 0);

        }

        [TestMethod]
        public void TestDeleteMovieOrEpisode()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            User user = new User(0, true, "", "", "", "", "", "");

            bool result = movieService.DeleteMovieOrEpisode(user, 1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDeleteMovieOrEpisodeUnauthorized()
        {
            IDataAccessMovie DAmovie = new FakeDALMovie();
            IDataAccessEpisode DAEpisode = new FakeDALEpisode();
            IMovieService movieService = new MovieService(DAmovie, DAEpisode);

            User user = new User(0, false, "", "", "", "", "", "");
            movieService.DeleteMovieOrEpisode(user, 1);
        }
    }
}
