
namespace WatchedIT_Desktop.forms
{
    partial class AddSeries
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
            this.tbDesc = new System.Windows.Forms.RichTextBox();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddMovie = new System.Windows.Forms.Label();
            this.lblAddSeries = new System.Windows.Forms.Label();
            this.btnAddSeries = new System.Windows.Forms.Button();
            this.tbProd = new System.Windows.Forms.TextBox();
            this.lblProd = new System.Windows.Forms.Label();
            this.tbActors = new System.Windows.Forms.RichTextBox();
            this.lblActors = new System.Windows.Forms.Label();
            this.lblMand = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(182, 376);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(205, 168);
            this.tbDesc.TabIndex = 28;
            this.tbDesc.Text = "";
            // 
            // tbGenre
            // 
            this.tbGenre.Location = new System.Drawing.Point(182, 261);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(205, 27);
            this.tbGenre.TabIndex = 26;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(182, 197);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(205, 27);
            this.tbUrl.TabIndex = 25;
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(182, 140);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(205, 27);
            this.tbYear.TabIndex = 24;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(182, 82);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(205, 27);
            this.tbName.TabIndex = 23;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(70, 391);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(85, 20);
            this.lblDesc.TabIndex = 22;
            this.lblDesc.Text = "Description";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(74, 261);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(58, 20);
            this.lblGenre.TabIndex = 20;
            this.lblGenre.Text = "Genre *";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(74, 197);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(81, 20);
            this.lblUrl.TabIndex = 19;
            this.lblUrl.Text = "Image URL";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(23, 143);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(153, 20);
            this.lblYear.TabIndex = 18;
            this.lblYear.Text = "Year * (YYYY-DD-MM)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(76, 82);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 20);
            this.lblName.TabIndex = 17;
            this.lblName.Text = "Name *";
            // 
            // lblAddMovie
            // 
            this.lblAddMovie.AutoSize = true;
            this.lblAddMovie.Location = new System.Drawing.Point(409, -39);
            this.lblAddMovie.Name = "lblAddMovie";
            this.lblAddMovie.Size = new System.Drawing.Size(82, 20);
            this.lblAddMovie.TabIndex = 16;
            this.lblAddMovie.Text = "Add movie";
            // 
            // lblAddSeries
            // 
            this.lblAddSeries.AutoSize = true;
            this.lblAddSeries.Location = new System.Drawing.Point(223, 25);
            this.lblAddSeries.Name = "lblAddSeries";
            this.lblAddSeries.Size = new System.Drawing.Size(78, 20);
            this.lblAddSeries.TabIndex = 31;
            this.lblAddSeries.Text = "Add series";
            // 
            // btnAddSeries
            // 
            this.btnAddSeries.Location = new System.Drawing.Point(223, 748);
            this.btnAddSeries.Name = "btnAddSeries";
            this.btnAddSeries.Size = new System.Drawing.Size(125, 43);
            this.btnAddSeries.TabIndex = 32;
            this.btnAddSeries.Text = "Add series";
            this.btnAddSeries.UseVisualStyleBackColor = true;
            this.btnAddSeries.Click += new System.EventHandler(this.btnAddSeries_Click);
            // 
            // tbProd
            // 
            this.tbProd.Location = new System.Drawing.Point(182, 318);
            this.tbProd.Name = "tbProd";
            this.tbProd.Size = new System.Drawing.Size(205, 27);
            this.tbProd.TabIndex = 34;
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Location = new System.Drawing.Point(74, 318);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(78, 20);
            this.lblProd.TabIndex = 33;
            this.lblProd.Text = "Producer *";
            // 
            // tbActors
            // 
            this.tbActors.Location = new System.Drawing.Point(182, 562);
            this.tbActors.Name = "tbActors";
            this.tbActors.Size = new System.Drawing.Size(205, 128);
            this.tbActors.TabIndex = 36;
            this.tbActors.Text = "";
            // 
            // lblActors
            // 
            this.lblActors.AutoSize = true;
            this.lblActors.Location = new System.Drawing.Point(104, 562);
            this.lblActors.Name = "lblActors";
            this.lblActors.Size = new System.Drawing.Size(61, 20);
            this.lblActors.TabIndex = 35;
            this.lblActors.Text = "Actors *";
            // 
            // lblMand
            // 
            this.lblMand.AutoSize = true;
            this.lblMand.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMand.ForeColor = System.Drawing.Color.Maroon;
            this.lblMand.Location = new System.Drawing.Point(208, 714);
            this.lblMand.Name = "lblMand";
            this.lblMand.Size = new System.Drawing.Size(162, 20);
            this.lblMand.TabIndex = 37;
            this.lblMand.Text = "* Fields are mandatory!";
            // 
            // AddSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 803);
            this.Controls.Add(this.lblMand);
            this.Controls.Add(this.tbActors);
            this.Controls.Add(this.lblActors);
            this.Controls.Add(this.tbProd);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.btnAddSeries);
            this.Controls.Add(this.lblAddSeries);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbGenre);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAddMovie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AddSeries";
            this.Text = "AddSeries";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbDesc;
        private System.Windows.Forms.TextBox tbGenre;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddMovie;
        private System.Windows.Forms.Label lblAddSeries;
        private System.Windows.Forms.Button btnAddSeries;
        private System.Windows.Forms.TextBox tbProd;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.RichTextBox tbActors;
        private System.Windows.Forms.Label lblActors;
        private System.Windows.Forms.Label lblMand;
    }
}