using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;

namespace ClassLibraries.interfaces
{
    public interface IDataAccessEpisode
    {
        public bool AddEpisode(string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration, int season, int episode, int seriesId);


        public bool EditEpisode(int id, string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration, int season, int episode);


        public List<Episode> GetEpisodes(int seriesid);


        public Episode GetEpisodeById(int id);
       
    }
}
