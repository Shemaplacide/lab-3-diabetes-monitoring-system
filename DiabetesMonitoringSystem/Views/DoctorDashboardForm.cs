using System;
using System.Data;
using System.Windows.Forms;
using DiabetesMonitoringSystem.Controllers;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Views
{
    public partial class DoctorDashboardForm : Form
    {
        public DoctorDashboardForm()
        {
            InitializeComponent();
        }

        private User doctor;
        private readonly CareController care = new CareController();

        public DoctorDashboardForm(User user) : this()
        {
            doctor = user;
            lblWelcome.Text = "Welcome, " + user.FullName;
        }

        private void LoadPatients(object sender, EventArgs e)
        {
            FormMessages.Try(this, () =>
            {
                dgvPatients.DataSource = care.Patients(doctor);
                FormMessages.HideId(dgvPatients, "UserId");
                dgvPatients.Columns["FullName"].HeaderText = "Patient name";
                dgvPatients.ClearSelection();
            });
        }

        private void OpenHistory(object sender, EventArgs e)
        {
            FormMessages.Try(this, () =>
            {
                int id = FormMessages.SelectedId(dgvPatients, "UserId");
                string name = Convert.ToString(dgvPatients.SelectedRows[0].Cells["FullName"].Value);
                using (GlucoseHistoryForm form = new GlucoseHistoryForm(doctor, id, name)) form.ShowDialog(this);
            });
        }

        private void OpenAppointments(object sender, EventArgs e)
        {
            FormMessages.Try(this, () =>
            {
                int id = FormMessages.SelectedId(dgvPatients, "UserId");
                string name = Convert.ToString(dgvPatients.SelectedRows[0].Cells["FullName"].Value);
                using (DoctorAppointmentsForm form = new DoctorAppointmentsForm(doctor, id, name)) form.ShowDialog(this);
            });
        }
    }
}
