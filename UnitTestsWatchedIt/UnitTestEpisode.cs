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
    public class UnitTestEpisode
    {
        [TestMethod]
        public void TestEpisodeConstructor()
        {
            Episode e = new Episode(1, "The simpsons", DateTime.MinValue, "url", "comdey", "producer", "description", "actors", TimeSpan.Zero,0 , 1, 2, 3);

            Assert.AreEqual(1, e.Id);
            Assert.AreEqual("The simpsons", e.Name);
            Assert.AreEqual(DateTime.MinValue, e.Year);
            Assert.AreEqual("url", e.ImageUrl);
            Assert.AreEqual("comdey", e.Genre);
            Assert.AreEqual("producer", e.Producer);
            Assert.AreEqual("description", e.Description);
            Assert.AreEqual("actors", e.Actors);
            Assert.AreEqual(TimeSpan.Zero, e.Duration);
            Assert.AreEqual(0, e.Rating);
            Assert.AreEqual(1, e.SeriesId);
            Assert.AreEqual(2, e.SeasonNo);
            Assert.AreEqual(3, e.EpisodeNo);
        }

       
    }
}
