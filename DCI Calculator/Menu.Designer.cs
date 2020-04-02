namespace DCI_Calculator
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.about = new System.Windows.Forms.Button();
            this.stoneCalc = new System.Windows.Forms.Button();
            this.parcelCalc = new System.Windows.Forms.Button();
            this.news = new System.Windows.Forms.Button();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.stoneCalcLabel = new System.Windows.Forms.Label();
            this.parcelCalcLabel = new System.Windows.Forms.Label();
            this.newsLabel = new System.Windows.Forms.Label();
            this.analysis = new System.Windows.Forms.Button();
            this.analysisLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // about
            // 
            this.about.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("about.BackgroundImage")));
            this.about.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.about.FlatAppearance.BorderSize = 0;
            this.about.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.about.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.about.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.about.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.about.Location = new System.Drawing.Point(65, 41);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(88, 103);
            this.about.TabIndex = 0;
            this.about.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            this.about.MouseLeave += new System.EventHandler(this.about_MouseLeave);
            this.about.MouseHover += new System.EventHandler(this.about_MouseHover);
            // 
            // stoneCalc
            // 
            this.stoneCalc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stoneCalc.BackgroundImage")));
            this.stoneCalc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stoneCalc.FlatAppearance.BorderSize = 0;
            this.stoneCalc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.stoneCalc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.stoneCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stoneCalc.Location = new System.Drawing.Point(200, 41);
            this.stoneCalc.Name = "stoneCalc";
            this.stoneCalc.Size = new System.Drawing.Size(72, 103);
            this.stoneCalc.TabIndex = 1;
            this.stoneCalc.UseVisualStyleBackColor = true;
            this.stoneCalc.MouseLeave += new System.EventHandler(this.stoneCalc_MouseLeave);
            this.stoneCalc.MouseHover += new System.EventHandler(this.stoneCalc_MouseHover);
            // 
            // parcelCalc
            // 
            this.parcelCalc.BackColor = System.Drawing.Color.SkyBlue;
            this.parcelCalc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("parcelCalc.BackgroundImage")));
            this.parcelCalc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.parcelCalc.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.parcelCalc.FlatAppearance.BorderSize = 0;
            this.parcelCalc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.parcelCalc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.parcelCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parcelCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parcelCalc.Location = new System.Drawing.Point(325, 53);
            this.parcelCalc.Name = "parcelCalc";
            this.parcelCalc.Size = new System.Drawing.Size(72, 79);
            this.parcelCalc.TabIndex = 2;
            this.parcelCalc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.parcelCalc.UseVisualStyleBackColor = false;
            this.parcelCalc.Click += new System.EventHandler(this.parcelCalc_Click);
            this.parcelCalc.MouseLeave += new System.EventHandler(this.parcelCalc_MouseLeave);
            this.parcelCalc.MouseHover += new System.EventHandler(this.parcelCalc_MouseHover);
            // 
            // news
            // 
            this.news.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("news.BackgroundImage")));
            this.news.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.news.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.news.FlatAppearance.BorderSize = 0;
            this.news.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.news.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.news.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.news.Location = new System.Drawing.Point(457, 53);
            this.news.Name = "news";
            this.news.Size = new System.Drawing.Size(75, 79);
            this.news.TabIndex = 3;
            this.news.UseVisualStyleBackColor = true;
            this.news.MouseLeave += new System.EventHandler(this.news_MouseLeave);
            this.news.MouseHover += new System.EventHandler(this.news_MouseHover);
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.Location = new System.Drawing.Point(86, 139);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(0, 15);
            this.aboutLabel.TabIndex = 4;
            this.aboutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stoneCalcLabel
            // 
            this.stoneCalcLabel.AutoSize = true;
            this.stoneCalcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stoneCalcLabel.Location = new System.Drawing.Point(180, 139);
            this.stoneCalcLabel.Name = "stoneCalcLabel";
            this.stoneCalcLabel.Size = new System.Drawing.Size(0, 15);
            this.stoneCalcLabel.TabIndex = 5;
            // 
            // parcelCalcLabel
            // 
            this.parcelCalcLabel.AutoSize = true;
            this.parcelCalcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parcelCalcLabel.Location = new System.Drawing.Point(301, 137);
            this.parcelCalcLabel.Name = "parcelCalcLabel";
            this.parcelCalcLabel.Size = new System.Drawing.Size(0, 15);
            this.parcelCalcLabel.TabIndex = 6;
            this.parcelCalcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newsLabel
            // 
            this.newsLabel.AutoSize = true;
            this.newsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newsLabel.Location = new System.Drawing.Point(474, 139);
            this.newsLabel.Name = "newsLabel";
            this.newsLabel.Size = new System.Drawing.Size(0, 15);
            this.newsLabel.TabIndex = 7;
            // 
            // analysis
            // 
            this.analysis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("analysis.BackgroundImage")));
            this.analysis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.analysis.FlatAppearance.BorderSize = 0;
            this.analysis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.analysis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.analysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.analysis.Location = new System.Drawing.Point(592, 53);
            this.analysis.Name = "analysis";
            this.analysis.Size = new System.Drawing.Size(75, 79);
            this.analysis.TabIndex = 8;
            this.analysis.UseVisualStyleBackColor = true;
            this.analysis.MouseLeave += new System.EventHandler(this.analysis_MouseLeave);
            this.analysis.MouseHover += new System.EventHandler(this.analysis_MouseHover);
            // 
            // analysisLabel
            // 
            this.analysisLabel.AutoSize = true;
            this.analysisLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analysisLabel.Location = new System.Drawing.Point(603, 139);
            this.analysisLabel.Name = "analysisLabel";
            this.analysisLabel.Size = new System.Drawing.Size(0, 15);
            this.analysisLabel.TabIndex = 9;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.analysisLabel);
            this.Controls.Add(this.analysis);
            this.Controls.Add(this.newsLabel);
            this.Controls.Add(this.parcelCalcLabel);
            this.Controls.Add(this.stoneCalcLabel);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.news);
            this.Controls.Add(this.parcelCalc);
            this.Controls.Add(this.stoneCalc);
            this.Controls.Add(this.about);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button about;
        private System.Windows.Forms.Button stoneCalc;
        private System.Windows.Forms.Button parcelCalc;
        private System.Windows.Forms.Button news;
        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.Label stoneCalcLabel;
        private System.Windows.Forms.Label parcelCalcLabel;
        private System.Windows.Forms.Label newsLabel;
        private System.Windows.Forms.Button analysis;
        private System.Windows.Forms.Label analysisLabel;
    }
}