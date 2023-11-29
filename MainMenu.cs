using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaquinaExpendedora.Methods;

namespace MaquinaExpendedora
{
    public partial class MainMenu : Form
    {
        bool toggleIDMenu = false;
        private double TotalAmountDeposited = 0;
        private PaymentMenu paymentMenu = null;

        public void ModifyIDlabel()
        {
            CurrentID.Text = MainControl.ID;
        }

        public void ModifyDepositedLabel()
        {
            TotalDepositedLabel.Text = $"${MainControl.TotalAmountDeposited}";
        }

        public MainMenu()
        {
            InitializeComponent();
        }

        public void AddCashAmount(double amount)
        {
            TotalAmountDeposited += amount;
            TotalDepositedLabel.Text = $"${TotalAmountDeposited.ToString()}.00";
            Console.WriteLine(TotalAmountDeposited);
        }

        private void MaquinaExpendedora_Load(object sender, EventArgs e)
        {

        }

        private void PaymentMenuBtn_Click(object sender, EventArgs e)
        {
            if (MainControl.PurchaseOnGoing()) return;

            // Check if the form is already open
            if (paymentMenu == null || paymentMenu.IsDisposed)
            {
                // If not, create a new instance and show it
                paymentMenu = new PaymentMenu(this);
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
        }

        private void IDSelectorBtn_MouseLeave(object sender, EventArgs e)
        {
            IDSelectorBtn.BackColor = Color.Silver;
        }

        private void PaymentMenuBtn_MouseEnter(object sender, EventArgs e)
        {
            PaymentMenuBtn.BackColor = Color.GreenYellow;
        }

        private void PaymentMenuBtn_MouseLeave(object sender, EventArgs e)
        {
            PaymentMenuBtn.BackColor = Color.Silver;
        }

        public void ToggleIDMenu()
        {
            toggleIDMenu = !toggleIDMenu;

            Size = new Size(
                toggleIDMenu ? 750 : 460,
                Size.Height);

            IDSelectorPanel.Visible = toggleIDMenu;
        }

        private void IDSelectorBtn_Click(object sender, EventArgs e)
        {
            if (MainControl.PurchaseOnGoing()) return;

            if (MainControl.TotalAmountDeposited <= 0)
            {
                MessageBox.Show("Porfavor de ingresar dinero antes de seleccionar un ID.", "¡Error!",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ToggleIDMenu();
        }

        private bool IDFull()
        {
            if (MainControl.ID.Length == 2) return true;
            return false;
        }

        private void ID_1_Click(object sender, EventArgs e)
        {
            ModifyID("1");
        }

        private void ID_2_Click(object sender, EventArgs e)
        {
            ModifyID("2");
        }

        private void ID_3_Click(object sender, EventArgs e)
        {
            ModifyID("3");
        }

        private void ID_A_Click(object sender, EventArgs e)
        {
            ModifyID("A");
        }

        private void ID_B_Click(object sender, EventArgs e)
        {
            ModifyID("B");
        }

        private void ID_C_Click(object sender, EventArgs e)
        {
            ModifyID("C");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            MainControl.ClearID();
            CurrentID.Text = MainControl.ID;
        }

        private void ModifyID(string btnText)
        {
            MainControl.ModifyID(btnText);
            CurrentID.Text = MainControl.ID;
        }

        private void DeleteButton_MouseEnter(object sender, EventArgs e)
        {
            DeleteButton.BackColor = Color.Firebrick;
        }

        private void DeleteButton_MouseLeave(object sender, EventArgs e)
        {
            DeleteButton.BackColor = Color.Silver;
        }

        private void AcceptButton_MouseEnter(object sender, EventArgs e)
        {
            AcceptButton.BackColor = Color.YellowGreen;
        }

        private void AcceptButton_MouseLeave(object sender, EventArgs e)
        {
            AcceptButton.BackColor = Color.Silver;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            MainControl.ToggleIDLock();
            if (MainControl.ID == "")
            {
                MessageBox.Show("Porfavor de ingresar un ID antes de continuar.", "¡Error!",
                                                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainControl.ToggleIDLock();
                return;
            }

            // If the ID is not valid
            if(!MainControl.IDExists())
            {
                MessageBox.Show("El ID proporcionado no es válido.", "¡Error!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainControl.ToggleIDLock();
                MainControl.ClearID();
                return;
            }


            double itemPrice = MainControl.getItemPrice();
            int itemAmount = MainControl.getItemAmount();
            string itemName = MainControl.getItemName();
            
            // If the item is not available
            if (itemAmount <= 0)
            {
                MessageBox.Show("El producto seleccionado no se encuentra disponible.", "¡Error!",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainControl.ToggleIDLock();
                return;
            }

            // If the user has not deposited enough money
            if (MainControl.TotalAmountDeposited < itemPrice)
            {
                MessageBox.Show($"El dinero ingresado no es suficiente para comprar el producto seleccionado. Devolviendo: ${TotalAmountDeposited}", "¡Error!",
                                                                      MessageBoxButtons.OK, MessageBoxIcon.Error);

                TotalAmountDeposited = 0;
                TotalDepositedLabel.Text = "$0.00";
                MainControl.ToggleIDLock();

                return;
            }

            ProcessPayment processPayment = new ProcessPayment(this);
            processPayment.Show();
        }

        public void ClearID()
        {
            if(MainControl.PurchaseOnGoing()) return;

            MainControl.ClearID();
            CurrentID.Text = "";
        }

        private void MainMenu_Enter(object sender, EventArgs e)
        {
            //Refresh all the labels
            string id = MainControl.ID;
            CurrentID.Text = id;
            TotalDepositedLabel.Text = $"${MainControl.TotalAmountDeposited.ToString()}.00";
        }
    }
}
