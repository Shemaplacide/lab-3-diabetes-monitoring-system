using System;
using System.Data;
using System.Windows.Forms;
using DiabetesMonitoringSystem.Controllers;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Views
{
    public partial class UserAccountsForm : Form
    {
        public UserAccountsForm()
        {
            InitializeComponent();
        }

        private User admin;
        private readonly AccountController accounts = new AccountController();

        public UserAccountsForm(User user) : this()
        {
            admin = user;
        }

        private void LoadAccounts(object sender, EventArgs e)
        {
            cboRole.Items.AddRange(new object[] { "Patient", "Doctor" });
            cboRole.SelectedIndex = 0;
            RefreshAccounts(sender, e);
        }

        private void RefreshAccounts(object sender, EventArgs e)
        {
            FormMessages.Try(this, () =>
            {
                dgvAccounts.DataSource = accounts.Accounts(admin);
                FormMessages.HideId(dgvAccounts, "UserId");
                dgvAccounts.Columns["FullName"].HeaderText = "Full name";
                dgvAccounts.Columns["IsActive"].HeaderText = "Active";
                dgvAccounts.ClearSelection();
            });
        }

        private void FillFields(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvAccounts.Rows[e.RowIndex];
            txtFullName.Text = Convert.ToString(row.Cells["FullName"].Value);
            txtUsername.Text = Convert.ToString(row.Cells["Username"].Value);
            cboRole.SelectedItem = Convert.ToString(row.Cells["Role"].Value);
            txtPassword.Clear();
        }

        private void CreateAccount(object sender, EventArgs e)
        {
            if (FormMessages.Try(this, () => accounts.CreateAccount(admin, txtFullName.Text,
                txtUsername.Text, Convert.ToString(cboRole.SelectedItem), txtPassword.Text)))
            {
                txtFullName.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                MessageBox.Show(this, "Account created.");
                RefreshAccounts(sender, e);
            }
        }

        private void UpdateAccount(object sender, EventArgs e)
        {
            if (FormMessages.Try(this, () => accounts.Update(admin,
                FormMessages.SelectedId(dgvAccounts, "UserId"), txtFullName.Text, txtUsername.Text)))
            {
                MessageBox.Show(this, "Account updated.");
                RefreshAccounts(sender, e);
            }
        }

        private void DeactivateAccount(object sender, EventArgs e)
        {
            FormMessages.Try(this, () =>
            {
                int id = FormMessages.SelectedId(dgvAccounts, "UserId");
                if (MessageBox.Show(this, "Deactivate the selected account?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                accounts.Deactivate(admin, id);
                MessageBox.Show(this, "Account deactivated.");
                RefreshAccounts(sender, e);
            });
        }
    }
}
