using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DCI_Calculator
{
    public partial class Login : Form
    {
        MySqlConnection loginConn;
        string connString;

        public Login()
        {
            InitializeComponent();
            this.ActiveControl = UserIDTextBox;
            UserIDTextBox.Focus();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            connString = "SERVER = 109.203.118.107; PORT = 3306; DATABASE = eleanor_DCI; UID = eleanor_eleanor; PASSWORD = SfZGV@UCxVx-;";

            try
            {
                //TODO add using when creating the new connection in order to verify the connection closes
                loginConn = new MySqlConnection();
                loginConn.ConnectionString = connString;
                loginConn.Open();

                string password = EncryptPassword(PasswordTextBox.Text);

                string query = "Select * from _credentials WHERE User_Name = '" + UserIDTextBox.Text + "' and mdpass = '" + password + "'";
                MySqlCommand loginCmd = new MySqlCommand(query, loginConn);

                MySqlDataAdapter loginData = new MySqlDataAdapter(loginCmd);

                DataTable loginTable = new DataTable();
                loginData.Fill(loginTable);

                bool expired = true;

                if (loginTable.Rows.Count > 0)
                {
                    foreach(DataRow row in loginTable.Rows)
                    {
                        DateTime expDate = row.Field<DateTime>("Expiration");
                        if(expDate > DateTime.Now)
                        {
                            expired = false;
                            this.Hide();
                            Menu mainMenu = new Menu();
                            mainMenu.Show();
                        }
                    }

                    if (expired)
                    {
                        errorMessageLabel.Text = "Your License Expired. Please Contact DCI for Renewal.";
                    }
                }

                else
                {
                    errorMessageLabel.Text = "Wrong User ID or Password";
                }
                loginConn.Close();
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
 
        }

        private string EncryptPassword(string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }

        private bool VerifyMd5Hash(string input, string hash)
        {
            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
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
                OKbutton.PerformClick();
            }
        }
    }
}
