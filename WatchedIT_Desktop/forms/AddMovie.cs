using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchedIT_Desktop.logic;
using WatchedIT_Desktop.logic.services;

namespace WatchedIT_Desktop.forms
{
    public partial class AddMovie : Form
    {
        private bool isMovie = true;
        private int seriesId;

        public AddMovie()
        {
            InitializeComponent();
            HideUI();

        }
        public AddMovie(bool ismovie, int seriesid)
        {
            InitializeComponent();
            isMovie = ismovie;
            seriesId = seriesid;
            HideUI();
            
        }
        private void HideUI()
        {
            if (isMovie)
            {
                lblSeason.Visible = false;
                lblEpisode.Visible = false;
                tbEpisode.Visible = false;
                tbSeason.Visible = false;
            }
            else
            {
                lblAddMovie.Text = "Add series";
                btnAddMovie.Text = "Add series";

            }
        }
        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            DateTime year;
            bool s = DateTime.TryParse(tbYear.Text, out year);
            if (!s)
            {
                MessageBox.Show("Date not in correct format");
                return;
            }
            string url = tbUrl.Text;
            string genre = tbGenre.Text;
            string producers = tbProd.Text;
            string desc = tbDesc.Text;
            string actors = tbActors.Text;
            TimeSpan duration;
            s = TimeSpan.TryParse(tbDuration.Text, out duration);
            if (!s)
            {
                MessageBox.Show("Duration not in correct format");
                return;
            }
            if (isMovie)
            {
                MovieService.AddMovie(name, year, url, genre, producers, desc, actors, duration);
            }
            else
            {
                int season = Convert.ToInt32(tbSeason.Value);
                int episode = Convert.ToInt32(tbEpisode.Value);
                EpisodeService.AddEpisode(name, year, url, genre, producers, desc, actors, duration, season, episode, seriesId);
            }
            Utils.UpdateContent = true;

        }
    }
}
