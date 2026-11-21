using System;
using System.Data;
using System.Windows.Forms;
using DiabetesMonitoringSystem.Controllers;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Views
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private User admin;

        public AdminDashboardForm(User user) : this()
        {
            admin = user;
            lblWelcome.Text = "Welcome, " + user.FullName;
        }

        private void OpenAccounts(object sender, EventArgs e)
        {
            using (UserAccountsForm form = new UserAccountsForm(admin)) form.ShowDialog(this);
        }

        private void OpenAssignments(object sender, EventArgs e)
        {
            using (PatientAssignmentsForm form = new PatientAssignmentsForm(admin)) form.ShowDialog(this);
        }
    }
}
