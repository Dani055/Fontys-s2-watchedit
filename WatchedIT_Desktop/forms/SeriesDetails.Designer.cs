
namespace WatchedIT_Desktop.forms
{
    partial class SeriesDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeriesDetails));
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblActors = new System.Windows.Forms.Label();
            this.lblProdValue = new System.Windows.Forms.Label();
            this.lblStarring = new System.Windows.Forms.Label();
            this.lblProd = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.btnYeet = new System.Windows.Forms.Button();
            this.btnAddEpisode = new System.Windows.Forms.Button();
            this.panelDesc = new System.Windows.Forms.Panel();
            this.flwEpisodes = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.panelDesc.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(23, 567);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 29);
            this.btnEdit.TabIndex = 25;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(-93, 488);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblActors
            // 
            this.lblActors.AutoSize = true;
            this.lblActors.Location = new System.Drawing.Point(883, 389);
            this.lblActors.Name = "lblActors";
            this.lblActors.Size = new System.Drawing.Size(18, 20);
            this.lblActors.TabIndex = 23;
            this.lblActors.Text = "...";
            // 
            // lblProdValue
            // 
            this.lblProdValue.AutoSize = true;
            this.lblProdValue.Location = new System.Drawing.Point(449, 389);
            this.lblProdValue.Name = "lblProdValue";
            this.lblProdValue.Size = new System.Drawing.Size(18, 20);
            this.lblProdValue.TabIndex = 22;
            this.lblProdValue.Text = "...";
            // 
            // lblStarring
            // 
            this.lblStarring.AutoSize = true;
            this.lblStarring.Location = new System.Drawing.Point(872, 355);
            this.lblStarring.Name = "lblStarring";
            this.lblStarring.Size = new System.Drawing.Size(64, 20);
            this.lblStarring.TabIndex = 21;
            this.lblStarring.Text = "Starring:";
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Location = new System.Drawing.Point(444, 355);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(77, 20);
            this.lblProd.TabIndex = 20;
            this.lblProd.Text = "Producers:";
            // 
            // lblDesc
            // 
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc.Location = new System.Drawing.Point(20, 20);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(564, 170);
            this.lblDesc.TabIndex = 18;
            this.lblDesc.Text = "Description";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(922, 54);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(48, 20);
            this.lblGenre.TabIndex = 16;
            this.lblGenre.Text = "Genre";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(444, 54);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 20);
            this.lblYear.TabIndex = 15;
            this.lblYear.Text = "Year";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(438, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 20);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "Name";
            // 
            // pbPhoto
            // 
            this.pbPhoto.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbPhoto.ErrorImage")));
            this.pbPhoto.Image = ((System.Drawing.Image)(resources.GetObject("pbPhoto.Image")));
            this.pbPhoto.Location = new System.Drawing.Point(12, 12);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(367, 549);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 13;
            this.pbPhoto.TabStop = false;
            // 
            // btnYeet
            // 
            this.btnYeet.Location = new System.Drawing.Point(133, 567);
            this.btnYeet.Name = "btnYeet";
            this.btnYeet.Size = new System.Drawing.Size(94, 29);
            this.btnYeet.TabIndex = 26;
            this.btnYeet.Text = "Delete";
            this.btnYeet.UseVisualStyleBackColor = true;
            this.btnYeet.Click += new System.EventHandler(this.btnYeet_Click);
            // 
            // btnAddEpisode
            // 
            this.btnAddEpisode.Location = new System.Drawing.Point(242, 567);
            this.btnAddEpisode.Name = "btnAddEpisode";
            this.btnAddEpisode.Size = new System.Drawing.Size(112, 29);
            this.btnAddEpisode.TabIndex = 27;
            this.btnAddEpisode.Text = "Add episode";
            this.btnAddEpisode.UseVisualStyleBackColor = true;
            this.btnAddEpisode.Click += new System.EventHandler(this.btnAddEpisode_Click);
            // 
            // panelDesc
            // 
            this.panelDesc.Controls.Add(this.lblDesc);
            this.panelDesc.Location = new System.Drawing.Point(406, 101);
            this.panelDesc.Name = "panelDesc";
            this.panelDesc.Padding = new System.Windows.Forms.Padding(20);
            this.panelDesc.Size = new System.Drawing.Size(604, 210);
            this.panelDesc.TabIndex = 28;
            // 
            // flwEpisodes
            // 
            this.flwEpisodes.AutoScroll = true;
            this.flwEpisodes.Location = new System.Drawing.Point(27, 617);
            this.flwEpisodes.Name = "flwEpisodes";
            this.flwEpisodes.Size = new System.Drawing.Size(494, 210);
            this.flwEpisodes.TabIndex = 29;
            // 
            // SeriesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 839);
            this.Controls.Add(this.flwEpisodes);
            this.Controls.Add(this.panelDesc);
            this.Controls.Add(this.btnAddEpisode);
            this.Controls.Add(this.btnYeet);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblActors);
            this.Controls.Add(this.lblProdValue);
            this.Controls.Add(this.lblStarring);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbPhoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SeriesDetails";
            this.Text = "SeriesDetails";
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.panelDesc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblActors;
        private System.Windows.Forms.Label lblProdValue;
        private System.Windows.Forms.Label lblStarring;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Button btnYeet;
        private System.Windows.Forms.Button btnAddEpisode;
        private System.Windows.Forms.Panel panelDesc;
        private System.Windows.Forms.FlowLayoutPanel flwEpisodes;
    }
}