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
    public partial class PaymentMenu : Form
    {
        private MainMenu MenuPrincipal = null;
        private int CashAmount = 0;
        private double TotalAmountDeposited = 0;
        public PaymentMenu()
        {
            InitializeComponent();
        }

        public PaymentMenu(Form callingForm)
        {
            MenuPrincipal = callingForm as MainMenu;
            InitializeComponent();
        }

        private void btnClosePopup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HidePanels()
        {
            CashPaymentPanel.Visible = false;
            Size = new Size(325, Size.Height);
        }

        private void CashBtn_Click(object sender, EventArgs e)
        {
            if(CashPaymentPanel.Visible)
            {
                HidePanels();
                return;
            }

            CashPaymentPanel.Visible = true;
            Size = new Size(794, Size.Height);
        }

        private void AddCashAmount(int amount)
        {
            CashAmount += amount;
            CashAmountLabel.Text = $"${CashAmount.ToString()}.00";
        }

        private void peso1_Click(object sender, EventArgs e)
        {
            AddCashAmount(1);
        }

        private void peso2_Click(object sender, EventArgs e)
        {
            AddCashAmount(2);
        }

        private void peso5_Click(object sender, EventArgs e)
        {
            AddCashAmount(5);
        }

        private void peso10_Click(object sender, EventArgs e)
        {
            AddCashAmount(10);
        }

        private void peso20_Click(object sender, EventArgs e)
        {
            AddCashAmount(20);
        }

        private void peso50_Click(object sender, EventArgs e)
        {
            AddCashAmount(50);
        }

        private void peso100_Click(object sender, EventArgs e)
        {
            AddCashAmount(100);
        }

        private void peso200_Click(object sender, EventArgs e)
        {
            AddCashAmount(200);
        }

        private void DeleteButtonCash_MouseEnter(object sender, EventArgs e)
        {
            DeleteButtonCash.BackColor = Color.Firebrick;
        }

        private void DeleteButtonCash_MouseLeave(object sender, EventArgs e)
        {
            DeleteButtonCash.BackColor = Color.Silver;
        }

        private void DeleteButtonCash_Click(object sender, EventArgs e)
        {
            CashAmount = 0;
            CashAmountLabel.Text = "$0.00";
            MessageBox.Show("Se ha retirado el dinero ingresado de forma correcta.", "Retiro con éxito.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AcceptButtonCash_MouseEnter(object sender, EventArgs e)
        {
            AcceptButtonCash.BackColor = Color.YellowGreen;
        }

        private void AcceptButtonCash_MouseLeave(object sender, EventArgs e)
        {
            AcceptButtonCash.BackColor = Color.Silver;
        }

        private void AcceptButtonCash_Click(object sender, EventArgs e)
        {
            TotalAmountDeposited += CashAmount;
            this.MenuPrincipal.AddCashAmount(TotalAmountDeposited);
            MessageBox.Show($"Se ha depositado ${CashAmount.ToString()}.00 de forma correcta.", "Depósito con éxito.",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
