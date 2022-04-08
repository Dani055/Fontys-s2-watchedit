using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.data_access;
using ClassLibraries.interfaces;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IMovieService movieService;
        private readonly IDataAccessEpisode dataAccessEpisode;
        public EpisodeService(IMovieService movieService, IDataAccessEpisode dataAccessEpisode)
        {
            this.movieService = movieService;
            this.dataAccessEpisode = dataAccessEpisode;
        }
        public bool AddEpisode(User loggedUser, string name, string yearStr, string url, string genre, string producer, string desc, string actors, string durationStr, int season, int episode, int seriesId)
        {
            DateTime year;
            TimeSpan duration;
            UserService.IsAdmin(loggedUser);
            movieService.ValidateMovie(name, genre, producer, actors, yearStr, durationStr);
            DateTime.TryParse(yearStr, out year);
            TimeSpan.TryParse(durationStr, out duration);

            return dataAccessEpisode.AddEpisodeQuery(name, year, url, genre, producer, desc, actors, duration, season, episode, seriesId);
        }

        public List<Episode> GetEpisodes(int seriesid)
        {
            return dataAccessEpisode.GetEpisodesQuery(seriesid);
        }
        public Episode GetEpisodeById(int id)
        {
            return dataAccessEpisode.GetEpisodeByIdQuery(id);
        }

    }
}
