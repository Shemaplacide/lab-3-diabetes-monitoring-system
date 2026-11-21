using System;
using System.Data;
using System.Windows.Forms;
using DiabetesMonitoringSystem.Controllers;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Views
{
    public partial class RecordGlucoseForm : Form
    {
        public RecordGlucoseForm()
        {
            InitializeComponent();
        }

        private User patient;
        private readonly CareController care = new CareController();

        public RecordGlucoseForm(User user) : this()
        {
            patient = user;
            dtpMeasuredAt.Value = DateTime.Now;
        }

        private void SaveReading(object sender, EventArgs e)
        {
            lblReadingError.Text = "";
            if (FormMessages.Try(this, SaveRecord))
            {
                MessageBox.Show(this, "Your reading was saved.");
                DialogResult = DialogResult.OK;
            }
        }

        private void SaveRecord()
        {
            try
            {
                care.Record(patient, txtGlucose.Text, dtpMeasuredAt.Value);
            }
            catch (ArgumentException error)
            {
                lblReadingError.Text = error.Message;
                txtGlucose.Focus();
                throw;
            }
        }
    }
}
