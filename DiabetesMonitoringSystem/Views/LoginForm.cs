using System;
using System.Data;
using System.Windows.Forms;
using DiabetesMonitoringSystem.Controllers;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private readonly AccountController accounts = new AccountController();

        private void OpenRegister(object sender, EventArgs e)
        {
            using (RegisterForm registration = new RegisterForm())
            {
                if (registration.ShowDialog(this) == DialogResult.OK)
                {
                    txtUsername.Text = registration.RegisteredUsername;
                    txtPassword.Clear();
                    txtPassword.Focus();
                    lblLoginError.Text = "";
                }
            }
        }

        private void LogIn(object sender, EventArgs e)
        {
            lblLoginError.Text = "";
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblLoginError.Text = "Enter your username and password.";
                return;
            }

            User user = null;
            if (!FormMessages.Try(this, () => user = accounts.Login(txtUsername.Text, txtPassword.Text))) return;
            txtPassword.Clear();
            if (user == null)
            {
                lblLoginError.Text = "Login failed. Check your username and password.";
                txtPassword.Focus();
                return;
            }

            Form dashboard;
            if (user.Role == "Admin") dashboard = new AdminDashboardForm(user);
            else if (user.Role == "Doctor") dashboard = new DoctorDashboardForm(user);
            else if (user.Role == "Patient") dashboard = new PatientDashboardForm(user);
            else return;

            Hide();
            try
            {
                using (dashboard) dashboard.ShowDialog();
            }
            finally
            {
                txtUsername.Clear();
                Show();
                txtUsername.Focus();
            }
        }
    }
}
