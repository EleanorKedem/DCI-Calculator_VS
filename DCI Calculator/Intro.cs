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
    public partial class Intro : Form
    {
        private static readonly Timer timer = new Timer();

        public Intro()
        {
            InitializeComponent();
        }

        private void Intro_Load(object sender, EventArgs e)
        {
            timer.Interval = 10000;
            timer.Tick += TimerEventProcessor;
            timer.Start();
        }

        void TimerEventProcessor(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
