using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.data_access;
using ClassLibraries.interfaces;
using ClassLibraries.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace UnitTestsWatchedIt
{
    [TestClass]
    public class TestDALMovie
    {
        [TestMethod]
        public void TestAddMovie()
        {
            IDBSettings mockDb = new MockDBSettings();
            IDataAccessMovie DAmovie = new DataAccessMovie(mockDb);
            bool result = DAmovie.AddMovie("The Incredibles", DateTime.Parse("2002-02-02"), "Animation", "Animation", "Prod", "whatever", "Voiceactors", TimeSpan.Parse("01:01:01"));
            Assert.IsTrue(result);
            Movie mAdded = new Movie(DAmovie.GetLastMovieId(), "The Incredibles", DateTime.Parse("2002-02-02"), "Animation", "Animation", "Prod", "whatever", "Voiceactors", TimeSpan.Parse("01:01:01"), 0);
            Movie m = DAmovie.GetMovieById(DAmovie.GetLastMovieId());

            mAdded.Should().BeEquivalentTo(m);

            DAmovie.DeleteLastMovie();
        }


        [TestMethod]
        public void TestEditMovie()
        {
            IDBSettings mockDb = new MockDBSettings();
            IDataAccessMovie DAmovie = new DataAccessMovie(mockDb);

            DAmovie.AddMovie("The Incredibles", DateTime.Parse("2002-02-02"), "Animation", "Animation", "Prod", "whatever", "Voiceactors", TimeSpan.Parse("01:01:01"));
            int movieId = DAmovie.GetLastMovieId();
            bool result = DAmovie.EditMovie(movieId, "New name", DateTime.Parse("2022-01-01"), "url@url", "New genre", "new producer", "new description", "new actors", TimeSpan.Parse("10:10:10"));
           
            Movie mEdited = new Movie(movieId, "New name", DateTime.Parse("2022-01-01"), "url@url", "New genre", "new producer", "new description", "new actors", TimeSpan.Parse("10:10:10"), 0);
            Movie m = DAmovie.GetMovieById(movieId);

            Assert.IsTrue(result);
            mEdited.Should().BeEquivalentTo(m);

            DAmovie.DeleteLastMovie();
        }

        //ONLY CHECKING ID's BECAUSE UNIT TEST FOR ADDING MAKES SURE THAT INFORMATION IS CORRECT
        [TestMethod]
        public void TestGetMovies()
        {
            IDBSettings mockDb = new MockDBSettings();
            IDataAccessMovie DAmovie = new DataAccessMovie(mockDb);
            List<int> ids = new List<int>();

            DAmovie.AddMovie("The Incredibles", DateTime.Parse("2002-02-02"), "url", "Animation", "Prod", "whatever", "Voiceactors", TimeSpan.Parse("01:01:01"));
            ids.Add(DAmovie.GetLastMovieId());
            DAmovie.AddMovie("The Witcher", DateTime.Parse("2019-02-02"), "url", "Medieval", "producers", "desc", "Actors", TimeSpan.Parse("00:20:00"));
            ids.Add(DAmovie.GetLastMovieId());

            List<Movie> movies = DAmovie.GetMovies(0);
            Assert.AreEqual(ids[1], movies[0].Id);
            Assert.AreEqual(ids[0], movies[1].Id);
            DAmovie.DeleteLastMovie();
            DAmovie.DeleteLastMovie();
        }

        [TestMethod]
        public void TestGetMovieById()
        {
            IDBSettings mockDb = new MockDBSettings();
            IDataAccessMovie DAmovie = new DataAccessMovie(mockDb);

            DAmovie.AddMovie("The Incredibles", DateTime.Parse("2002-02-02"), "url", "Animation", "Prod", "whatever", "Voiceactors", TimeSpan.Parse("01:01:01"));
            int movieId = DAmovie.GetLastMovieId();
            Movie mAdded = new Movie(movieId, "The Incredibles", DateTime.Parse("2002-02-02"), "url", "Animation", "Prod", "whatever", "Voiceactors", TimeSpan.Parse("01:01:01"), 0);
            Movie m = DAmovie.GetMovieById(movieId);

            mAdded.Should().BeEquivalentTo(m);
            DAmovie.DeleteLastMovie();
        }

        [TestMethod]
        public void TestDeleteMovieOrEpisode()
        {
            IDBSettings mockDb = new MockDBSettings();
            IDataAccessMovie DAmovie = new DataAccessMovie(mockDb);

            DAmovie.AddMovie("The Incredibles", DateTime.Parse("2002-02-02"), "url", "Animation", "Prod", "whatever", "Voiceactors", TimeSpan.Parse("01:01:01"));
            int movieId = DAmovie.GetLastMovieId();
            DAmovie.DeleteMovieOrEpisode(movieId);

            Movie m = DAmovie.GetMovieById(movieId);
            Assert.IsNull(m);
        }

    }
}
