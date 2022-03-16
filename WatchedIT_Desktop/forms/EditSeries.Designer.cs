
namespace WatchedIT_Desktop.forms
{
    partial class EditSeries
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
            this.tbActors = new System.Windows.Forms.RichTextBox();
            this.lblActors = new System.Windows.Forms.Label();
            this.tbProd = new System.Windows.Forms.TextBox();
            this.lblProd = new System.Windows.Forms.Label();
            this.btnEditSeries = new System.Windows.Forms.Button();
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
            this.lblEditSeries = new System.Windows.Forms.Label();
            this.lblMand = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbActors
            // 
            this.tbActors.Location = new System.Drawing.Point(205, 560);
            this.tbActors.Name = "tbActors";
            this.tbActors.Size = new System.Drawing.Size(205, 128);
            this.tbActors.TabIndex = 51;
            this.tbActors.Text = "";
            // 
            // lblActors
            // 
            this.lblActors.AutoSize = true;
            this.lblActors.Location = new System.Drawing.Point(127, 560);
            this.lblActors.Name = "lblActors";
            this.lblActors.Size = new System.Drawing.Size(61, 20);
            this.lblActors.TabIndex = 50;
            this.lblActors.Text = "Actors *";
            // 
            // tbProd
            // 
            this.tbProd.Location = new System.Drawing.Point(205, 316);
            this.tbProd.Name = "tbProd";
            this.tbProd.Size = new System.Drawing.Size(205, 27);
            this.tbProd.TabIndex = 49;
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Location = new System.Drawing.Point(97, 316);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(78, 20);
            this.lblProd.TabIndex = 48;
            this.lblProd.Text = "Producer *";
            // 
            // btnEditSeries
            // 
            this.btnEditSeries.Location = new System.Drawing.Point(239, 743);
            this.btnEditSeries.Name = "btnEditSeries";
            this.btnEditSeries.Size = new System.Drawing.Size(125, 43);
            this.btnEditSeries.TabIndex = 47;
            this.btnEditSeries.Text = "Edit series";
            this.btnEditSeries.UseVisualStyleBackColor = true;
            this.btnEditSeries.Click += new System.EventHandler(this.btnEditSeries_Click);
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(205, 374);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(205, 168);
            this.tbDesc.TabIndex = 46;
            this.tbDesc.Text = "";
            // 
            // tbGenre
            // 
            this.tbGenre.Location = new System.Drawing.Point(205, 259);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(205, 27);
            this.tbGenre.TabIndex = 45;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(205, 195);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(205, 27);
            this.tbUrl.TabIndex = 44;
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(205, 138);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(205, 27);
            this.tbYear.TabIndex = 43;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(205, 80);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(205, 27);
            this.tbName.TabIndex = 42;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(93, 389);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(85, 20);
            this.lblDesc.TabIndex = 41;
            this.lblDesc.Text = "Description";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(97, 259);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(58, 20);
            this.lblGenre.TabIndex = 40;
            this.lblGenre.Text = "Genre *";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(97, 195);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(81, 20);
            this.lblUrl.TabIndex = 39;
            this.lblUrl.Text = "Image URL";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(46, 141);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(153, 20);
            this.lblYear.TabIndex = 38;
            this.lblYear.Text = "Year * (YYYY-DD-MM)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(99, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 20);
            this.lblName.TabIndex = 37;
            this.lblName.Text = "Name *";
            // 
            // lblEditSeries
            // 
            this.lblEditSeries.AutoSize = true;
            this.lblEditSeries.Location = new System.Drawing.Point(250, 27);
            this.lblEditSeries.Name = "lblEditSeries";
            this.lblEditSeries.Size = new System.Drawing.Size(76, 20);
            this.lblEditSeries.TabIndex = 52;
            this.lblEditSeries.Text = "Edit series";
            // 
            // lblMand
            // 
            this.lblMand.AutoSize = true;
            this.lblMand.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMand.ForeColor = System.Drawing.Color.Maroon;
            this.lblMand.Location = new System.Drawing.Point(220, 708);
            this.lblMand.Name = "lblMand";
            this.lblMand.Size = new System.Drawing.Size(162, 20);
            this.lblMand.TabIndex = 53;
            this.lblMand.Text = "* Fields are mandatory!";
            // 
            // EditSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 808);
            this.Controls.Add(this.lblMand);
            this.Controls.Add(this.lblEditSeries);
            this.Controls.Add(this.tbActors);
            this.Controls.Add(this.lblActors);
            this.Controls.Add(this.tbProd);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.btnEditSeries);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "EditSeries";
            this.Text = "EditSeries";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbActors;
        private System.Windows.Forms.Label lblActors;
        private System.Windows.Forms.TextBox tbProd;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Button btnEditSeries;
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
        private System.Windows.Forms.Label lblEditSeries;
        private System.Windows.Forms.Label lblMand;
    }
}