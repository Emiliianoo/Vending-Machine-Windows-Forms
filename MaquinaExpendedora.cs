using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaquinaExpendedora
{
    public partial class MaquinaExpendedora : Form
    {
        private PaymentMenu paymentMenu = null;

        public MaquinaExpendedora()
        {
            InitializeComponent();
        }

        private void MaquinaExpendedora_Load(object sender, EventArgs e)
        {
            IDSelectorBtn.Visible = false;
            IDSelectorBtn.Enabled = true;

            IDSelectorBtn.Click += IDSelectorBtn_Click;
        }

        private void IDSelectorBtn_Click(object sender, EventArgs e)
        {
            ID_Selector ID_Selector = new ID_Selector();
            ID_Selector.Show();
        }

        private void PaymentMenuBtn_Click(object sender, EventArgs e)
        {
            if (paymentMenu == null || paymentMenu.IsDisposed)
            {
                // If not, create a new instance and show it
                paymentMenu = new PaymentMenu();
                paymentMenu.Show();
            }
            // If already open, bring it to the front
            else
            {
                paymentMenu.BringToFront();
            }
        }
    }
}
