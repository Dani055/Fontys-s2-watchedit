
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
            this.lblName.Size = new System.Drawing.Size(49, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(31, 157);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(139, 20);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year(YYYY-DD-MM)";
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
            this.lblGenre.Size = new System.Drawing.Size(48, 20);
            this.lblGenre.TabIndex = 4;
            this.lblGenre.Text = "Genre";
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Location = new System.Drawing.Point(73, 330);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(68, 20);
            this.lblProd.TabIndex = 5;
            this.lblProd.Text = "Producer";
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
            this.lblActors.Size = new System.Drawing.Size(51, 20);
            this.lblActors.TabIndex = 7;
            this.lblActors.Text = "Actors";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(24, 772);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(151, 20);
            this.lblDuration.TabIndex = 8;
            this.lblDuration.Text = "Duration (HH:MM:SS)";
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
            this.btnAddMovie.Location = new System.Drawing.Point(207, 823);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(125, 43);
            this.btnAddMovie.TabIndex = 17;
            this.btnAddMovie.Text = "Add movie";
            this.btnAddMovie.UseVisualStyleBackColor = true;
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click);
            // 
            // AddMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 892);
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
            this.Name = "AddMovie";
            this.Text = "AddMovie";
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
    }
}