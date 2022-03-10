﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchedIT_Desktop.logic;
using WatchedIT_Desktop.logic.models;
using WatchedIT_Desktop.logic.services;

namespace WatchedIT_Desktop.forms
{
    public partial class EditMovie : Form
    {
        private bool isMovie = true;
        private Movie movie = null;
        public EditMovie(bool isMovie, Movie movie)
        {
            InitializeComponent();
            this.isMovie = isMovie;
            this.movie = movie;
            HideUI();
            LoadInfo();
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
                lblEditMovie.Text = "Edit episode";
                btnEditMovie.Text = "Edit episode";

            }
        }
        private void LoadInfo()
        {
            tbName.Text = movie.Name;
            tbYear.Text = movie.Year.ToString("yyyy-MM-dd");
            tbUrl.Text = movie.ImageUrl;
            tbGenre.Text = movie.Genre;
            tbProd.Text = movie.Producer;
            tbDesc.Text = movie.Description;
            tbActors.Text = movie.Actors;
            tbDuration.Text = movie.Duration.ToString();
            if (movie is Episode)
            {
                tbSeason.Value = ((Episode)movie).SeasonNo;
                tbEpisode.Value = ((Episode)movie).EpisodeNo;
            }
        }

        private void btnEditMovie_Click(object sender, EventArgs e)
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
            string genre = tbGenre.Text.Trim();
            string producers = tbProd.Text.Trim();
            string desc = tbDesc.Text.Trim();
            string actors = tbActors.Text.Trim();
            TimeSpan duration;
            int season = 0;
            int episode = 0;
            s = TimeSpan.TryParse(tbDuration.Text, out duration);
            if (!s)
            {
                MessageBox.Show("Duration not in correct format");
                return;
            }
            if (!isMovie)
            {
                season = Convert.ToInt32(tbSeason.Value);
                episode = Convert.ToInt32(tbEpisode.Value);
            }

            try
            {
                if (MovieService.EditMovieOrEpisode(movie.Id, name, year, url, genre, producers, desc, actors, duration, isMovie, season, episode))
                {
                    if (isMovie)
                    {
                        Utils.ShowInfo("Movie edited successfully!");
                    }
                    else
                    {
                        Utils.ShowInfo("Episode edited successfully!");
                    }
                    Utils.UpdateContent = true;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex.Message);
            }

        }
    }
}
