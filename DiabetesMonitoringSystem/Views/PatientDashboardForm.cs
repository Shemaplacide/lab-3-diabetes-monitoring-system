using System;
using System.Data;
using System.Windows.Forms;
using DiabetesMonitoringSystem.Controllers;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Views
{
    public partial class PatientDashboardForm : Form
    {
        public PatientDashboardForm()
        {
            InitializeComponent();
        }

        private User patient;
        private readonly CareController care = new CareController();

        public PatientDashboardForm(User user) : this()
        {
            patient = user;
            lblWelcome.Text = "Welcome, " + user.FullName;
        }

        private void RefreshAppointments(object sender, EventArgs e)
        {
            dgvAppointments.DataSource = null;
            FormMessages.Try(this, () =>
            {
                dgvAppointments.DataSource = care.Appointments(patient, patient.Id);
                FormMessages.HideId(dgvAppointments, "AppointmentId");
                dgvAppointments.Columns["Date and time"].DefaultCellStyle.Format = "dd MMM yyyy HH:mm";
            });
        }

        private void RecordGlucose(object sender, EventArgs e)
        {
            using (RecordGlucoseForm form = new RecordGlucoseForm(patient)) form.ShowDialog(this);
        }

        private void OpenHistory(object sender, EventArgs e)
        {
            using (GlucoseHistoryForm form = new GlucoseHistoryForm(patient, patient.Id, patient.FullName))
                form.ShowDialog(this);
        }
    }
}
