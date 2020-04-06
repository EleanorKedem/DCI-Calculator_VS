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
    public partial class ItemCalc : Form
    {
        MySqlConnection priceBookConn;
        string connString;

        bool showPriceList;
        SizeAssortment stonesSize;

        public String stoneSizeValue;
        public ItemCalc(SizeAssortment s)
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
            crystalsGroupBox.Size = new Size(1242, 178);
            CrystalsTableLayoutPanelPrices.Show();
            sawableHighGroupBox.Size = new Size(1242, 178);
            SawableHighTableLayoutPanelPrices.Show();
            sawableLowGroupBox.Size = new Size(1242, 178);
            SawableLowTableLayoutPanelPrices.Show();
            makeableHighGroupBox.Size = new Size(1242, 178);
            MakeableHighTableLayoutPanelPrices.Show();
            makeableLowGroupBox.Size = new Size(1242, 178);
            MakeableLowTableLayoutPanelPrices.Show();
            spottedZGroupBox.Size = new Size(1242, 178);
            SpottedZTableLayoutPanelPrices.Show();
            clivageGroupBox.Size = new Size(1242, 178);
            ClivageTableLayoutPanelPrices.Show();
            rejectionsGroupBox.Size = new Size(1242, 178);
            RejectionsTableLayoutPanelPrices.Show();
            boartGroupBox.Size = new Size(1242, 178);
            BoartTableLayoutPanelPrices.Show();
        }

        private void PriceListHide()
        {
            CrystalsTableLayoutPanelPrices.Hide();
            crystalsGroupBox.Size = new Size(740, 178);
            SawableHighTableLayoutPanelPrices.Hide();
            sawableHighGroupBox.Size = new Size(740, 178);
            SawableLowTableLayoutPanelPrices.Hide();
            sawableLowGroupBox.Size = new Size(740, 178);
            MakeableHighTableLayoutPanelPrices.Hide();
            makeableHighGroupBox.Size = new Size(740, 178);
            MakeableLowTableLayoutPanelPrices.Hide();
            makeableLowGroupBox.Size = new Size(740, 178);
            SpottedZTableLayoutPanelPrices.Hide();
            spottedZGroupBox.Size = new Size(740, 178);
            ClivageTableLayoutPanelPrices.Hide();
            clivageGroupBox.Size = new Size(740, 178);
            RejectionsTableLayoutPanelPrices.Hide();
            rejectionsGroupBox.Size = new Size(740, 178);
            BoartTableLayoutPanelPrices.Hide();
            boartGroupBox.Size = new Size(740, 178);
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

                foreach (var g in this.Controls.OfType<GroupBox>())
                {
                    String name = g.Tag + "TableLayoutPanelPrices";
                    var pricesTable = (TableLayoutPanel)g.Controls[name];
                    DataTable priceBookTable = new DataTable();
                    string query;

                    switch (g.Tag)
                    {
                        case "Crystals":
                        case "SawableHigh":
                        case "SawableLow":
                        case "MakeableHigh":
                        case "MakeableLow":
                            query = "Select D, E_F, G, H, I, J_K, cape from _itemCalc WHERE size = '" + stonesSize.Key.ToString() + "' and model = '" + g.Tag + "'";
                            break;
                        case "SpottedZ":
                        case "Clivage":
                            query = "Select 1CR, 2CR, 3CR, cape from _itemCalc WHERE size = '" + stonesSize.Key.ToString() + "' and model = '" + g.Tag + "'";
                            break;
                        case "Rejections":
                            query = "Select Rejection from _itemCalc WHERE size = '" + stonesSize.Key.ToString() + "' and model = '" + g.Tag + "'";
                            break;
                        case "Boart":
                            query = "Select Boart from _itemCalc WHERE size = '" + stonesSize.Key.ToString() + "' and model = '" + g.Tag + "'";
                            break;
                        default:
                            query = "";
                            break;
                    }
                    MySqlCommand priceBookCmd = new MySqlCommand(query, priceBookConn);
                    MySqlDataAdapter priceBookData = new MySqlDataAdapter(priceBookCmd);
                    priceBookData.Fill(priceBookTable);
                    for (int row = 1; row < pricesTable.RowCount; ++row)
                    {
                        for (int col = 1; col < pricesTable.ColumnCount; ++col) 
                        {
                            TextBox price = (TextBox)pricesTable.GetControlFromPosition(col, row);
                            price.Text = priceBookTable.Rows[row - 1][col-1].ToString();
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

        private void textBox_KeyDown(object sender, KeyEventArgs e)
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


        private void ItemCalcTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CrystalsCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                /* TODO - this is not working! Not sure why
                var textbox = (TextBox)sender;
                var table = (TableLayoutPanel)textbox.Parent;
                var groupBox = (GroupBox)table.Parent;
                var nextGroupBox = this.GetNextControl(groupBox, true);
                name = nextGroupBox.Tag.ToString() + "Table";
                var nextTable = (TableLayoutPanel)nextGroupBox.Controls[name];
                var nextTextbox = nextTable.GetControlFromPosition(1, 1); //position of the carat count textbox
                nextTextbox.Focus();
                */

                e.Handled = true;
                sawableHighCaratCountValueTextbox.Focus();
            }
        }

        private void SawableHighCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                sawableLowCaratCountValueTextbox.Focus();
            }
        }
        private void SawableLowCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                makeableHighCaratCountValueTextbox.Focus();
            }
        }
        private void MakeableHighCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                makeableLowCaratCountValueTextbox.Focus();
            }
        }
        private void MakeableLowCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                spottedZCaratCountValueTextbox.Focus();
            }
        }
        private void SpottedZCaratCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                rejectsCaratCountValueTextbox.Focus();
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
    }
}
