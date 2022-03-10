using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchedIT_Desktop.logic.models
{
    public class Series
    {
        public int Id { get; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string ImageUrl { get; set; }
        public string Producer { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public string Description { get; set; }

        public Series()
        {

        }
        public Series(int id, string name, DateTime year, string imageurl, string genre, string producer, string desc, string actors)
        {
            Id = id;
            Name = name;
            Year = year;
            ImageUrl = imageurl == "" ? null : imageurl;
            Genre = genre;
            Description = desc;
            Producer = producer;
            Actors = actors;
        }
    }
}
