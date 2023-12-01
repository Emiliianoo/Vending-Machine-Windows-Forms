namespace MaquinaExpendedora
{
    partial class AdminPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AdminLoginPanel = new System.Windows.Forms.Panel();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.ManagePanel = new System.Windows.Forms.Panel();
            this.AdminLoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdminLoginPanel
            // 
            this.AdminLoginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AdminLoginPanel.Controls.Add(this.LoginBtn);
            this.AdminLoginPanel.Controls.Add(this.ReturnBtn);
            this.AdminLoginPanel.Controls.Add(this.UsernameTextBox);
            this.AdminLoginPanel.Controls.Add(this.UsernameLabel);
            this.AdminLoginPanel.Controls.Add(this.HeaderLabel);
            this.AdminLoginPanel.Controls.Add(this.PasswordTextBox);
            this.AdminLoginPanel.Controls.Add(this.PasswordLabel);
            this.AdminLoginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminLoginPanel.Location = new System.Drawing.Point(0, 0);
            this.AdminLoginPanel.Name = "AdminLoginPanel";
            this.AdminLoginPanel.Size = new System.Drawing.Size(361, 450);
            this.AdminLoginPanel.TabIndex = 0;
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.Silver;
            this.LoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.Color.Black;
            this.LoginBtn.Location = new System.Drawing.Point(52, 232);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(2);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(113, 29);
            this.LoginBtn.TabIndex = 20;
            this.LoginBtn.Text = "Iniciar Sesión";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.BackColor = System.Drawing.Color.Silver;
            this.ReturnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnBtn.ForeColor = System.Drawing.Color.Black;
            this.ReturnBtn.Location = new System.Drawing.Point(11, 408);
            this.ReturnBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(83, 31);
            this.ReturnBtn.TabIndex = 19;
            this.ReturnBtn.Text = "Regresar";
            this.ReturnBtn.UseVisualStyleBackColor = false;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(52, 143);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(260, 20);
            this.UsernameTextBox.TabIndex = 4;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel.Location = new System.Drawing.Point(49, 124);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(142, 16);
            this.UsernameLabel.TabIndex = 3;
            this.UsernameLabel.Text = "Nombre de Usuario";
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.White;
            this.HeaderLabel.Location = new System.Drawing.Point(53, 61);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(261, 24);
            this.HeaderLabel.TabIndex = 2;
            this.HeaderLabel.Text = "Pagina de Administradores";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(52, 195);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(260, 20);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.White;
            this.PasswordLabel.Location = new System.Drawing.Point(49, 176);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(86, 16);
            this.PasswordLabel.TabIndex = 0;
            this.PasswordLabel.Text = "Contraseña";
            // 
            // ManagePanel
            // 
            this.ManagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ManagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ManagePanel.Location = new System.Drawing.Point(0, 0);
            this.ManagePanel.Name = "ManagePanel";
            this.ManagePanel.Size = new System.Drawing.Size(361, 450);
            this.ManagePanel.TabIndex = 21;
            this.ManagePanel.Visible = false;
            // 
            // AdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 450);
            this.Controls.Add(this.ManagePanel);
            this.Controls.Add(this.AdminLoginPanel);
            this.MaximumSize = new System.Drawing.Size(377, 489);
            this.MinimumSize = new System.Drawing.Size(377, 489);
            this.Name = "AdminPage";
            this.Text = "Administradores";
            this.Load += new System.EventHandler(this.AdminPage_Load);
            this.AdminLoginPanel.ResumeLayout(false);
            this.AdminLoginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AdminLoginPanel;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.Panel ManagePanel;
    }
}