using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchedIT_Desktop.logic.services;

namespace WatchedIT_Desktop.forms
{
    public partial class AddMovie : Form
    {
        public AddMovie()
        {
            InitializeComponent();
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
            MovieService.AddMovie(name, year, url, genre, producers, desc, actors, duration);

        }
    }
}
