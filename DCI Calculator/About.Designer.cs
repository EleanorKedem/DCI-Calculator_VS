namespace DCI_Calculator
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.aboutLabel = new System.Windows.Forms.Label();
            this.aboutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.aboutHeadlineLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aboutLabel
            // 
            this.aboutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.Location = new System.Drawing.Point(38, 153);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(677, 242);
            this.aboutLabel.TabIndex = 0;
            this.aboutLabel.Text = resources.GetString("aboutLabel.Text");
            // 
            // aboutLinkLabel
            // 
            this.aboutLinkLabel.AutoSize = true;
            this.aboutLinkLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLinkLabel.Location = new System.Drawing.Point(38, 411);
            this.aboutLinkLabel.Name = "aboutLinkLabel";
            this.aboutLinkLabel.Size = new System.Drawing.Size(317, 20);
            this.aboutLinkLabel.TabIndex = 1;
            this.aboutLinkLabel.TabStop = true;
            this.aboutLinkLabel.Text = "https://www.diamondcounsellor.com/";
            this.aboutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLinkLabel_LinkClicked);
            // 
            // aboutHeadlineLabel
            // 
            this.aboutHeadlineLabel.AutoSize = true;
            this.aboutHeadlineLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutHeadlineLabel.Location = new System.Drawing.Point(109, 9);
            this.aboutHeadlineLabel.Name = "aboutHeadlineLabel";
            this.aboutHeadlineLabel.Size = new System.Drawing.Size(504, 120);
            this.aboutHeadlineLabel.TabIndex = 2;
            this.aboutHeadlineLabel.Text = "The leading international \r\nauthority on rough diamond \r\nvaluations";
            this.aboutHeadlineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aboutHeadlineLabel);
            this.Controls.Add(this.aboutLinkLabel);
            this.Controls.Add(this.aboutLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.LinkLabel aboutLinkLabel;
        private System.Windows.Forms.Label aboutHeadlineLabel;
    }
}