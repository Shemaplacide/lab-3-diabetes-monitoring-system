using System;
using System.Data;
using System.Windows.Forms;
using DiabetesMonitoringSystem.Controllers;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Views
{
    public partial class DoctorAppointmentsForm : Form
    {
        public DoctorAppointmentsForm()
        {
            InitializeComponent();
        }

        private User doctor;
        private int patientId;
        private readonly CareController care = new CareController();

        public DoctorAppointmentsForm(User user, int selectedPatientId, string patientName) : this()
        {
            doctor = user;
            patientId = selectedPatientId;
            lblPatient.Text = "Patient: " + patientName;
            dtpAppointment.Value = DateTime.Now.AddDays(1);
        }

        private void RefreshAppointments(object sender, EventArgs e)
        {
            dgvAppointments.DataSource = null;
            FormMessages.Try(this, () =>
            {
                dgvAppointments.DataSource = care.Appointments(doctor, patientId);
                FormMessages.HideId(dgvAppointments, "AppointmentId");
                dgvAppointments.Columns["Date and time"].DefaultCellStyle.Format = "dd MMM yyyy HH:mm";
                dgvAppointments.ClearSelection();
            });
        }

        private void PickAppointment(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dtpAppointment.Value = (DateTime)dgvAppointments.Rows[e.RowIndex].Cells["Date and time"].Value;
        }

        private void Schedule(object sender, EventArgs e)
        {
            if (FormMessages.Try(this, () => care.Schedule(doctor, patientId, dtpAppointment.Value)))
            {
                MessageBox.Show(this, "Appointment scheduled.");
                RefreshAppointments(sender, e);
            }
        }

        private void Reschedule(object sender, EventArgs e)
        {
            if (FormMessages.Try(this, () => care.Reschedule(doctor, patientId,
                FormMessages.SelectedId(dgvAppointments, "AppointmentId"), dtpAppointment.Value)))
            {
                MessageBox.Show(this, "Appointment rescheduled.");
                RefreshAppointments(sender, e);
            }
        }

        private void CancelAppointment(object sender, EventArgs e)
        {
            FormMessages.Try(this, () =>
            {
                int id = FormMessages.SelectedId(dgvAppointments, "AppointmentId");
                if (MessageBox.Show(this, "Cancel the selected appointment?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                care.Cancel(doctor, patientId, id);
                MessageBox.Show(this, "Appointment cancelled.");
                RefreshAppointments(sender, e);
            });
        }
    }
}
