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
        private ID_Selector ID_Selector = null;
        private Dictionary<string, double> _prices = new Dictionary<string, double>
        {
            { "1A", 21.00 }, { "2A", 20.00 }, { "3A", 21.00 },
            { "1B", 23.00 }, { "2B", 22.00 }, { "3B", 23.00 },
            { "1C", 25.00 }, { "2C", 24.00 }, { "3C", 25.00}
        };

        public MaquinaExpendedora()
        {
            InitializeComponent();
        }

        private void MaquinaExpendedora_Load(object sender, EventArgs e)
        {

        }

        private void IDSelectorBtn_Click(object sender, EventArgs e)
        {
            if (ID_Selector == null || ID_Selector.IsDisposed)
            {
                // If not, create a new instance and show it
                ID_Selector = new ID_Selector();
                ID_Selector.Show();
            }
            // If already open, bring it to the front
            else
            {
                ID_Selector.BringToFront();
            }
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

        private void IDSelectorBtn_MouseEnter(object sender, EventArgs e)
        {
            IDSelectorBtn.BackColor = Color.GreenYellow;
            IDSelectorBtn.ForeColor = Color.Black;
        }

        private void IDSelectorBtn_MouseLeave(object sender, EventArgs e)
        {
            IDSelectorBtn.BackColor = Color.FromArgb(255, 64, 64, 64);
            IDSelectorBtn.ForeColor = Color.White;
        }

        private void PaymentMenuBtn_MouseEnter(object sender, EventArgs e)
        {
            PaymentMenuBtn.BackColor = Color.GreenYellow;
            PaymentMenuBtn.ForeColor = Color.Black;
        }

        private void PaymentMenuBtn_MouseLeave(object sender, EventArgs e)
        {
            PaymentMenuBtn.BackColor = Color.FromArgb(255, 64, 64, 64);
            PaymentMenuBtn.ForeColor = Color.White;
        }
    }
}
