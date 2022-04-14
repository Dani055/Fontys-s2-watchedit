using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraries.models;
using ClassLibraries.services;

namespace UnitTestsWatchedIt
{
    [TestClass]
    public class UnitTestSeries
    {
        [TestMethod]
        public void TestSeriesConstructor()
        {
            Series s = new Series(1, "the simpsons", DateTime.MinValue, "url", "genre", "prod", "desc", "actors");

            Assert.AreEqual(1, s.Id);
            Assert.AreEqual("the simpsons", s.Name);
            Assert.AreEqual(DateTime.MinValue, s.Year);
            Assert.AreEqual("url", s.ImageUrl);
            Assert.AreEqual("prod", s.Producer);
            Assert.AreEqual("desc", s.Description);
            Assert.AreEqual("actors", s.Actors);
        }

        #region "Old unit tests with static services. Consider looking at unit tests for movie"
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddSeriesUnauthorized()
        {
            User user = UserService.Login("bust", "123");
            SeriesService.AddSeries(user, "The Withcer", "2019-01-01", "image", "Action/Fantasy", "description", "actors", "producer");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddSeriesNameShort()
        {
            User user = UserService.Login("jrdn", "123");
            SeriesService.AddSeries(user, "Th", "2019-01-01", "image", "Action/Fantasy", "description", "actors", "producer");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddSeriesGenreShort()
        {
            User user = UserService.Login("jrdn", "123");
            SeriesService.AddSeries(user, "The Witcher", "2019-01-01", "image", "", "description", "actors", "producer");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddSeriesProducerShort()
        {
            User user = UserService.Login("jrdn", "123");
            SeriesService.AddSeries(user, "The Witcher", "2019-01-01", "image", "genre", "description", "actors", "");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddSeriesActorsShort()
        {
            User user = UserService.Login("jrdn", "123");
            SeriesService.AddSeries(user, "The Witcher", "2019-01-01", "image", "genre", "description", "", "producer");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddSeriesDateIncorrect()
        {
            User user = UserService.Login("jrdn", "123");
            SeriesService.AddSeries(user, "The Witcher", "date", "image", "genre", "description", "actors", "producer");
        }

        //NOT TESTING INPUT VALIDATION OR AUTHORIZATION BECAUSE ValidateSeries() IS A SHARED METHOD
        [TestMethod]
        public void TestEditSeries()
        {
            User user = UserService.Login("jrdn", "123");
            SeriesService.AddSeries(user, "The Witcher", "2019-01-01", "image", "genre", "description", "actors", "producer");
            SeriesService.EditSeries(user, SeriesService.GetLastSeriesId(user), "New name", "2022-01-01", "url@url", "New genre", "new description", "new actors", "new producers");
            SeriesService.DeleteLastSeries(user);
        }

        [TestMethod]
        public void TestGetSeries()
        {
            SeriesService.GetSeries(0);
        }

        [TestMethod]
        public void TestSearchSeries()
        {
            SeriesService.SearchSeries("simp");
        }
        [TestMethod]
        public void TestGetSeriesById()
        {
            User user = UserService.Login("jrdn", "123");
            SeriesService.GetSeriesById(SeriesService.GetLastSeriesId(user));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDeleteSeriesUnauthorized()
        {
            User user = UserService.Login("bust", "123");
            SeriesService.DeleteSeries(user, 12);

        }

        [TestMethod]
        public void TestDeleteSeries()
        {
            User user = UserService.Login("jrdn", "123");
            SeriesService.AddSeries(user, "The Witcher", "2019-01-01", "image", "genre", "description", "actors", "producer");
            SeriesService.DeleteSeries(user, SeriesService.GetLastSeriesId(user));
        }
        #endregion
    }
}
