
namespace WatchedIT_Desktop.user_controls
{
    partial class EpisodeCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEpisode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEpisode
            // 
            this.lblEpisode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEpisode.Location = new System.Drawing.Point(0, 0);
            this.lblEpisode.Name = "lblEpisode";
            this.lblEpisode.Size = new System.Drawing.Size(291, 42);
            this.lblEpisode.TabIndex = 0;
            this.lblEpisode.Text = "Name - Season - Episode";
            this.lblEpisode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEpisode.Click += new System.EventHandler(this.lblEpisode_Click);
            // 
            // EpisodeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEpisode);
            this.Name = "EpisodeCard";
            this.Size = new System.Drawing.Size(291, 42);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEpisode;
    }
}
