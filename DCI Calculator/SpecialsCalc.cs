using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCI_Calculator
{
    public partial class SpecialsCalc : Form
    {
        public String stoneSizeValue;
        public SpecialsCalc(SizeAssortment stone)
        {
            InitializeComponent();
            this.stonesLabel.Text = stone.Key.ToString() + " Valuation    " + ParcelCalc.SetValueMine;
            this.totalCtsValueLabel.Text = stone.TotalWeight.ToString();
            this.Show();
        }

        private void SpecialsCalc_Load(object sender, EventArgs e)
        {
         
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addRowButton_Click(object sender, EventArgs e)
        {
            //TODO add a row to the table - tableLayoutPanel1
        }
    }
}
