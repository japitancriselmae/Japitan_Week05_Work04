using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace japitan_Week05_Work04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. SAVE BUTTON (Validation & Calculation)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check kung blangko
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtCost.Text))
            {
                MessageBox.Show("Palihog butangi og Name ug Cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check kung numero
            if (!decimal.TryParse(txtCost.Text, out decimal cost) || !decimal.TryParse(txtMarkup.Text, out decimal markup))
            {
                MessageBox.Show("Numero lamang ang i-type sa Cost ug Markup.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calculation
            decimal price = cost + (cost * (markup / 100));
            txtPrice.Text = price.ToString("0.00");

            MessageBox.Show("Product Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 2. CLEAR BUTTON
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBarcode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtCost.Clear();
            txtMarkup.Clear();
            txtPrice.Clear();

            
            rbLocal.Checked = false;
            rbAbroad.Checked = false;
            // chkActive.Checked = false; // Tangtanga ang // sa unahan kung naa nakay checkbox

            txtBarcode.Focus();
        }

        // 3. CANCEL BUTTON
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Sigurado ka ba nga gusto nimo i-cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // 4. AUTO-CALCULATE 
        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            AutoCalculate();
        }

        private void txtMarkup_TextChanged(object sender, EventArgs e)
        {
            AutoCalculate();
        }

        private void AutoCalculate()
        {
            if (decimal.TryParse(txtCost.Text, out decimal cost) && decimal.TryParse(txtMarkup.Text, out decimal markup))
            {
                decimal price = cost + (cost * (markup / 100));
                txtPrice.Text = price.ToString("0.00");
            }
            else
            {
                txtPrice.Text = "";
            }
        }
    }
}