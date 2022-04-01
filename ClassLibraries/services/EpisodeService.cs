using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.data_access;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.services
{
    public static class EpisodeService
    {
        public static bool AddEpisode(User loggedUser, string name, string yearStr, string url, string genre, string producer, string desc, string actors, string durationStr, int season, int episode, int seriesId)
        {
            DateTime year;
            TimeSpan duration;
            UserService.IsAdmin(loggedUser);
            MovieService.ValidateMovie(name, genre, producer, actors, yearStr, durationStr);
            DateTime.TryParse(yearStr, out year);
            TimeSpan.TryParse(durationStr, out duration);

            return DataAccessEpisode.AddEpisodeQuery(name, year, url, genre, producer, desc, actors, duration, season, episode, seriesId);
        }

        public static List<Episode> GetEpisodes(int seriesid)
        {
            return DataAccessEpisode.GetEpisodesQuery(seriesid);
        }
        public static Episode GetEpisodeById(int id)
        {
            return DataAccessEpisode.GetEpisodeByIdQuery(id);
        }

    }
}
