using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchedIT_Desktop.logic.models
{
    public class Episode : Movie
    {
        public int SeriesId { get;}
        public int SeasonNo { get; set; }
        public int EpisodeNo { get; set; }

        public Episode(int id, string name, DateTime year, string imageurl, string genre, string producer, string desc, string actors, TimeSpan duration, int seriesId, int season, int episode) : base(id, name, year, imageurl, genre, producer, desc, actors, duration)
        {
            SeriesId = seriesId;
            SeasonNo = season;
            EpisodeNo = episode;
        }
    }
}
