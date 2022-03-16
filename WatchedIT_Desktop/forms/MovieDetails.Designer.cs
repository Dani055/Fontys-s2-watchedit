
namespace WatchedIT_Desktop.forms
{
    partial class MovieDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieDetails));
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblProd = new System.Windows.Forms.Label();
            this.lblStarring = new System.Windows.Forms.Label();
            this.lblProdValue = new System.Windows.Forms.Label();
            this.lblActors = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.panelDesc = new System.Windows.Forms.Panel();
            this.lblDesc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.panelDesc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPhoto
            // 
            this.pbPhoto.Image = ((System.Drawing.Image)(resources.GetObject("pbPhoto.Image")));
            this.pbPhoto.Location = new System.Drawing.Point(12, 12);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(367, 549);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 0;
            this.pbPhoto.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(452, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(452, 70);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 20);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(763, 70);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(48, 20);
            this.lblGenre.TabIndex = 3;
            this.lblGenre.Text = "Genre";
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Location = new System.Drawing.Point(452, 442);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(77, 20);
            this.lblProd.TabIndex = 7;
            this.lblProd.Text = "Producers:";
            // 
            // lblStarring
            // 
            this.lblStarring.AutoSize = true;
            this.lblStarring.Location = new System.Drawing.Point(879, 442);
            this.lblStarring.Name = "lblStarring";
            this.lblStarring.Size = new System.Drawing.Size(64, 20);
            this.lblStarring.TabIndex = 8;
            this.lblStarring.Text = "Starring:";
            // 
            // lblProdValue
            // 
            this.lblProdValue.AutoSize = true;
            this.lblProdValue.Location = new System.Drawing.Point(457, 476);
            this.lblProdValue.Name = "lblProdValue";
            this.lblProdValue.Size = new System.Drawing.Size(18, 20);
            this.lblProdValue.TabIndex = 9;
            this.lblProdValue.Text = "...";
            // 
            // lblActors
            // 
            this.lblActors.AutoSize = true;
            this.lblActors.Location = new System.Drawing.Point(890, 476);
            this.lblActors.Name = "lblActors";
            this.lblActors.Size = new System.Drawing.Size(18, 20);
            this.lblActors.TabIndex = 10;
            this.lblActors.Text = "...";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(56, 573);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(182, 573);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 29);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(452, 357);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(67, 20);
            this.lblDuration.TabIndex = 6;
            this.lblDuration.Text = "Duration";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(1004, 70);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(52, 20);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "Rating";
            // 
            // panelDesc
            // 
            this.panelDesc.Controls.Add(this.lblDesc);
            this.panelDesc.Location = new System.Drawing.Point(452, 111);
            this.panelDesc.Name = "panelDesc";
            this.panelDesc.Padding = new System.Windows.Forms.Padding(20);
            this.panelDesc.Size = new System.Drawing.Size(604, 210);
            this.panelDesc.TabIndex = 29;
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
            // MovieDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1099, 625);
            this.Controls.Add(this.panelDesc);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblActors);
            this.Controls.Add(this.lblProdValue);
            this.Controls.Add(this.lblStarring);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbPhoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MovieDetails";
            this.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.Text = "MovieDetails";
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.panelDesc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Label lblStarring;
        private System.Windows.Forms.Label lblProdValue;
        private System.Windows.Forms.Label lblActors;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Panel panelDesc;
        private System.Windows.Forms.Label lblDesc;
    }
}