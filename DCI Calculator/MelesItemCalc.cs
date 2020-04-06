using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DCI_Calculator
{
    public partial class MelesItemCalc : Form
    {
        MySqlConnection priceBookConn;
        string connString;

        bool showPriceList;
        SizeAssortment stonesSize;

        public String stoneSizeValue;
        public MelesItemCalc(SizeAssortment s)
        {
            showPriceList = false;
            stonesSize = s;
            InitializeComponent();
            this.stonesLabel.Text = stonesSize.Key.ToString() + " Valuation    " + ParcelCalc.SetValueMine;
            this.totalCtsValueLabel.Text = stonesSize.TotalWeight.ToString();
            this.diffSumValueLabel.Text = stonesSize.CheckEnteredWeight().ToString();
            this.LoadDataBase();
            this.Show();
            PriceListHide();
        }

        private void MelesItemCalc_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataBase()
        {
            connString = "SERVER = 109.203.118.107; PORT = 3306; DATABASE = eleanor_DCI; UID = eleanor_eleanor; PASSWORD = SfZGV@UCxVx-;";

            try
            {
                //TODO add using when creating the new connection in order to verify the connection closes
                priceBookConn = new MySqlConnection();
                priceBookConn.ConnectionString = connString;
                priceBookConn.Open();

                foreach(var g in this.Controls.OfType<GroupBox>())
                {
                    string query = "Select * from _melesItemCalc WHERE size = '" + stonesSize.Key.ToString() + "' and model = '" + g.Tag + "'";               
                    MySqlCommand priceBookCmd = new MySqlCommand(query, priceBookConn);
                    MySqlDataAdapter priceBookData = new MySqlDataAdapter(priceBookCmd);
                    DataTable priceBookTable = new DataTable();
                    priceBookData.Fill(priceBookTable);
                    String name = g.Tag + "TableLayoutPanelPrices";
                    var pricesTable = (TableLayoutPanel)g.Controls[name];
                    
                    for (int row = 1; row < pricesTable.RowCount; ++row)
                    {
                        for (int col = 1; col < pricesTable.ColumnCount; ++col)
                        {
                            TextBox price = (TextBox)pricesTable.GetControlFromPosition(col, row);
                            price.Text = priceBookTable.Rows[row-1].Field<decimal>("price").ToString();
                        }
                    }
                }
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            priceBookConn.Close();
        }

        #region PriceList
        private void priceListButton_Click(object sender, EventArgs e)
        {
            showPriceList = !showPriceList;

            if (showPriceList)
            {
                PriceListShow();
            }
            else
            {
                PriceListHide();
            }
        }

        private void PriceListShow()
        {
            ZHighGroupBox.Size = new Size(759, 178);
            ZHighTableLayoutPanelPrices.Show();
            ZLowGroupBox.Size = new Size(759, 178);
            ZLowTableLayoutPanelPrices.Show();
            MakeableGroupBox.Size = new Size(759, 178);
            MakeableTableLayoutPanelPrices.Show();
            SpottedGroupBox.Size = new Size(759, 178);
            SpottedTableLayoutPanelPrices.Show();
            ClivageGroupBox.Size = new Size(759, 178);
            ClivageTableLayoutPanelPrices.Show();
            RejectionsGroupBox.Size = new Size(759, 178);
            RejectionsTableLayoutPanelPrices.Show();
            BoartGroupBox.Size = new Size(759, 178);
            BoartTableLayoutPanelPrices.Show();
        }

        private void PriceListHide()
        {
            ZHighTableLayoutPanelPrices.Hide();
            ZHighGroupBox.Size = new Size(500, 178);
            ZLowTableLayoutPanelPrices.Hide();
            ZLowGroupBox.Size = new Size(500, 178);
            MakeableTableLayoutPanelPrices.Hide();
            MakeableGroupBox.Size = new Size(500, 178);
            SpottedTableLayoutPanelPrices.Hide();
            SpottedGroupBox.Size = new Size(500, 178);
            ClivageTableLayoutPanelPrices.Hide();
            ClivageGroupBox.Size = new Size(500, 178);
            RejectionsTableLayoutPanelPrices.Hide();
            RejectionsGroupBox.Size = new Size(500, 178);
            BoartTableLayoutPanelPrices.Hide();
            BoartGroupBox.Size = new Size(500, 178);
        }

        #endregion

        private void UpdateTotals()
        {
            stonesSize.UpdateValues();
            this.noStonesValueLabel.Text = stonesSize.NumStones.ToString();
            this.totalCtsValueLabel.Text = stonesSize.TotalWeight.ToString();
            this.ctsValValueLabel.Text = stonesSize.InsertedWeight.ToString();
            this.totalValValueLabel.Text = stonesSize.TotalValue.ToString();
            this.avgPriceValueLabel.Text = stonesSize.AverageValue.ToString();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            int row, col, position;
            double price = 0;
            int stonesNum = 0;
            var textbox = (TextBox)sender;
            if (textbox.Text != "")
            {
                stonesNum = Convert.ToInt32(textbox.Text);
            }
            var table = (TableLayoutPanel)textbox.Parent;
            var groupbox = (GroupBox)table.Parent;
            String name = table.Name + "Prices";
            var pricesTable = (TableLayoutPanel)groupbox.Controls[name];
            StoneModel key = (StoneModel)Enum.Parse(typeof(StoneModel), table.Tag.ToString());
            name = groupbox.Tag.ToString() + "Table";
            var sumTable = (TableLayoutPanel)groupbox.Controls[name];

            row = table.GetRow(textbox);
            col = table.GetColumn(textbox);
            position = row * 10 + col;

            //TODO check prices table was found!
            var priceTextbox = (TextBox)pricesTable.GetControlFromPosition(col, row);

            if (priceTextbox.Text != "")
            {
                price = Convert.ToDouble(priceTextbox.Text);
            }
            else
            {
                price = 0;
            }
            if (stonesSize.items.ContainsKey(key))
            {
                stonesSize.items[key].AddStones(position, stonesNum, price);
                var label = (Label)sumTable.GetControlFromPosition(1, 0); //position of number of stones
                label.Text = stonesSize.items[key].TotalStonesNum.ToString();
                label = (Label)sumTable.GetControlFromPosition(1, 2); //position of average value
                label.Text = stonesSize.items[key].AverageValue.ToString();
                label = (Label)sumTable.GetControlFromPosition(1, 3); //position of total value
                label.Text = stonesSize.items[key].TotalValue.ToString();

                UpdateTotals();
            }

            else
            {
                MessageBox.Show("Please enter Carats Valued for the Model");
                textbox.Text = "";
                return;
            }

        }

        private void AllowOnlyNumbers(KeyPressEventArgs e)
        {
            Char c = e.KeyChar;
            if (!Char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
                MessageBox.Show("Invalid input");
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            var textbox = (TextBox)sender;
            var table = (TableLayoutPanel)textbox.Parent;
            int row = table.GetRow(textbox);
            int col = table.GetColumn(textbox);

            if ((e.KeyCode == Keys.Down) || (e.KeyCode == Keys.Enter))
            {
                if (row < table.RowCount - 1) //if we are not on the last row
                {
                    var nextTextbox = table.GetControlFromPosition(col, row + 1);
                    nextTextbox.Focus();
                }
            }

            if ((e.KeyCode == Keys.Right) || (e.KeyCode == Keys.RShiftKey))
            {
                if (col < table.ColumnCount - 1) //if we are not on the last column
                {
                    var nextTextbox = table.GetControlFromPosition(col + 1, row);
                    nextTextbox.Focus();
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                if (row > 1) //if we are not on the first row
                {
                    var nextTextbox = table.GetControlFromPosition(col, row - 1);
                    nextTextbox.Focus();
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                if (col > 1) //if we are not on the first column
                {
                    var nextTextbox = table.GetControlFromPosition(col - 1, row);
                    nextTextbox.Focus();
                }
            }
        }


        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                var textbox = (TextBox)sender;
                var table = (TableLayoutPanel)textbox.Parent;
                int row = table.GetRow(textbox);
                int col = table.GetColumn(textbox);
                if (row < table.RowCount - 1) //if we are not on the last row
                {
                    var nextTextbox = table.GetControlFromPosition(col, row + 1);
                    nextTextbox.Focus();
                }
            }

            else
            {
                AllowOnlyNumbers(e);
            }
        }

        #region CaratCountTextBox_KeyPress
        private void ZHighCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                ZLowCaratCountValueTextbox.Focus();
            }
        }

        private void ZLowCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                makeableCaratCountValueTextbox.Focus();
            }
        }
        private void MakeableCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                spottedCaratCountValueTextbox.Focus();
            }
        }
        private void SpottedCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                clivageCaratCountValueTextbox.Focus();
            }
        }
        private void ClivageCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                rejectionsCaratCountValueTextbox.Focus();
            }
        }
        private void RejectionsCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                boartCaratCountValueTextbox.Focus();
            }
        }
        private void BoartCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
            }
        }
        #endregion

        private void InsertingWeightsItem(StoneModel m, double w)
        {
            if (!(stonesSize.UpdateItemWeight(m, w)))
            {
                Item newItem = new Item(m, stonesSize.Key, w);
                stonesSize.AddModel(m, newItem);
            }
        }

        private void CaratCountValueTextbox_TextChanged(object sender, EventArgs e)
        {
            double diff;
            var textbox = (TextBox)sender;
            StoneModel key = (StoneModel)Enum.Parse(typeof(StoneModel), textbox.Tag.ToString());
            double weight;

            if (textbox.Text != "")
            {
                weight = Convert.ToDouble(textbox.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsItem(key, weight);

            diff = stonesSize.CheckEnteredWeight();
            this.diffSumValueLabel.Text = diff.ToString();

            if (diff > 0)
            {
                MessageBox.Show("More Carats Valued than on Summary");
            }
        }

        #region BriefMessageBoxes
        private void QU1Label_Click(object sender, EventArgs e)
        {
            MessageBox.Show("D-G Colours, Clean Quality", "Assortment");
        }
        private void QU2Label_Click(object sender, EventArgs e)
        {
            MessageBox.Show("D-G Colours, Very Light Pique\n&\nH-J Colours, Clean", "Assortment");
        }
        private void QU3Label_Click(object sender, EventArgs e)
        {
            MessageBox.Show("H-J Colours, Not Clean\n&\nLight Spotted\n&\nK-L Colours, Clean", "Assortment");
        }
        #endregion
    }
}
