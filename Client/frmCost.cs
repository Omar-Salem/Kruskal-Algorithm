using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kruskal
{
    public partial class frmCost : Form
    {
        public int _cost;

        public frmCost()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtCost.Text == string.Empty)
            {
                errorProvider1.SetError(txtCost, "please enter value");
            }
            else
            {
                _cost = int.Parse(txtCost.Text);
                this.Close();
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar);
        }
    }
}
