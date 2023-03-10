
namespace WatchedIT_Desktop.forms
{
    partial class AddMovie
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
            this.lblAddMovie = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblProd = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblActors = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.tbProd = new System.Windows.Forms.TextBox();
            this.tbActors = new System.Windows.Forms.RichTextBox();
            this.tbDesc = new System.Windows.Forms.RichTextBox();
            this.tbDuration = new System.Windows.Forms.TextBox();
            this.btnAddMovie = new System.Windows.Forms.Button();
            this.lblEpisode = new System.Windows.Forms.Label();
            this.lblSeason = new System.Windows.Forms.Label();
            this.tbEpisode = new System.Windows.Forms.NumericUpDown();
            this.tbSeason = new System.Windows.Forms.NumericUpDown();
            this.lblMand = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbEpisode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeason)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddMovie
            // 
            this.lblAddMovie.AutoSize = true;
            this.lblAddMovie.Location = new System.Drawing.Point(217, 25);
            this.lblAddMovie.Name = "lblAddMovie";
            this.lblAddMovie.Size = new System.Drawing.Size(82, 20);
            this.lblAddMovie.TabIndex = 0;
            this.lblAddMovie.Text = "Add movie";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(75, 94);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name *";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(24, 157);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(153, 20);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year * (YYYY-DD-MM)";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(73, 211);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(81, 20);
            this.lblUrl.TabIndex = 3;
            this.lblUrl.Text = "Image URL";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(73, 275);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(58, 20);
            this.lblGenre.TabIndex = 4;
            this.lblGenre.Text = "Genre *";
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Location = new System.Drawing.Point(73, 330);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(78, 20);
            this.lblProd.TabIndex = 5;
            this.lblProd.Text = "Producer *";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(69, 385);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(85, 20);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Description";
            // 
            // lblActors
            // 
            this.lblActors.AutoSize = true;
            this.lblActors.Location = new System.Drawing.Point(90, 604);
            this.lblActors.Name = "lblActors";
            this.lblActors.Size = new System.Drawing.Size(61, 20);
            this.lblActors.TabIndex = 7;
            this.lblActors.Text = "Actors *";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(14, 769);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(161, 20);
            this.lblDuration.TabIndex = 8;
            this.lblDuration.Text = "Duration * (HH:MM:SS)";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(181, 94);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(205, 27);
            this.tbName.TabIndex = 9;
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(181, 154);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(205, 27);
            this.tbYear.TabIndex = 10;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(181, 211);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(205, 27);
            this.tbUrl.TabIndex = 11;
            // 
            // tbGenre
            // 
            this.tbGenre.Location = new System.Drawing.Point(181, 275);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(205, 27);
            this.tbGenre.TabIndex = 12;
            // 
            // tbProd
            // 
            this.tbProd.Location = new System.Drawing.Point(181, 330);
            this.tbProd.Name = "tbProd";
            this.tbProd.Size = new System.Drawing.Size(205, 27);
            this.tbProd.TabIndex = 13;
            // 
            // tbActors
            // 
            this.tbActors.Location = new System.Drawing.Point(181, 601);
            this.tbActors.Name = "tbActors";
            this.tbActors.Size = new System.Drawing.Size(205, 128);
            this.tbActors.TabIndex = 14;
            this.tbActors.Text = "";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(181, 385);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(205, 168);
            this.tbDesc.TabIndex = 15;
            this.tbDesc.Text = "";
            // 
            // tbDuration
            // 
            this.tbDuration.Location = new System.Drawing.Point(181, 769);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.Size = new System.Drawing.Size(205, 27);
            this.tbDuration.TabIndex = 16;
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.Location = new System.Drawing.Point(207, 912);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(125, 43);
            this.btnAddMovie.TabIndex = 17;
            this.btnAddMovie.Text = "Add movie";
            this.btnAddMovie.UseVisualStyleBackColor = true;
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click);
            // 
            // lblEpisode
            // 
            this.lblEpisode.AutoSize = true;
            this.lblEpisode.Location = new System.Drawing.Point(260, 829);
            this.lblEpisode.Name = "lblEpisode";
            this.lblEpisode.Size = new System.Drawing.Size(72, 20);
            this.lblEpisode.TabIndex = 44;
            this.lblEpisode.Text = "Episode *";
            // 
            // lblSeason
            // 
            this.lblSeason.AutoSize = true;
            this.lblSeason.Location = new System.Drawing.Point(109, 827);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(66, 20);
            this.lblSeason.TabIndex = 43;
            this.lblSeason.Text = "Season *";
            // 
            // tbEpisode
            // 
            this.tbEpisode.Location = new System.Drawing.Point(338, 827);
            this.tbEpisode.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbEpisode.Name = "tbEpisode";
            this.tbEpisode.Size = new System.Drawing.Size(59, 27);
            this.tbEpisode.TabIndex = 42;
            this.tbEpisode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbSeason
            // 
            this.tbSeason.Location = new System.Drawing.Point(181, 825);
            this.tbSeason.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbSeason.Name = "tbSeason";
            this.tbSeason.Size = new System.Drawing.Size(64, 27);
            this.tbSeason.TabIndex = 41;
            this.tbSeason.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMand
            // 
            this.lblMand.AutoSize = true;
            this.lblMand.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblMand.ForeColor = System.Drawing.Color.Maroon;
            this.lblMand.Location = new System.Drawing.Point(181, 879);
            this.lblMand.Name = "lblMand";
            this.lblMand.Size = new System.Drawing.Size(162, 20);
            this.lblMand.TabIndex = 45;
            this.lblMand.Text = "* Fields are mandatory!";
            // 
            // AddMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 967);
            this.Controls.Add(this.lblMand);
            this.Controls.Add(this.lblEpisode);
            this.Controls.Add(this.lblSeason);
            this.Controls.Add(this.tbEpisode);
            this.Controls.Add(this.tbSeason);
            this.Controls.Add(this.btnAddMovie);
            this.Controls.Add(this.tbDuration);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbActors);
            this.Controls.Add(this.tbProd);
            this.Controls.Add(this.tbGenre);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblActors);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAddMovie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AddMovie";
            this.Text = "AddMovie";
            ((System.ComponentModel.ISupportInitialize)(this.tbEpisode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeason)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddMovie;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblActors;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.TextBox tbGenre;
        private System.Windows.Forms.TextBox tbProd;
        private System.Windows.Forms.RichTextBox tbActors;
        private System.Windows.Forms.RichTextBox tbDesc;
        private System.Windows.Forms.TextBox tbDuration;
        private System.Windows.Forms.Button btnAddMovie;
        private System.Windows.Forms.Label lblEpisode;
        private System.Windows.Forms.Label lblSeason;
        private System.Windows.Forms.NumericUpDown tbEpisode;
        private System.Windows.Forms.NumericUpDown tbSeason;
        private System.Windows.Forms.Label lblMand;
    }
}