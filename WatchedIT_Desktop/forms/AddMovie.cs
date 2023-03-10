using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraries;
using ClassLibraries.models;
using ClassLibraries.services;

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
                lblAddMovie.Text = "Add episode";
                btnAddMovie.Text = "Add episode";

            }
        }
        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string yearStr = tbYear.Text;
            string durationStr = tbDuration.Text;
            string url = tbUrl.Text;
            string genre = tbGenre.Text.Trim();
            string producers = tbProd.Text.Trim();
            string desc = tbDesc.Text.Trim();
            string actors = tbActors.Text.Trim();


            bool result = false;
            try
            {
                if (isMovie)
                {
                    result = MovieService.AddMovie(name, yearStr, url, genre, producers, desc, actors, durationStr);
                }
                else
                {
                    int season = Convert.ToInt32(tbSeason.Value);
                    int episode = Convert.ToInt32(tbEpisode.Value);
                    result = EpisodeService.AddEpisode(name, yearStr, url, genre, producers, desc, actors, durationStr, season, episode, seriesId);
                }
                if (result)
                {
                    Utils.UpdateContent = true;
                    if (isMovie)
                    {
                        MessageHelper.ShowInfo("Movie added successfully!");
                    }
                    else
                    {
                        MessageHelper.ShowInfo("Episode added successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }
        }
    }
}
