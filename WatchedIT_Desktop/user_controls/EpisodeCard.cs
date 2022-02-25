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
    public partial class EpisodeCard : UserControl
    {
        private int id;
        private string name;
        private int seasonNo;
        private int episodeNo;
        private SeriesDetails sd;

        public EpisodeCard(int id, string name, int season, int episode, SeriesDetails form)
        {
            InitializeComponent();
            this.id = id;
            this.name = name;
            seasonNo = season;
            episodeNo = episode;
            sd = form;
            lblEpisode.Text = $"{this.name}: Season {seasonNo} - Episode {episodeNo}";
        }

        private void lblEpisode_Click(object sender, EventArgs e)
        {
            sd.goToEpisodeDetails(id);
        }
    }
}
