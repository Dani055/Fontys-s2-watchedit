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
    public class TestDALEpisode
    {
        [TestMethod]
        public void TestAddEpisode()
        {
            IDBSettings mockDb = new MockDBSettings();
            IDataAccessMovie DAmovie = new DataAccessMovie(mockDb);
            IDataAccessEpisode DAepisode = new DataAccessEpisode(mockDb);

            DAepisode.AddEpisode("The Incredibles", DateTime.Parse("2002-02-02"), "Animation", "Animation", "Prod", "whatever", "Voiceactors", TimeSpan.Parse("01:01:01"), 1, 1, 31);

            Episode eAdded = new Episode(DAmovie.GetLastMovieId(), "The Incredibles", DateTime.Parse("2002-02-02"), "Animation", "Animation", "Prod", "whatever", "Voiceactors", TimeSpan.Parse("01:01:01"), 0, 31, 1, 1);
            Episode e = DAepisode.GetEpisodeById(DAmovie.GetLastMovieId());

            eAdded.Should().BeEquivalentTo(e);

            DAmovie.DeleteLastMovie();
        }


        [TestMethod]
        public void TestEditMovie()
        {
            IDBSettings mockDb = new MockDBSettings();
            IDataAccessMovie DAmovie = new DataAccessMovie(mockDb);
            IDataAccessEpisode DAepisode = new DataAccessEpisode(mockDb);

            DAepisode.AddEpisode("The Incredibles", DateTime.Parse("2002-02-02"), "Animation", "Animation", "Prod", "whatever", "Voiceactors", TimeSpan.Parse("01:01:01"), 1, 1, 31);

            int movieId = DAmovie.GetLastMovieId();
            bool result = DAepisode.EditEpisode(movieId, "New name", DateTime.Parse("2022-01-01"), "url@url", "New genre", "new producer", "new description", "new actors", TimeSpan.Parse("10:10:10"), 2, 2);

            Episode epEdited = new Episode(movieId, "New name", DateTime.Parse("2022-01-01"), "url@url", "New genre", "new producer", "new description", "new actors", TimeSpan.Parse("10:10:10"), 0, 31, 2, 2);
            Episode e = DAepisode.GetEpisodeById(movieId);

            epEdited.Should().BeEquivalentTo(e);

            DAmovie.DeleteLastMovie();
        }
    }
}
