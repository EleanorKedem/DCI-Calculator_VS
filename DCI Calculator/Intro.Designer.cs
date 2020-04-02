namespace DCI_Calculator
{
    partial class Intro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Intro));
            this.DCI_logo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DCI_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // DCI_logo
            // 
            this.DCI_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DCI_logo.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DCI_logo.Image = ((System.Drawing.Image)(resources.GetObject("DCI_logo.Image")));
            this.DCI_logo.Location = new System.Drawing.Point(272, 111);
            this.DCI_logo.Name = "DCI_logo";
            this.DCI_logo.Size = new System.Drawing.Size(206, 85);
            this.DCI_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.DCI_logo.TabIndex = 0;
            this.DCI_logo.TabStop = false;
            this.DCI_logo.UseWaitCursor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(349, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "CALCULATOR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Intro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DCI_logo);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Intro";
            this.Text = "DCI Calculator";
            this.Load += new System.EventHandler(this.Intro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DCI_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DCI_logo;
        private System.Windows.Forms.Button button1;
    }
}

