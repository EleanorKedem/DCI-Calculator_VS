namespace DCI_Calculator
{
    partial class StoneSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoneSelector));
            this.stonesComboBox = new System.Windows.Forms.ComboBox();
            this.headingLabel = new System.Windows.Forms.Label();
            this.OKbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stonesComboBox
            // 
            this.stonesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stonesComboBox.FormattingEnabled = true;
            this.stonesComboBox.Items.AddRange(new object[] {
            "Specials",
            "10CT",
            "9CT",
            "8CT",
            "7CT",
            "6CT",
            "5CT",
            "4CT",
            "3CT",
            "10GR",
            "8GR",
            "6GR",
            "4GR",
            "3GR",
            "2PCT",
            "4PCT",
            "-9 +7",
            "-7 +5"});
            this.stonesComboBox.Location = new System.Drawing.Point(131, 74);
            this.stonesComboBox.Name = "stonesComboBox";
            this.stonesComboBox.Size = new System.Drawing.Size(146, 24);
            this.stonesComboBox.TabIndex = 14;
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingLabel.Location = new System.Drawing.Point(102, 28);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(205, 24);
            this.headingLabel.TabIndex = 15;
            this.headingLabel.Text = "Choose Size to Work";
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(171, 131);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 16;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // StoneSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 200);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.headingLabel);
            this.Controls.Add(this.stonesComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StoneSelector";
            this.Text = "Stones Size Selector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox stonesComboBox;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Button OKbutton;
    }
}