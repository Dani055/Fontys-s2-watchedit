
namespace WatchedIT_Desktop.forms
{
    partial class EditMovie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEpisode = new System.Windows.Forms.Label();
            this.lblSeason = new System.Windows.Forms.Label();
            this.tbEpisode = new System.Windows.Forms.NumericUpDown();
            this.tbSeason = new System.Windows.Forms.NumericUpDown();
            this.btnEditMovie = new System.Windows.Forms.Button();
            this.tbDuration = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.RichTextBox();
            this.tbActors = new System.Windows.Forms.RichTextBox();
            this.tbProd = new System.Windows.Forms.TextBox();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblActors = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblProd = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEditMovie = new System.Windows.Forms.Label();
            this.lblMand = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbEpisode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeason)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEpisode
            // 
            this.lblEpisode.AutoSize = true;
            this.lblEpisode.Location = new System.Drawing.Point(282, 805);
            this.lblEpisode.Name = "lblEpisode";
            this.lblEpisode.Size = new System.Drawing.Size(72, 20);
            this.lblEpisode.TabIndex = 61;
            this.lblEpisode.Text = "Episode *";
            // 
            // lblSeason
            // 
            this.lblSeason.AutoSize = true;
            this.lblSeason.Location = new System.Drawing.Point(131, 805);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(66, 20);
            this.lblSeason.TabIndex = 60;
            this.lblSeason.Text = "Season *";
            // 
            // tbEpisode
            // 
            this.tbEpisode.Location = new System.Drawing.Point(360, 803);
            this.tbEpisode.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbEpisode.Name = "tbEpisode";
            this.tbEpisode.Size = new System.Drawing.Size(59, 27);
            this.tbEpisode.TabIndex = 59;
            this.tbEpisode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbSeason
            // 
            this.tbSeason.Location = new System.Drawing.Point(203, 803);
            this.tbSeason.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbSeason.Name = "tbSeason";
            this.tbSeason.Size = new System.Drawing.Size(64, 27);
            this.tbSeason.TabIndex = 58;
            this.tbSeason.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnEditMovie
            // 
            this.btnEditMovie.Location = new System.Drawing.Point(229, 894);
            this.btnEditMovie.Name = "btnEditMovie";
            this.btnEditMovie.Size = new System.Drawing.Size(125, 43);
            this.btnEditMovie.TabIndex = 57;
            this.btnEditMovie.Text = "Edit movie";
            this.btnEditMovie.UseVisualStyleBackColor = true;
            this.btnEditMovie.Click += new System.EventHandler(this.btnEditMovie_Click);
            // 
            // tbDuration
            // 
            this.tbDuration.Location = new System.Drawing.Point(203, 747);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.Size = new System.Drawing.Size(205, 27);
            this.tbDuration.TabIndex = 56;
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(203, 363);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(205, 168);
            this.tbDesc.TabIndex = 55;
            this.tbDesc.Text = "";
            // 
            // tbActors
            // 
            this.tbActors.Location = new System.Drawing.Point(203, 579);
            this.tbActors.Name = "tbActors";
            this.tbActors.Size = new System.Drawing.Size(205, 128);
            this.tbActors.TabIndex = 54;
            this.tbActors.Text = "";
            // 
            // tbProd
            // 
            this.tbProd.Location = new System.Drawing.Point(203, 297);
            this.tbProd.Name = "tbProd";
            this.tbProd.Size = new System.Drawing.Size(205, 27);
            this.tbProd.TabIndex = 53;
            // 
            // tbGenre
            // 
            this.tbGenre.Location = new System.Drawing.Point(203, 247);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(205, 27);
            this.tbGenre.TabIndex = 52;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(203, 190);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(205, 27);
            this.tbUrl.TabIndex = 51;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(36, 750);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(161, 20);
            this.lblDuration.TabIndex = 50;
            this.lblDuration.Text = "Duration * (HH:MM:SS)";
            // 
            // lblActors
            // 
            this.lblActors.AutoSize = true;
            this.lblActors.Location = new System.Drawing.Point(112, 582);
            this.lblActors.Name = "lblActors";
            this.lblActors.Size = new System.Drawing.Size(61, 20);
            this.lblActors.TabIndex = 49;
            this.lblActors.Text = "Actors *";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(91, 363);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(85, 20);
            this.lblDesc.TabIndex = 48;
            this.lblDesc.Text = "Description";
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Location = new System.Drawing.Point(95, 297);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(78, 20);
            this.lblProd.TabIndex = 47;
            this.lblProd.Text = "Producer *";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(115, 247);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(58, 20);
            this.lblGenre.TabIndex = 46;
            this.lblGenre.Text = "Genre *";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(82, 190);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(81, 20);
            this.lblUrl.TabIndex = 45;
            this.lblUrl.Text = "Image URL";
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(203, 140);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(205, 27);
            this.tbYear.TabIndex = 66;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(203, 80);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(205, 27);
            this.tbName.TabIndex = 65;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(44, 143);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(153, 20);
            this.lblYear.TabIndex = 64;
            this.lblYear.Text = "Year * (YYYY-DD-MM)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(97, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 20);
            this.lblName.TabIndex = 63;
            this.lblName.Text = "Name *";
            // 
            // lblEditMovie
            // 
            this.lblEditMovie.AutoSize = true;
            this.lblEditMovie.Location = new System.Drawing.Point(229, 22);
            this.lblEditMovie.Name = "lblEditMovie";
            this.lblEditMovie.Size = new System.Drawing.Size(80, 20);
            this.lblEditMovie.TabIndex = 62;
            this.lblEditMovie.Text = "Edit movie";
            // 
            // lblMand
            // 
            this.lblMand.AutoSize = true;
            this.lblMand.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMand.ForeColor = System.Drawing.Color.Maroon;
            this.lblMand.Location = new System.Drawing.Point(216, 859);
            this.lblMand.Name = "lblMand";
            this.lblMand.Size = new System.Drawing.Size(162, 20);
            this.lblMand.TabIndex = 67;
            this.lblMand.Text = "* Fields are mandatory!";
            // 
            // EditMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 949);
            this.Controls.Add(this.lblMand);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblEditMovie);
            this.Controls.Add(this.lblEpisode);
            this.Controls.Add(this.lblSeason);
            this.Controls.Add(this.tbEpisode);
            this.Controls.Add(this.tbSeason);
            this.Controls.Add(this.btnEditMovie);
            this.Controls.Add(this.tbDuration);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbActors);
            this.Controls.Add(this.tbProd);
            this.Controls.Add(this.tbGenre);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblActors);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "EditMovie";
            this.Text = "EditEpisode";
            ((System.ComponentModel.ISupportInitialize)(this.tbEpisode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeason)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEpisode;
        private System.Windows.Forms.Label lblSeason;
        private System.Windows.Forms.NumericUpDown tbEpisode;
        private System.Windows.Forms.NumericUpDown tbSeason;
        private System.Windows.Forms.Button btnEditMovie;
        private System.Windows.Forms.TextBox tbDuration;
        private System.Windows.Forms.RichTextBox tbDesc;
        private System.Windows.Forms.RichTextBox tbActors;
        private System.Windows.Forms.TextBox tbProd;
        private System.Windows.Forms.TextBox tbGenre;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblActors;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEditMovie;
        private System.Windows.Forms.Label lblMand;
    }
}