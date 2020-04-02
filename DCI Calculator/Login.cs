using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DCI_Calculator
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.ActiveControl = UserIDTextBox;
            UserIDTextBox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* TODO - fix connection with database - Credentials-temp
             * later link to a proper database of credentials
            SqlConnection loginConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Eleanor\\source\\repos\\DCI Calculator\\DCI Calculator\\Credentials - temp.mdf;Integrated Security=True;User Instance=true");

            SqlCommand loginCmd = new SqlCommand("Select * from Credentials where UserName = '" + UserIDTextBox.Text + "' and Password = '" + PasswordTextBox.Text + "'", loginConn);
            
            SqlDataAdapter loginData = new SqlDataAdapter(loginCmd);

            DataTable loginTable = new DataTable();
            loginData.Fill(loginTable);

            if (loginTable.Rows.Count>0)
            {*/
                this.Hide();
                Menu mainMenu = new Menu();
                mainMenu.Show();
            /*}

            else
            {
                MessageBox.Show("Wrong User ID or Password.");
            }*/
        }

        private void Login_Load(object sender, EventArgs e)
        {
 
        }

        private void UserIDTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                PasswordTextBox.Focus();
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
