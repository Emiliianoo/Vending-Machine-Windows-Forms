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
    public partial class AdminPage : Form
    {
        private MainMenu menu = null;
        private string username = "admin";
        private string password = "admin";

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
    }
}
