using System;
using System.Data;
using System.Windows.Forms;
using DiabetesMonitoringSystem.Controllers;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Views
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private readonly AccountController accounts = new AccountController();
        public string RegisteredUsername { get; private set; }

        private void CreateAccount(object sender, EventArgs e)
        {
            lblPasswordError.Text = "";
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblPasswordError.Text = "The two passwords must match.";
                txtConfirmPassword.Focus();
                return;
            }

            if (FormMessages.Try(this, () => accounts.Register(txtFullName.Text, txtUsername.Text, txtPassword.Text)))
            {
                RegisteredUsername = txtUsername.Text.Trim();
                MessageBox.Show(this, "Account created. Log in with your new password.", "Account created");
                DialogResult = DialogResult.OK;
            }
        }
    }
}
