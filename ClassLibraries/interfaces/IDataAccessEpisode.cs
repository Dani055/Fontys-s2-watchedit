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
        public bool AddEpisodeQuery(string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration, int season, int episode, int seriesId);


        public bool EditEpisodeQuery(int id, string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration, int season, int episode);


        public List<Episode> GetEpisodesQuery(int seriesid);


        public Episode GetEpisodeByIdQuery(int id);
       
    }
}
