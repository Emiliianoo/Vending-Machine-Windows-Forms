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
    public partial class AdminPage : Form
    {
        private MainMenu menu = null;
        private static string username = "admin";
        private static string password = "12345";

        public AdminPage()
        {
            InitializeComponent();
        }

        public AdminPage(Form callingForm)
        {
            menu = callingForm as MainMenu;
            InitializeComponent();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            CokeNumUpDown.Value = MainControl.getItemAmount("1A");
            CokePriceNumUpDown.Value = (decimal)MainControl.getItemPrice("1A");

            SpriteNumUpDown.Value = MainControl.getItemAmount("2A");
            SpritePriceNumUpDown.Value = (decimal)MainControl.getItemPrice("2A");

            PepsiNumUpDown.Value = MainControl.getItemAmount("3A");
            PepsiPriceNumUpDown.Value = (decimal)MainControl.getItemPrice("3A");

            DrPepperNumUpDown.Value = MainControl.getItemAmount("1B");
            DrPepperPriceNumUpDown.Value = (decimal)MainControl.getItemPrice("1B");

            RufflesNumUpDown.Value = MainControl.getItemAmount("2B");
            RufflesPriceNumUpDown.Value = (decimal)MainControl.getItemPrice("2B");

            SabritasNumUpDown.Value = MainControl.getItemAmount("3B");
            SabritasPriceNumUpDown.Value = (decimal)MainControl.getItemPrice("3B");

            GansitoNumUpDown.Value = MainControl.getItemAmount("1C");
            GansitoPriceNumUpDown.Value = (decimal)MainControl.getItemPrice("1C");

            ChokisNumUpDown.Value = MainControl.getItemAmount("2C");
            ChokisPriceNumUpDown.Value = (decimal)MainControl.getItemPrice("2C");

            ChocorolesNumUpDown.Value = MainControl.getItemAmount("3C");
            ChocorolesPriceNumUpDown.Value = (decimal)MainControl.getItemPrice("3C");
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string usernameInput = UsernameTextBox.Text;
            string passwordInput = PasswordTextBox.Text;

            if(usernameInput != username || passwordInput != password)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LogIn();
        }

        private void LogIn()
        {
            MessageBox.Show("Bienvenido, administrador.", "Login exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AdminLoginPanel.Visible = false;
            ManagePanel.Visible = true;
        }

        private void InspectBtn_Click(object sender, EventArgs e)
        {
            MainControl.ToggleAdminInspect();
            ManagePanel.Visible = false;
            ItemViewPanel.Visible = true;
            Size = new Size(848, Size.Height);
        }

        private void ChangePasswordBtn_Click(object sender, EventArgs e)
        {
            ManagePanel.Visible = false;
            PasswordChangePanel.Visible = true;
        }

        private void CokeNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemAmount("1A", (int)CokeNumUpDown.Value);
            menu.UpdateLabels();
        }

        private void CokePriceNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemPrice("1A", (double)MainControl.RoundDown(CokePriceNumUpDown.Value, 2));
            menu.UpdateLabels();
        }

        private void SpriteNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemAmount("2A", (int)SpriteNumUpDown.Value);
            menu.UpdateLabels();
        }

        private void SpritePriceNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemPrice("2A", (double)MainControl.RoundDown(SpritePriceNumUpDown.Value, 2));
            menu.UpdateLabels();
        }

        private void PepsiNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemAmount("3A", (int)PepsiNumUpDown.Value);
            menu.UpdateLabels();
        }

        private void PepsiPriceNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemPrice("3A", (double)MainControl.RoundDown(PepsiPriceNumUpDown.Value, 2));
            menu.UpdateLabels();
        }

        private void DrPepperNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemAmount("1B", (int)DrPepperNumUpDown.Value);
            menu.UpdateLabels();
        }

        private void DrPepperPriceNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemPrice("1B", (double)MainControl.RoundDown(DrPepperPriceNumUpDown.Value, 2));
            menu.UpdateLabels();
        }

        private void RufflesNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemAmount("2B", (int)RufflesNumUpDown.Value);
            menu.UpdateLabels();
        }

        private void RufflesPriceNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemPrice("2B", (double)MainControl.RoundDown(RufflesPriceNumUpDown.Value, 2));
            menu.UpdateLabels();
        }

        private void SabritasNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemAmount("3B", (int)SabritasNumUpDown.Value);
            menu.UpdateLabels();
        }

        private void SabritasPriceNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemPrice("3B", (double)MainControl.RoundDown(SabritasPriceNumUpDown.Value, 2));
            menu.UpdateLabels();
        }

        private void FinishBtn_Click(object sender, EventArgs e)
        {
            if(MainControl.AdminInspectOpen())
            {
                MainControl.ToggleAdminInspect();
            }
            this.Close();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            if(MainControl.AdminInspectOpen())
            {
                MainControl.ToggleAdminInspect();
            }
            ItemViewPanel.Visible = false;
            ManagePanel.Visible = true;
            Size = new Size(377, Size.Height);
        }

        private void GansitoNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemAmount("1C", (int)GansitoNumUpDown.Value);
            menu.UpdateLabels();
        }

        private void GansitoPriceNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemPrice("1C", (double)MainControl.RoundDown(GansitoPriceNumUpDown.Value, 2));
            menu.UpdateLabels();
        }

        private void ChokisNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemAmount("2C", (int)ChokisNumUpDown.Value);
            menu.UpdateLabels();
        }

        private void ChokisPriceNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemPrice("2C", (double)MainControl.RoundDown(ChokisPriceNumUpDown.Value, 2));
            menu.UpdateLabels();
        }

        private void ChocorolesNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemAmount("3C", (int)ChocorolesNumUpDown.Value);
            menu.UpdateLabels();
        }

        private void ChocorolesPriceNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            MainControl.ChangeItemPrice("3C", (double)MainControl.RoundDown(ChocorolesPriceNumUpDown.Value, 2));
            menu.UpdateLabels();
        }

        private void ReturnBtn2_Click(object sender, EventArgs e)
        {
            ManagePanel.Visible = false;
            AdminLoginPanel.Visible = true;
        }

        private void ConfirmChangeBtn_Click(object sender, EventArgs e)
        {
            if(OldPasswordTextBox.Text == password)
            {
                password = NewPasswordTextBox.Text;
            }

            MessageBox.Show("Contraseña cambiada con éxito.", "Cambio de contraseña exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PasswordChangePanel.Visible = false;
            AdminLoginPanel.Visible = true;
        }

        private void ReturnBtn3_Click(object sender, EventArgs e)
        {
            PasswordChangePanel.Visible = false;
            ManagePanel.Visible = true;
        }

        private void OldPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(MainControl.AdminInspectOpen())
            {
                MainControl.ToggleAdminInspect();
            }
        }
    }
}
