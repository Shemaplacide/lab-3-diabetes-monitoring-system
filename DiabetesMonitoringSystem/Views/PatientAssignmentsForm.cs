using System;
using System.Data;
using System.Windows.Forms;
using DiabetesMonitoringSystem.Controllers;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Views
{
    public partial class PatientAssignmentsForm : Form
    {
        public PatientAssignmentsForm()
        {
            InitializeComponent();
        }

        private User admin;
        private readonly AccountController accounts = new AccountController();

        public PatientAssignmentsForm(User user) : this()
        {
            admin = user;
        }

        private void RefreshAssignments(object sender, EventArgs e)
        {
            FormMessages.Try(this, () =>
            {
                cboPatient.DisplayMember = "FullName";
                cboPatient.ValueMember = "UserId";
                cboPatient.DataSource = accounts.Accounts(admin, "Patient");
                cboDoctor.DisplayMember = "FullName";
                cboDoctor.ValueMember = "UserId";
                cboDoctor.DataSource = accounts.Accounts(admin, "Doctor", true);
                cboPatient.SelectedIndex = -1;
                cboDoctor.SelectedIndex = -1;
                dgvAssignments.DataSource = accounts.Assignments(admin);
                dgvAssignments.Columns["DoctorActive"].HeaderText = "Doctor active";
            });
        }

        private void SaveAssignment(object sender, EventArgs e)
        {
            if (cboPatient.SelectedValue == null || cboDoctor.SelectedValue == null)
            {
                MessageBox.Show(this, "Select a patient and an active doctor.");
                return;
            }

            if (FormMessages.Try(this, () => accounts.Assign(admin,
                (int)cboPatient.SelectedValue, (int)cboDoctor.SelectedValue)))
            {
                MessageBox.Show(this, "Assignment saved.");
                RefreshAssignments(sender, e);
            }
        }
    }
}
