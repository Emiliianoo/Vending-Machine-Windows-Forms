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
    public partial class ProcessPayment : Form
    {
        private MainMenu menu = null;

        public ProcessPayment()
        {
            InitializeComponent();
            timer1.Start();
        }

        public ProcessPayment(Form callingForm)
        {
            menu = callingForm as MainMenu;
            InitializeComponent();
            timer1.Start();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {

            if (progressBar.Value == 100)
            {
                timer1.Stop();
                await Task.Delay(1000);
                double change = MainControl.TotalAmountDeposited - MainControl.getItemPrice();
                MainControl.DispenseItem();
                MainControl.SubtractCashAmount(MainControl.getItemPrice());
                if (change > 0)
                {
                    // Ask if they want to withdraw the change
                    DialogResult dialogResult = MessageBox.Show($"Se ha vendido un {MainControl.getItemName()} con éxito. ¿Desea seguir comprando? Cambio actual: ${change}", "Retiro con éxito.",
                                                              MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.No)
                    {
                        MainControl.SubtractCashAmount(change);
                        MessageBox.Show($"Se ha retirado el cambio de ${change.ToString()} de forma correcta.", "Retiro con éxito.",
                                                                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                        menu.ToggleIDMenu();
                    }

                }
                else
                {
                    MessageBox.Show($"Se ha vendido un {MainControl.getItemName()} con éxito.", "Retiro con éxito.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MainControl.ToggleIDLock();
                MainControl.ClearID();
                menu.ModifyIDlabel();
                menu.ModifyDepositedLabel();

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
