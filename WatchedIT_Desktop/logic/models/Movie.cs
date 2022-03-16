using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchedIT_Desktop.logic.models
{
    public class Movie
    {
        public int Id { get; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }
        public string Actors { get; set; }
        public TimeSpan Duration { get; set; }

        public Movie()
        {

        }
        public Movie(int id, string name, DateTime year, string imageurl, string genre, string producer, string desc, string actors, TimeSpan duration)
        {
            Id = id;
            Name = name;
            Year = year;
            ImageUrl = imageurl == "" ? null : imageurl;
            Genre = genre;
            Producer = producer;
            Description = desc;
            Actors = actors;
            Duration = duration;
        }

    }
}
