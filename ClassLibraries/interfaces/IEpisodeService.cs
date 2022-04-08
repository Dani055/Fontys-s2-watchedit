using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;

namespace ClassLibraries.interfaces
{
    public interface IEpisodeService
    {
        public bool AddEpisode(User loggedUser, string name, string yearStr, string url, string genre, string producer, string desc, string actors, string durationStr, int season, int episode, int seriesId);
        public List<Episode> GetEpisodes(int seriesid);
        public Episode GetEpisodeById(int id);
    }
}
