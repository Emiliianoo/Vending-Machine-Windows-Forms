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
    public partial class ProcessPayment : Form
    {
        private MainMenu menu = null;
        private string ID = "";
        private double TotalAmountDeposited = 0;
        private double itemPrice = 0;
        private int itemAmount = 0;
        private string itemName = "";

        public ProcessPayment()
        {
            InitializeComponent();
            timer1.Start();
        }

        public ProcessPayment(Form callingForm, double TotalAmountDeposited, double itemPrice, string itemName, string ID)
        {
            menu = callingForm as MainMenu;
            InitializeComponent();
            timer1.Start();
            this.ID = ID;
            this.TotalAmountDeposited = TotalAmountDeposited;
            this.itemPrice = itemPrice;
            this.itemName = itemName;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {

            if (progressBar.Value == 100)
            {
                timer1.Stop();
                await Task.Delay(1000);
                double change = TotalAmountDeposited - itemPrice;
                menu.RemoveItem(ID);
                menu.AddCashAmount(-itemPrice);
                if (change > 0)
                {
                    // Ask if they want to withdraw the change
                    DialogResult dialogResult = MessageBox.Show($"Se ha vendido un {itemName} con éxito. ¿Desea seguir comprando? Cambio actual: ${change}", "Retiro con éxito.",
                                                              MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.No)
                    {
                        menu.AddCashAmount(-change);
                        MessageBox.Show($"Se ha retirado el cambio de ${change.ToString()} de forma correcta.", "Retiro con éxito.",
                                                                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                        menu.ToggleIDMenu();
                    }

                }
                else
                {
                    MessageBox.Show($"Se ha vendido un {itemName} con éxito.", "Retiro con éxito.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                menu.UnlockID();
                menu.ClearID();
                this.Close();
            }
            progressBar.Increment(20);
        }

        private void ProcessPayment_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
