using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraries.models
{
    public class Review
    {
        public int Id { get; }
        public int UserId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImg { get; set; }
        public int MovieId { get; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public Review()
        {

        }
        public Review(int id, int userid, string firstname, string lastname, string userimg, int movieid, string description ,int rating)
        {
            Id = id;
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
            UserImg = userimg;
            MovieId = movieid;
            Description = description;
            Rating = rating;
        }
    }
}
