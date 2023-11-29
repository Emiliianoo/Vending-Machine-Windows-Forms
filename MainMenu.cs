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
    public partial class MainMenu : Form
    {
        bool toggleIDMenu = false;
        bool IDLocked = false;
        private string ID = "";
        private double TotalAmountDeposited = 0;
        private PaymentMenu paymentMenu = null;
        private Dictionary<string, (double Price, int Amount, string Name)> _itemsInfo = new Dictionary<string, (double, int, string)>
        {
            { "1A", (21.00, 5, "Coca Cola") },
            { "2A", (20.00, 2, "Sprite") },
            { "3A", (20.00, 1, "Pepsi") },
            { "1B", (23.00, 3, "DrPepper") },
            { "2B", (22.00, 3, "Ruffles") },
            { "3B", (23.00, 2, "Sabritas") },
            { "1C", (25.00, 1, "Gansito") },
            { "2C", (24.00, 5, "Barritas") },
            { "3C", (25.00, 3, "Chocorroles") }
        };


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
            if(IDLocked) return; //Processing payment so return

            if (!_itemsInfo.ContainsKey(ID) && ID != "")
            {
                MessageBox.Show("El ID proporcionado no es válido.", "¡Error!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; //if ID is not valid then return
            }

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
            if(IDLocked) return; //Processing payment so return

            if(TotalAmountDeposited <= 0)
            {
                MessageBox.Show("Porfavor de ingresar dinero antes de seleccionar un ID.", "¡Error!",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ToggleIDMenu();
        }

                private bool IDFull()
        {
            if (ID.Length == 2) return true;
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
            if(IDLocked) return;
            ID = "";
            CurrentID.Text = ID;
        }

        private void ModifyID(string btnText)
        {
            if(IDFull() || IDLocked) return;
            ID += btnText;
            CurrentID.Text = ID;
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
            IDLocked = true;
            if (ID == "")
            {
                MessageBox.Show("Porfavor de ingresar un ID antes de continuar.", "¡Error!",
                                                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                UnlockID();
                return;
            }

            if(!_itemsInfo.ContainsKey(ID))
            {
                MessageBox.Show("El ID proporcionado no es válido.", "¡Error!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                UnlockID();
                ID = "";
                return;
            }


            double itemPrice = _itemsInfo[ID].Price;
            int itemAmount = _itemsInfo[ID].Amount;
            string itemName = _itemsInfo[ID].Name;
            
            // If the item is not available
            if (itemAmount <= 0)
            {
                MessageBox.Show("El producto seleccionado no se encuentra disponible.", "¡Error!",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                UnlockID();
                return;
            }

            // If the user has not deposited enough money
            if (TotalAmountDeposited < itemPrice)
            {
                MessageBox.Show($"El dinero ingresado no es suficiente para comprar el producto seleccionado. Devolviendo: ${TotalAmountDeposited}", "¡Error!",
                                                                      MessageBoxButtons.OK, MessageBoxIcon.Error);

                TotalAmountDeposited = 0;
                TotalDepositedLabel.Text = "$0.00";
                UnlockID();

                return;
            }

            ProcessPayment processPayment = new ProcessPayment(this, TotalAmountDeposited, itemPrice, itemName, ID);
            processPayment.Show();
        }

        public void RemoveItem(string ID)
        {
            _itemsInfo[ID] = (_itemsInfo[ID].Price, _itemsInfo[ID].Amount - 1, _itemsInfo[ID].Name);
        }

        public void UnlockID()
        {
            IDLocked = false;
        }

        public void ClearID()
        {
            ID = "";
            CurrentID.Text = ID;
        }   
    }
}
