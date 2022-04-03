
namespace WatchedIT_Desktop.forms
{
    partial class Home
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnAddMovie = new System.Windows.Forms.Button();
            this.btnAddSeries = new System.Windows.Forms.Button();
            this.btnShowMovies = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLoadMore = new System.Windows.Forms.Label();
            this.btnShowSeries = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.advancedSearch = new System.Windows.Forms.TabControl();
            this.filtersTab = new System.Windows.Forms.TabPage();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.lblFilterYear = new System.Windows.Forms.Label();
            this.nmRatingTo = new System.Windows.Forms.NumericUpDown();
            this.nmYearFrom = new System.Windows.Forms.NumericUpDown();
            this.nmRatingFrom = new System.Windows.Forms.NumericUpDown();
            this.nmYearTo = new System.Windows.Forms.NumericUpDown();
            this.sortingTab = new System.Windows.Forms.TabPage();
            this.rbRatingDesc = new System.Windows.Forms.RadioButton();
            this.rbRatingAsc = new System.Windows.Forms.RadioButton();
            this.rbNameDesc = new System.Windows.Forms.RadioButton();
            this.rbNameAsc = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.advancedSearch.SuspendLayout();
            this.filtersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmRatingTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmYearFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmRatingFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmYearTo)).BeginInit();
            this.sortingTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1137, 23);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(101, 33);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(948, 126);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 20);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.Location = new System.Drawing.Point(877, 55);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(94, 29);
            this.btnAddMovie.TabIndex = 7;
            this.btnAddMovie.Text = "Add movie";
            this.btnAddMovie.UseVisualStyleBackColor = true;
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click);
            // 
            // btnAddSeries
            // 
            this.btnAddSeries.Location = new System.Drawing.Point(986, 54);
            this.btnAddSeries.Name = "btnAddSeries";
            this.btnAddSeries.Size = new System.Drawing.Size(94, 29);
            this.btnAddSeries.TabIndex = 8;
            this.btnAddSeries.Text = "Add series";
            this.btnAddSeries.UseVisualStyleBackColor = true;
            this.btnAddSeries.Click += new System.EventHandler(this.btnAddSeries_Click);
            // 
            // btnShowMovies
            // 
            this.btnShowMovies.Location = new System.Drawing.Point(30, 44);
            this.btnShowMovies.Name = "btnShowMovies";
            this.btnShowMovies.Size = new System.Drawing.Size(74, 39);
            this.btnShowMovies.TabIndex = 9;
            this.btnShowMovies.Text = "Movies";
            this.btnShowMovies.UseVisualStyleBackColor = true;
            this.btnShowMovies.Click += new System.EventHandler(this.btnShowMovies_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(20, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1209, 552);
            this.panel1.TabIndex = 16;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1209, 512);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblLoadMore);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 515);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1209, 37);
            this.panel2.TabIndex = 7;
            // 
            // lblLoadMore
            // 
            this.lblLoadMore.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblLoadMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLoadMore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoadMore.Location = new System.Drawing.Point(0, 0);
            this.lblLoadMore.Name = "lblLoadMore";
            this.lblLoadMore.Size = new System.Drawing.Size(1209, 37);
            this.lblLoadMore.TabIndex = 0;
            this.lblLoadMore.Text = "Load more...";
            this.lblLoadMore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLoadMore.Click += new System.EventHandler(this.lblLoadMore_Click);
            // 
            // btnShowSeries
            // 
            this.btnShowSeries.Location = new System.Drawing.Point(110, 44);
            this.btnShowSeries.Name = "btnShowSeries";
            this.btnShowSeries.Size = new System.Drawing.Size(79, 40);
            this.btnShowSeries.TabIndex = 11;
            this.btnShowSeries.Text = "Series";
            this.btnShowSeries.UseVisualStyleBackColor = true;
            this.btnShowSeries.Click += new System.EventHandler(this.btnShowSeries_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(275, 60);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(56, 20);
            this.lblSearch.TabIndex = 12;
            this.lblSearch.Text = "Search:";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(337, 57);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(164, 27);
            this.tbSearch.TabIndex = 13;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(355, 108);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 38);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search movies";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // advancedSearch
            // 
            this.advancedSearch.Controls.Add(this.filtersTab);
            this.advancedSearch.Controls.Add(this.sortingTab);
            this.advancedSearch.Location = new System.Drawing.Point(564, 23);
            this.advancedSearch.Name = "advancedSearch";
            this.advancedSearch.SelectedIndex = 0;
            this.advancedSearch.Size = new System.Drawing.Size(282, 197);
            this.advancedSearch.TabIndex = 17;
            // 
            // filtersTab
            // 
            this.filtersTab.Controls.Add(this.lblGenre);
            this.filtersTab.Controls.Add(this.lblTo);
            this.filtersTab.Controls.Add(this.lblFrom);
            this.filtersTab.Controls.Add(this.label2);
            this.filtersTab.Controls.Add(this.tbGenre);
            this.filtersTab.Controls.Add(this.lblFilterYear);
            this.filtersTab.Controls.Add(this.nmRatingTo);
            this.filtersTab.Controls.Add(this.nmYearFrom);
            this.filtersTab.Controls.Add(this.nmRatingFrom);
            this.filtersTab.Controls.Add(this.nmYearTo);
            this.filtersTab.Location = new System.Drawing.Point(4, 29);
            this.filtersTab.Name = "filtersTab";
            this.filtersTab.Padding = new System.Windows.Forms.Padding(3);
            this.filtersTab.Size = new System.Drawing.Size(274, 164);
            this.filtersTab.TabIndex = 0;
            this.filtersTab.Text = "Filters";
            this.filtersTab.UseVisualStyleBackColor = true;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(51, 122);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(48, 20);
            this.lblGenre.TabIndex = 28;
            this.lblGenre.Text = "Genre";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(183, 17);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(25, 20);
            this.lblTo.TabIndex = 27;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(80, 17);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(43, 20);
            this.lblFrom.TabIndex = 26;
            this.lblFrom.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Rating";
            // 
            // tbGenre
            // 
            this.tbGenre.Location = new System.Drawing.Point(114, 119);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(125, 27);
            this.tbGenre.TabIndex = 2;
            // 
            // lblFilterYear
            // 
            this.lblFilterYear.AutoSize = true;
            this.lblFilterYear.Location = new System.Drawing.Point(15, 46);
            this.lblFilterYear.Name = "lblFilterYear";
            this.lblFilterYear.Size = new System.Drawing.Size(37, 20);
            this.lblFilterYear.TabIndex = 24;
            this.lblFilterYear.Text = "Year";
            // 
            // nmRatingTo
            // 
            this.nmRatingTo.Location = new System.Drawing.Point(172, 77);
            this.nmRatingTo.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmRatingTo.Name = "nmRatingTo";
            this.nmRatingTo.Size = new System.Drawing.Size(78, 27);
            this.nmRatingTo.TabIndex = 21;
            // 
            // nmYearFrom
            // 
            this.nmYearFrom.Location = new System.Drawing.Point(80, 44);
            this.nmYearFrom.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nmYearFrom.Name = "nmYearFrom";
            this.nmYearFrom.Size = new System.Drawing.Size(70, 27);
            this.nmYearFrom.TabIndex = 22;
            // 
            // nmRatingFrom
            // 
            this.nmRatingFrom.Location = new System.Drawing.Point(80, 77);
            this.nmRatingFrom.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmRatingFrom.Name = "nmRatingFrom";
            this.nmRatingFrom.Size = new System.Drawing.Size(69, 27);
            this.nmRatingFrom.TabIndex = 20;
            // 
            // nmYearTo
            // 
            this.nmYearTo.Location = new System.Drawing.Point(172, 44);
            this.nmYearTo.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nmYearTo.Name = "nmYearTo";
            this.nmYearTo.Size = new System.Drawing.Size(78, 27);
            this.nmYearTo.TabIndex = 23;
            // 
            // sortingTab
            // 
            this.sortingTab.Controls.Add(this.rbRatingDesc);
            this.sortingTab.Controls.Add(this.rbRatingAsc);
            this.sortingTab.Controls.Add(this.rbNameDesc);
            this.sortingTab.Controls.Add(this.rbNameAsc);
            this.sortingTab.Location = new System.Drawing.Point(4, 29);
            this.sortingTab.Name = "sortingTab";
            this.sortingTab.Padding = new System.Windows.Forms.Padding(3);
            this.sortingTab.Size = new System.Drawing.Size(274, 164);
            this.sortingTab.TabIndex = 1;
            this.sortingTab.Text = "Sorting";
            this.sortingTab.UseVisualStyleBackColor = true;
            // 
            // rbRatingDesc
            // 
            this.rbRatingDesc.AutoSize = true;
            this.rbRatingDesc.Location = new System.Drawing.Point(145, 100);
            this.rbRatingDesc.Name = "rbRatingDesc";
            this.rbRatingDesc.Size = new System.Drawing.Size(110, 24);
            this.rbRatingDesc.TabIndex = 3;
            this.rbRatingDesc.Text = "Rating desc.";
            this.rbRatingDesc.UseVisualStyleBackColor = true;
            // 
            // rbRatingAsc
            // 
            this.rbRatingAsc.AutoSize = true;
            this.rbRatingAsc.Location = new System.Drawing.Point(22, 100);
            this.rbRatingAsc.Name = "rbRatingAsc";
            this.rbRatingAsc.Size = new System.Drawing.Size(101, 24);
            this.rbRatingAsc.TabIndex = 2;
            this.rbRatingAsc.Text = "Rating asc.";
            this.rbRatingAsc.UseVisualStyleBackColor = true;
            // 
            // rbNameDesc
            // 
            this.rbNameDesc.AutoSize = true;
            this.rbNameDesc.Location = new System.Drawing.Point(145, 33);
            this.rbNameDesc.Name = "rbNameDesc";
            this.rbNameDesc.Size = new System.Drawing.Size(99, 24);
            this.rbNameDesc.TabIndex = 1;
            this.rbNameDesc.Text = "Name Z-A";
            this.rbNameDesc.UseVisualStyleBackColor = true;
            // 
            // rbNameAsc
            // 
            this.rbNameAsc.AutoSize = true;
            this.rbNameAsc.Checked = true;
            this.rbNameAsc.Location = new System.Drawing.Point(22, 33);
            this.rbNameAsc.Name = "rbNameAsc";
            this.rbNameAsc.Size = new System.Drawing.Size(99, 24);
            this.rbNameAsc.TabIndex = 0;
            this.rbNameAsc.TabStop = true;
            this.rbNameAsc.Text = "Name A-Z";
            this.rbNameAsc.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1249, 810);
            this.Controls.Add(this.advancedSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnAddSeries);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnShowSeries);
            this.Controls.Add(this.btnAddMovie);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnShowMovies);
            this.Controls.Add(this.lblUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Home";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.advancedSearch.ResumeLayout(false);
            this.filtersTab.ResumeLayout(false);
            this.filtersTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmRatingTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmYearFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmRatingFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmYearTo)).EndInit();
            this.sortingTab.ResumeLayout(false);
            this.sortingTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnAddMovie;
        private System.Windows.Forms.Button btnAddSeries;
        private System.Windows.Forms.Button btnShowMovies;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowSeries;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLoadMore;
        private System.Windows.Forms.TabControl advancedSearch;
        private System.Windows.Forms.TabPage filtersTab;
        private System.Windows.Forms.NumericUpDown nmRatingTo;
        private System.Windows.Forms.NumericUpDown nmYearFrom;
        private System.Windows.Forms.NumericUpDown nmRatingFrom;
        private System.Windows.Forms.NumericUpDown nmYearTo;
        private System.Windows.Forms.TabPage sortingTab;
        private System.Windows.Forms.TextBox tbGenre;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFilterYear;
        private System.Windows.Forms.RadioButton rbRatingDesc;
        private System.Windows.Forms.RadioButton rbRatingAsc;
        private System.Windows.Forms.RadioButton rbNameDesc;
        private System.Windows.Forms.RadioButton rbNameAsc;
    }
}