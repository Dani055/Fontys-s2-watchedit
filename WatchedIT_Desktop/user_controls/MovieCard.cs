using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchedIT_Desktop.forms;

namespace WatchedIT_Desktop.user_controls
{
    public partial class MovieCard : UserControl
    {
        private int id;
        private string imageUrl;
        private string movieName;
        private Home home;
        private bool isMovie;

        public int Id {
            get { return id; }
            set {id = value; } 
        }
        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value;
                if (imageUrl != null)
                {
                    pbPhoto.Load(imageUrl);
                }

            }
        }
        public string MovieName
        {
            get { return movieName; }
            set { movieName = value; lblName.Text = value; }
        }
        public MovieCard(int id, string imageurl, string moviename, Home parent, bool ismovie)
        {
            InitializeComponent();
            this.Id = id;
            ImageUrl = imageurl;
            MovieName = moviename;
            this.home = parent;
            this.isMovie = ismovie;
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            if (isMovie)
            {
                home.GoToMovieDetails(Id);
            }
            else
            {
                home.GoToSeriesDetails(Id);
            }
            
        }

        private void pbPhoto_Click(object sender, EventArgs e)
        {
            if (isMovie)
            {
                home.GoToMovieDetails(Id);
            }
            else
            {
                home.GoToSeriesDetails(Id);
            }
        }
    }
}
