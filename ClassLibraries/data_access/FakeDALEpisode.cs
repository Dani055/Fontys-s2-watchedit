using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.interfaces;
using ClassLibraries.models;

namespace ClassLibraries.data_access
{
    public class FakeDALEpisode : IDataAccessEpisode
    {
        public bool AddEpisode(string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration, int season, int episode, int seriesId)
        {
            throw new NotImplementedException();
        }

        public bool EditEpisode(int id, string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration, int season, int episode)
        {
            throw new NotImplementedException();
        }

        public Episode GetEpisodeById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Episode> GetEpisodes(int seriesid)
        {
            throw new NotImplementedException();
        }
    }
}
