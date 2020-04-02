using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/// <summary>
/// TODO enter command moves focus to the next line
/// </summary>

namespace DCI_Calculator
{
    public partial class Summary : Form
    {
        private int [] subtotalRows;
        private int[] standaloneRows;


        public Parcel parcel;
        public String valuer;

        public Summary()
        {
            InitializeComponent();
            subtotalRows = new int[] { 8, 12, 18 };
            standaloneRows = new int[] { 1, 13 };
            this.headingLabel.Text = ParcelCalc.SetValueMine + "  Production " + ParcelCalc.SetValueProdction + "  Valuation Summary";
        }

        private void Summary_Activated(object sender, EventArgs e)
        {
            SummaryUpdate();
        }

        private void SummaryUpdate()
        {
            UpdateGrandTotal();
            UpdateSubTotals();
            for (int row=1, size = 0; row<summaryTable.RowCount; ++row)
            {
                if (subtotalRows.Contains(row))
                {
                    continue;
                }
                else
                {
                    if (parcel.MyParcel.ContainsKey((StoneSize)size))
                    {
                        var label = summaryTable.GetControlFromPosition(2, row); //average value column
                        label.Text = "$" + parcel.MyParcel[(StoneSize)size].AverageValue.ToString("0.##");
                        label = summaryTable.GetControlFromPosition(3, row); //Total value column
                        label.Text = "$" + parcel.MyParcel[(StoneSize)size].TotalValue.ToString("0.##");
                        label = summaryTable.GetControlFromPosition(4, row); //percent of weight
                        label.Text = parcel.MyParcel[(StoneSize)size].PercentWeight.ToString("0.##") + "%";
                        label = summaryTable.GetControlFromPosition(5, row); //percent of value
                        label.Text = parcel.MyParcel[(StoneSize)size].PercentValue.ToString("0.##") + "%";
                    }

                    ++size;
                }
            }
        }

        private void UpdateSubTotals()
        {
            foreach(int i in subtotalRows)
            {
                var subtotalLabel = (Label)summaryTable.GetControlFromPosition(1, i); //carats column
                StoneSubgroup group = (StoneSubgroup)Enum.Parse(typeof(StoneSubgroup), subtotalLabel.Tag.ToString());
                subtotalLabel.Text = parcel.CalculateSubtotalWeight(group).ToString();
                subtotalLabel = (Label)summaryTable.GetControlFromPosition(2, i); //average price column
                subtotalLabel.Text = parcel.CalculateSubtotalAverageValue(group).ToString(); 
                subtotalLabel = (Label)summaryTable.GetControlFromPosition(3, i); //value column
                subtotalLabel.Text = parcel.CalculateSubtotalValue(group).ToString(); 
                subtotalLabel = (Label)summaryTable.GetControlFromPosition(4, i); //percent of weight column
                subtotalLabel.Text = parcel.CalculateSubtotalPercentWeight(group).ToString() + "%";
                subtotalLabel = (Label)summaryTable.GetControlFromPosition(5, i); //percent of value column
                subtotalLabel.Text = parcel.CalculateSubtotalPercentValue(group).ToString() + "%";
            }
        }

        private void UpdateGrandTotal ()
        {
            this.labelGrandTotalCarats.Text = parcel.CalculateTotalWeight().ToString("0.##");
            this.labelGrandTotalValue.Text = "$ " + parcel.CalculateTotalValue().ToString("0.##");
            this.labelGrandTotalAvPrice.Text = "$ " + parcel.CalculateAverageValue().ToString("0.##");
            this.labelGrandTotalPrice.Text = parcel.SumPercentValue().ToString("0.##") + "%";
        }

        private void UpdatePercent()
        {
            int row, size;
            parcel.CalculateAllPercent();

            for (row = 1, size = 0; (row < summaryTable.RowCount) && (size < Enum.GetNames(typeof(StoneSize)).Length); ++row)
            {
                if (subtotalRows.Contains(row))
                    continue;

                else
                {
                    if (parcel.MyParcel.ContainsKey((StoneSize)size))
                    {
                        summaryTable.GetControlFromPosition(4, row).Text = parcel.MyParcel[(StoneSize)size].PercentWeight.ToString("0.##") + "%";
                    }
                    else
                    {
                        summaryTable.GetControlFromPosition(4, row).Text = "0%";
                    }
                    ++size;
                }
                this.labelGrandTotalCaratsPC.Text = parcel.SumPercent().ToString() + "%";

            }
        }

        private void AllowOnlyNumbers (KeyPressEventArgs e)
        {
            Char c = e.KeyChar;
            if(!Char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
                MessageBox.Show("Invalid input");
            }
        }

        private void SummaryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                var textbox = (TextBox)sender;
                var table = (TableLayoutPanel)textbox.Parent;
                int row = table.GetRow(textbox);
                int col = table.GetColumn(textbox);

                if (subtotalRows.Contains(row+1))
                    ++row;

                if (row == (table.RowCount-2)) //we reached the last row
                    return;

                var nextTextbox = (TextBox)table.GetControlFromPosition(col, row + 1);
                nextTextbox.Focus();

                UpdateGrandTotal(); //at the moment this line is redundant
                UpdateSubTotals(); //at the moment this line is redundant
            }
            else
            {
                AllowOnlyNumbers(e);
            }
        }

        private void InsertingWeightsSize(StoneSize s, double w)
        {
            if (!(parcel.UpdateSizeWeight(s, w)))
            {
                SizeAssortment newSize = new SizeAssortment(s, w, valuer);
                parcel.AddSize(s, newSize);
            }

            UpdateGrandTotal();
            UpdateSubTotals();
        }

        #region TextBoxChange

        private void specialsTextBox_TextChanged(object sender, EventArgs e)
        {
            double weight;
            
            if (specialsTextBox.Text != "")
            {
                weight = Convert.ToDouble(specialsTextBox.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.Specials, weight);

            UpdatePercent();
        }


        private void textBox10CT_TextChanged(object sender, EventArgs e)
        {
            double weight;
            
            if (textBox10CT.Text != "")
            {
                weight = Convert.ToDouble(textBox10CT.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.CT10, weight);

            UpdatePercent();
        }

        private void textBox9CT_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox9CT.Text != "")
            {
                weight = Convert.ToDouble(textBox9CT.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.CT9, weight);

            UpdatePercent();
        }

        private void textBox8CT_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if(textBox8CT.Text != "")
            {
                weight = Convert.ToDouble(textBox8CT.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.CT8, weight);

            UpdatePercent();
        }

        private void textBox7CT_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox7CT.Text != "")
            {
                weight = Convert.ToDouble(textBox7CT.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.CT7, weight);

            UpdatePercent();
        }

        private void textBox6CT_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox6CT.Text != "")
            {
                weight = Convert.ToDouble(textBox6CT.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.CT6, weight);

            UpdatePercent();
        }
        private void textBox5CT_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox5CT.Text != "")
            {
                weight = Convert.ToDouble(textBox5CT.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.CT5, weight);

            UpdatePercent();
        }

        private void textBox4CT_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox4CT.Text != "")
            {
                weight = Convert.ToDouble(textBox4CT.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.CT4, weight);

            UpdatePercent();
        }

        private void textBox3CT_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox3CT.Text != "")
            {
                weight = Convert.ToDouble(textBox3CT.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.CT3, weight);

            UpdatePercent();
        }

        private void textBox10GR_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox10GR.Text != "")
            {
                weight = Convert.ToDouble(textBox10GR.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.GR10, weight);

            UpdatePercent();
        }

        private void textBox8GR_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox8GR.Text != "")
            {
                weight = Convert.ToDouble(textBox8GR.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.GR8, weight);

            UpdatePercent();
        }

        private void textBox6GR_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox6GR.Text != "")
            {
                weight = Convert.ToDouble(textBox6GR.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.GR6, weight);

            UpdatePercent();
        }

        private void textBox5GR_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox5GR.Text != "")
            {
                weight = Convert.ToDouble(textBox5GR.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.GR5, weight);

            UpdatePercent();
        }

        private void textBox4GR_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox4GR.Text != "")
            {
                weight = Convert.ToDouble(textBox4GR.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.GR4, weight);

            UpdatePercent();
        }
        private void textBox3GR_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox3GR.Text != "")
            {
                weight = Convert.ToDouble(textBox3GR.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.GR3, weight);

            UpdatePercent();
        }

        private void textBoxPCT2_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox2perCT.Text != "")
            {
                weight = Convert.ToDouble(textBox2perCT.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.PCT2, weight);

            UpdatePercent();
        }

        private void textBoxPCT4_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBox4perCT.Text != "")
            {
                weight = Convert.ToDouble(textBox4perCT.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.PCT4, weight);

            UpdatePercent();
        }

        private void textBoxMinus9plus7_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBoxminus9plus7.Text != "")
            {
                weight = Convert.ToDouble(textBoxminus9plus7.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.minus9plus7, weight);

            UpdatePercent();
        }

        private void textBoxMinus7plus5_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBoxminus7plus5.Text != "")
            {
                weight = Convert.ToDouble(textBoxminus7plus5.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.minus7plus5, weight);

            UpdatePercent();
        }
        private void textBoxMinus5plus3_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBoxminus5plus3.Text != "")
            {
                weight = Convert.ToDouble(textBoxminus5plus3.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.minus5plus3, weight);

            UpdatePercent();
        }

        private void textBoxMinus3plus1_TextChanged(object sender, EventArgs e)
        {
            double weight;

            if (textBoxminus3plus1.Text != "")
            {
                weight = Convert.ToDouble(textBoxminus3plus1.Text);
            }

            else
            {
                weight = 0;
            }

            InsertingWeightsSize(StoneSize.minus3plus1, weight);

            UpdatePercent();
        }

        #endregion

        /*====================================================================================================
         * 
         * 
         * TODO make sure we don't open double instances from the same form - focus on a form that was already
         * opened - one form per size!!
         * 
         * 
         * ===================================================================================================
         */

        private void SpecialsLabel_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            StoneSize key = (StoneSize)Enum.Parse(typeof(StoneSize), label.Tag.ToString());

            if(parcel.MyParcel.ContainsKey(key) && (parcel.MyParcel[key].TotalWeight > 0))
            {
                SpecialsCalc specials = new SpecialsCalc(parcel.MyParcel[key]);
                specials.Show();
            }


            else
            {
                MessageBox.Show("Value not inserted for the chosen size");
            }            
        }

        private void ItemLabel_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            StoneSize key = (StoneSize)Enum.Parse(typeof(StoneSize), label.Tag.ToString());

            if (parcel.MyParcel.ContainsKey(key) && (parcel.MyParcel[key].TotalWeight > 0))
            {
                ItemCalc item = new ItemCalc(parcel.MyParcel[key]);
                item.Show();
            }


            else
            {
                MessageBox.Show("Value not inserted for the chosen size");
            }
        }

        private void SmallItemLabel_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            StoneSize key = (StoneSize)Enum.Parse(typeof(StoneSize), label.Tag.ToString());

            if (parcel.MyParcel.ContainsKey(key) && (parcel.MyParcel[key].TotalWeight > 0))
            {
                SmallItemCalc item = new SmallItemCalc(parcel.MyParcel[key]);
                item.Show();
            }


            else
            {
                MessageBox.Show("Value not inserted for the chosen size");
            }
        }
        private void MelesItemLabel_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            StoneSize key = (StoneSize)Enum.Parse(typeof(StoneSize), label.Tag.ToString());

            if (parcel.MyParcel.ContainsKey(key) && (parcel.MyParcel[key].TotalWeight > 0))
            {
                MelesItemCalc item = new MelesItemCalc(parcel.MyParcel[key]);
                item.Show();
            }


            else
            {
                MessageBox.Show("Value not inserted for the chosen size");
            }
        }

        #region LabelsMouseEvents
        private void specialsLabel_MouseEnter(object sender, EventArgs e)
        {
            specialsLabel.ForeColor = Color.Red;
        }
        private void specialsLabel_MouseLeave(object sender, EventArgs e)
        {
            specialsLabel.ForeColor = Color.FromArgb(128, 128, 255);
        }
        private void label10CT_MouseEnter(object sender, EventArgs e)
        {
            label10CT.ForeColor = Color.Red;
        }
        private void label10CT_MouseLeave(object sender, EventArgs e)
        {
            label10CT.ForeColor = Color.Black;
        }
        private void label9CT_MouseEnter(object sender, EventArgs e)
        {
            label9CT.ForeColor = Color.Red;
        }
        private void label9CT_MouseLeave(object sender, EventArgs e)
        {
            label9CT.ForeColor = Color.Black;
        }
        private void label8CT_MouseEnter(object sender, EventArgs e)
        {
            label8CT.ForeColor = Color.Red;
        }
        private void label8CT_MouseLeave(object sender, EventArgs e)
        {
            label8CT.ForeColor = Color.Black;
        }
        private void label7CT_MouseEnter(object sender, EventArgs e)
        {
            label7CT.ForeColor = Color.Red;
        }
        private void label7CT_MouseLeave(object sender, EventArgs e)
        {
            label7CT.ForeColor = Color.Black;
        }
        private void label6CT_MouseEnter(object sender, EventArgs e)
        {
            label6CT.ForeColor = Color.Red;
        }
        private void label6CT_MouseLeave(object sender, EventArgs e)
        {
            label6CT.ForeColor = Color.Black;
        }
        private void label5CT_MouseEnter(object sender, EventArgs e)
        {
            label5CT.ForeColor = Color.Red;
        }
        private void label5CT_MouseLeave(object sender, EventArgs e)
        {
            label5CT.ForeColor = Color.Black;
        }
        private void label4CT_MouseEnter(object sender, EventArgs e)
        {
            label4CT.ForeColor = Color.Red;
        }
        private void label4CT_MouseLeave(object sender, EventArgs e)
        {
            label4CT.ForeColor = Color.Black;
        }
        private void label3CT_MouseEnter(object sender, EventArgs e)
        {
            label3CT.ForeColor = Color.Red;
        }
        private void label3CT_MouseLeave(object sender, EventArgs e)
        {
            label3CT.ForeColor = Color.Black;
        }
        private void label10GR_MouseEnter(object sender, EventArgs e)
        {
            label10GR.ForeColor = Color.Red;
        }
        private void label10GR_MouseLeave(object sender, EventArgs e)
        {
            label10GR.ForeColor = Color.Black;
        }
        private void label8GR_MouseEnter(object sender, EventArgs e)
        {
            label8GR.ForeColor = Color.Red;
        }
        private void label8GR_MouseLeave(object sender, EventArgs e)
        {
            label8GR.ForeColor = Color.FromArgb(128, 128, 255);
        }
        private void label6GR_MouseEnter(object sender, EventArgs e)
        {
            label6GR.ForeColor = Color.Red;
        }
        private void label6GR_MouseLeave(object sender, EventArgs e)
        {
            label6GR.ForeColor = Color.Black;
        }
        private void label5GR_MouseEnter(object sender, EventArgs e)
        {
            label5GR.ForeColor = Color.Red;
        }
        private void label5GR_MouseLeave(object sender, EventArgs e)
        {
            label5GR.ForeColor = Color.Black;
        }
        private void label4GR_MouseEnter(object sender, EventArgs e)
        {
            label4GR.ForeColor = Color.Red;
        }
        private void label4GR_MouseLeave(object sender, EventArgs e)
        {
            label4GR.ForeColor = Color.Black;
        }
        private void label3GR_MouseEnter(object sender, EventArgs e)
        {
            label3GR.ForeColor = Color.Red;
        }
        private void label3GR_MouseLeave(object sender, EventArgs e)
        {
            label3GR.ForeColor = Color.Black;
        }
        private void label2perCT_MouseEnter(object sender, EventArgs e)
        {
            label2perCT.ForeColor = Color.Red;
        }

        private void label2perCT_MouseLeave(object sender, EventArgs e)
        {
            label2perCT.ForeColor = Color.Black;
        }
        private void label4perCT_MouseEnter(object sender, EventArgs e)
        {
            label4perCT.ForeColor = Color.Red;
        }
        private void label4perCT_MouseLeave(object sender, EventArgs e)
        {
            label4perCT.ForeColor = Color.Black;
        }

        private void labelminus9plus7_MouseEnter(object sender, EventArgs e)
        {
            labelminus9plus7.ForeColor = Color.Red;
        }
        private void labelminus9plus7_MouseLeave(object sender, EventArgs e)
        {
            labelminus9plus7.ForeColor = Color.Black;
        }

        private void labelminus7plus5_MouseEnter(object sender, EventArgs e)
        {
            labelminus7plus5.ForeColor = Color.Red;
        }

        private void labelminus7plus5_MouseLeave(object sender, EventArgs e)
        {
            labelminus7plus5.ForeColor = Color.Black;
        }

        private void labelminus5plus3_MouseEnter(object sender, EventArgs e)
        {
            labelminus5plus3.ForeColor = Color.Red;
        }

        private void labelminus5plus3_MouseLeave(object sender, EventArgs e)
        {
            labelminus5plus3.ForeColor = Color.Black;
        }

        private void labelminus3plus1_MouseEnter(object sender, EventArgs e)
        {
            labelminus3plus1.ForeColor = Color.Red;
        }

        private void labelminus3plus1_MouseLeave(object sender, EventArgs e)
        {
            labelminus3plus1.ForeColor = Color.Black;
        }
        #endregion

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                using(Stream s = File.Open(saveFile.FileName, FileMode.OpenOrCreate))
                using(StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(parcel);
                }
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {

        }
    }
}