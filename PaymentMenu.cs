using MaquinaExpendedora.Methods;
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
        private static List<decimal> creditCard = new List<decimal> { 2957376894657890, 523, 400}; // Card number, CVV, Card Limit Left
        private static List<decimal> debitCard = new List<decimal> { 2957376894657890, 325, 10 }; // Card number, CVV, Card Amount
        private static int creditCardFailedAttemps = 0;
        private static int debitCardFailedAttemps = 0;


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
            CreditPaymentPanel.Visible = false;
            Size = new Size(325, Size.Height);
        }

        private void CashBtn_Click(object sender, EventArgs e)
        {
            if(CashPaymentPanel.Visible)
            {
                HidePanels();
                return;
            }

            CreditPaymentPanel.Visible = false;
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
            MainControl.AddCashAmount(CashAmount);
            MessageBox.Show($"Se ha depositado ${CashAmount.ToString()} de forma correcta.", "Depósito con éxito.",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            MenuPrincipal.ModifyDepositedLabel();
            MenuPrincipal.BringToFront();
            this.Close();
        }

        private void PaymentMenu_Load(object sender, EventArgs e)
        {

        }

        private void CreditCardBtn_Click(object sender, EventArgs e)
        {
            if(CashAmountLabel.Text != "$0.00")
            {
                MessageBox.Show($"Porfavor de retirar el dinero ingresado antes de continuar.", "Error.",
                                                                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(CreditPaymentPanel.Visible)
            {
                HidePanels();
                return;
            }

            CashPaymentPanel.Visible = false;
            CreditPaymentPanel.Visible = true;
            Size = new Size(794, Size.Height);
        }

        private void CardAcceptDepositBtn_Click(object sender, EventArgs e)
        {
            try
            {
                long cardNumber = long.Parse(CardNumberTextBox.Text);
                int cardCVV = Convert.ToInt32(CardCVVTextBox.Text);
                string card = CardSelectedLabel.Text;
                decimal amount = Convert.ToDecimal(DepositAmountTextBox.Text);

                Console.WriteLine(cardNumber);
                Console.WriteLine(cardCVV);
                Console.WriteLine(card);
                Console.WriteLine(amount);

                if (card == "Crédito")
                {
                    if(creditCardFailedAttemps >= 3)
                    {
                        MessageBox.Show($"Se ha bloqueado la opción de tarjeta de crédito.", "Tarjeta bloqueada.",
                                                                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MenuPrincipal.BringToFront();
                        this.Close();
                        return;
                    }

                    if (validCreditCard(cardNumber, cardCVV, amount))
                    {
                        creditCard[2] -= amount;
                        MainControl.AddCashAmount((double)amount);
                        MessageBox.Show($"Se ha depositado ${amount.ToString()} de forma correcta.", "Depósito con éxito.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MenuPrincipal.ModifyDepositedLabel();
                        MenuPrincipal.BringToFront();
                        this.Close();
                        return;
                    }
                    else
                    {
                        if (creditCardFailedAttemps >= 3)
                        {
                            MessageBox.Show($"Se ha bloqueado la opción de tarjeta de crédito.", "Tarjeta bloqueada.",
                                                                                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MenuPrincipal.BringToFront();
                            this.Close();
                            return;
                        }
                    }
                }
                else
                {
                    if(debitCardFailedAttemps >= 3)
                    {
                        MessageBox.Show($"Se ha bloqueado la opción de tarjeta de débito.", "Tarjeta bloqueada.",
                                                                                                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MenuPrincipal.BringToFront();
                        this.Close();
                        return;
                    }

                    if (validDebitCard(cardNumber, cardCVV, amount))
                    {
                        debitCard[2] -= amount;
                        MainControl.AddCashAmount((double)amount);
                        MessageBox.Show($"Se ha depositado ${amount.ToString()} de forma correcta.", "Depósito con éxito.",
                                                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MenuPrincipal.ModifyDepositedLabel();
                        MenuPrincipal.BringToFront();
                        this.Close();
                        return;
                    }
                    else
                    {
                        if (debitCardFailedAttemps >= 3)
                        {
                            MessageBox.Show($"Se ha bloqueado la opción de tarjeta de débito.", "Tarjeta bloqueada.",
                                                                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MenuPrincipal.BringToFront();
                            this.Close();
                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: Números inválidos", "Error.",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool validDebitCard(long cardNumber, int cardCVV, decimal amount)
        {
            if (amount > debitCard[2])
            {
                MessageBox.Show($"Fondos insuficientes.", "Fondos Insuficientes.",
                                                                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                debitCardFailedAttemps++;
                return false;
            }

            if (cardNumber == debitCard[0] && cardCVV == debitCard[1])
            {
                return true;
            }

            MessageBox.Show($"Número de tarjeta, CVV incorrecto.", "Dinero regresado.",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            debitCardFailedAttemps++;
            return false;
        }

        private bool validCreditCard(long cardNumber, int cardCVV, decimal amount)
        {
            if(amount > creditCard[2])
            {
                MessageBox.Show($"Fondos insuficientes.", "Fondos Insuficientes.",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);

                creditCardFailedAttemps++;
                return false;
            }

            if(cardNumber == creditCard[0] && cardCVV == creditCard[1])
            {
                return true;
            }

            MessageBox.Show($"Número de tarjeta, CVV incorrecto.", "Dinero regresado.",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            creditCardFailedAttemps++;
            return false;
        }

        private void CreditPaymentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CreditOption_CheckedChanged(object sender, EventArgs e)
        {
            if(CreditOption.Checked)
            {
                CardSelectedLabel.Text = "Crédito";
                DebitOption.Checked = false;
                return;
            }
        }

        private void DebitOption_CheckedChanged(object sender, EventArgs e)
        {
            if(DebitOption.Checked)
            {
                CardSelectedLabel.Text = "Débito";
                CreditOption.Checked = false;
                return;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CardAcceptDepositBtn_MouseEnter(object sender, EventArgs e)
        {
            CardAcceptDepositBtn.BackColor = Color.YellowGreen;
        }

        private void CardAcceptDepositBtn_MouseLeave(object sender, EventArgs e)
        {
            CardAcceptDepositBtn.BackColor = Color.Silver;
        }
    }
}
