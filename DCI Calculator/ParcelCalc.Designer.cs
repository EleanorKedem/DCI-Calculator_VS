namespace DCI_Calculator
{
    partial class ParcelCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParcelCalc));
            this.mineLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.productionLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.valuerLabel = new System.Windows.Forms.Label();
            this.calcDate = new System.Windows.Forms.DateTimePicker();
            this.productionTextBox = new System.Windows.Forms.TextBox();
            this.valuerTextBox = new System.Windows.Forms.TextBox();
            this.mineComboBox = new System.Windows.Forms.ComboBox();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.stonesLabel = new System.Windows.Forms.Label();
            this.stonesComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // mineLabel
            // 
            this.mineLabel.AutoSize = true;
            this.mineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mineLabel.Location = new System.Drawing.Point(155, 85);
            this.mineLabel.Name = "mineLabel";
            this.mineLabel.Size = new System.Drawing.Size(41, 16);
            this.mineLabel.TabIndex = 0;
            this.mineLabel.Text = "Mine";
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLabel.Location = new System.Drawing.Point(155, 45);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(60, 16);
            this.countryLabel.TabIndex = 1;
            this.countryLabel.Text = "Country";
            // 
            // productionLabel
            // 
            this.productionLabel.AutoSize = true;
            this.productionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productionLabel.Location = new System.Drawing.Point(155, 125);
            this.productionLabel.Name = "productionLabel";
            this.productionLabel.Size = new System.Drawing.Size(110, 16);
            this.productionLabel.TabIndex = 2;
            this.productionLabel.Text = "Production No.";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(155, 165);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(41, 16);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "Date";
            // 
            // valuerLabel
            // 
            this.valuerLabel.AutoSize = true;
            this.valuerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valuerLabel.Location = new System.Drawing.Point(155, 205);
            this.valuerLabel.Name = "valuerLabel";
            this.valuerLabel.Size = new System.Drawing.Size(53, 16);
            this.valuerLabel.TabIndex = 4;
            this.valuerLabel.Text = "Valuer";
            // 
            // calcDate
            // 
            this.calcDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcDate.Location = new System.Drawing.Point(295, 165);
            this.calcDate.Name = "calcDate";
            this.calcDate.Size = new System.Drawing.Size(237, 22);
            this.calcDate.TabIndex = 5;
            this.calcDate.Value = new System.DateTime(2020, 1, 2, 11, 10, 33, 0);
            // 
            // productionTextBox
            // 
            this.productionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productionTextBox.Location = new System.Drawing.Point(295, 125);
            this.productionTextBox.Name = "productionTextBox";
            this.productionTextBox.Size = new System.Drawing.Size(237, 22);
            this.productionTextBox.TabIndex = 6;
            // 
            // valuerTextBox
            // 
            this.valuerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valuerTextBox.Location = new System.Drawing.Point(295, 205);
            this.valuerTextBox.Name = "valuerTextBox";
            this.valuerTextBox.Size = new System.Drawing.Size(237, 22);
            this.valuerTextBox.TabIndex = 7;
            // 
            // mineComboBox
            // 
            this.mineComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mineComboBox.FormattingEnabled = true;
            this.mineComboBox.Location = new System.Drawing.Point(295, 85);
            this.mineComboBox.Name = "mineComboBox";
            this.mineComboBox.Size = new System.Drawing.Size(237, 24);
            this.mineComboBox.TabIndex = 8;
            // 
            // countryComboBox
            // 
            this.countryComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(295, 45);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(237, 24);
            this.countryComboBox.TabIndex = 9;
            // 
            // OKbutton
            // 
            this.OKbutton.BackColor = System.Drawing.SystemColors.Control;
            this.OKbutton.FlatAppearance.BorderSize = 3;
            this.OKbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OKbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKbutton.Location = new System.Drawing.Point(373, 303);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 10;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = false;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // stonesLabel
            // 
            this.stonesLabel.AutoSize = true;
            this.stonesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stonesLabel.Location = new System.Drawing.Point(155, 245);
            this.stonesLabel.Name = "stonesLabel";
            this.stonesLabel.Size = new System.Drawing.Size(56, 16);
            this.stonesLabel.TabIndex = 11;
            this.stonesLabel.Text = "Stones";
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
            this.stonesComboBox.Location = new System.Drawing.Point(295, 245);
            this.stonesComboBox.Name = "stonesComboBox";
            this.stonesComboBox.Size = new System.Drawing.Size(237, 24);
            this.stonesComboBox.TabIndex = 12;
            // 
            // ParcelCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stonesComboBox);
            this.Controls.Add(this.stonesLabel);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.countryComboBox);
            this.Controls.Add(this.mineComboBox);
            this.Controls.Add(this.valuerTextBox);
            this.Controls.Add(this.productionTextBox);
            this.Controls.Add(this.calcDate);
            this.Controls.Add(this.valuerLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.productionLabel);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.mineLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ParcelCalc";
            this.Text = "Parcel Details";
            this.Load += new System.EventHandler(this.ParcelCalc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mineLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label productionLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label valuerLabel;
        private System.Windows.Forms.DateTimePicker calcDate;
        private System.Windows.Forms.TextBox productionTextBox;
        private System.Windows.Forms.TextBox valuerTextBox;
        private System.Windows.Forms.ComboBox mineComboBox;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Label stonesLabel;
        private System.Windows.Forms.ComboBox stonesComboBox;
    }
}