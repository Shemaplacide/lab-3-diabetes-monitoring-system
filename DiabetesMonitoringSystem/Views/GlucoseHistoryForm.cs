using System;
using System.Data;
using System.Windows.Forms;
using DiabetesMonitoringSystem.Controllers;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Views
{
    public partial class GlucoseHistoryForm : Form
    {
        public GlucoseHistoryForm()
        {
            InitializeComponent();
        }

        private User viewer;
        private int patientId;
        private readonly CareController care = new CareController();

        public GlucoseHistoryForm(User user, int selectedPatientId, string patientName) : this()
        {
            viewer = user;
            patientId = selectedPatientId;
            lblPatient.Text = "Patient: " + patientName;
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
        }

        private void ShowAll(object sender, EventArgs e)
        {
            LoadReadings(null, null);
        }

        private void Filter(object sender, EventArgs e)
        {
            LoadReadings(dtpFrom.Value, dtpTo.Value);
        }

        private void LoadReadings(DateTime? from, DateTime? to)
        {
            lblDateError.Text = "";
            dgvReadings.DataSource = null;
            if (from.HasValue && from.Value.Date > to.Value.Date)
            {
                lblDateError.Text = "The start date must be on or before the end date.";
                return;
            }

            FormMessages.Try(this, () =>
            {
                dgvReadings.DataSource = care.History(viewer, patientId, from, to);
                dgvReadings.Columns["Measured at"].DefaultCellStyle.Format = "dd MMM yyyy HH:mm";
                dgvReadings.Columns["Reading"].DefaultCellStyle.Format = "0.###";
            });
        }
    }
}
