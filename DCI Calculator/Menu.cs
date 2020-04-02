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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void parcelCalc_Click(object sender, EventArgs e)
        {
            this.Hide();
            //TODO add instance of class parcel
            //Need to discuss with Luke
            ParcelCalc prcl = new ParcelCalc();
            prcl.Show();
        }

        private void about_MouseHover(object sender, EventArgs e)
        {
            aboutLabel.Text = "About";
        }

        private void about_MouseLeave(object sender, EventArgs e)
        {
            aboutLabel.ResetText();
        }

        private void parcelCalc_MouseHover(object sender, EventArgs e)
        {
            parcelCalcLabel.Text = "Parcel Calculator";
        }

        private void parcelCalc_MouseLeave(object sender, EventArgs e)
        {
            parcelCalcLabel.ResetText();
        }

        private void stoneCalc_MouseHover(object sender, EventArgs e)
        {
            stoneCalcLabel.Text = "Stone Calculator";
        }

        private void stoneCalc_MouseLeave(object sender, EventArgs e)
        {
            stoneCalcLabel.ResetText();
        }

        private void news_MouseHover(object sender, EventArgs e)
        {
            newsLabel.Text = "News";
        }

        private void news_MouseLeave(object sender, EventArgs e)
        {
            newsLabel.ResetText();
        }

        private void analysis_MouseHover(object sender, EventArgs e)
        {
            analysisLabel.Text = "Analysis";
        }

        private void analysis_MouseLeave(object sender, EventArgs e)
        {
            analysisLabel.ResetText();
        }

        private void about_Click(object sender, EventArgs e)
        {
            this.Hide();
            About aboutInfo = new About();
            aboutInfo.Show();
        }
    }
}
