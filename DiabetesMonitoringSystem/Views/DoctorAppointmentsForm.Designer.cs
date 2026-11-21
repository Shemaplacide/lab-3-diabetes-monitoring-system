using System.Drawing;
using System.Windows.Forms;

namespace DiabetesMonitoringSystem.Views
{
    partial class DoctorAppointmentsForm
    {
        private Label lblTitle;
        private Label lblPatient;
        private Label lblWhen;
        private DateTimePicker dtpAppointment;
        private Button btnSchedule;
        private Button btnReschedule;
        private DataGridView dgvAppointments;
        private Button btnCancelAppointment;
        private Button btnRefresh;
        private Button btnBack;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.lblTitle = new Label();
            this.lblTitle.Location = new Point(28, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(490, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Follow-up appointments";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.Controls.Add(this.lblTitle);

            this.lblPatient = new Label();
            this.lblPatient.Location = new Point(28, 69);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new Size(690, 25);
            this.lblPatient.TabIndex = 1;
            this.Controls.Add(this.lblPatient);

            this.lblWhen = new Label();
            this.lblWhen.Location = new Point(28, 112);
            this.lblWhen.Name = "lblWhen";
            this.lblWhen.Size = new Size(150, 25);
            this.lblWhen.TabIndex = 2;
            this.lblWhen.Text = "Appointment time";
            this.Controls.Add(this.lblWhen);

            this.dtpAppointment = new DateTimePicker();
            this.dtpAppointment.Location = new Point(180, 108);
            this.dtpAppointment.Name = "dtpAppointment";
            this.dtpAppointment.Size = new Size(205, 26);
            this.dtpAppointment.TabIndex = 3;
            this.dtpAppointment.Format = DateTimePickerFormat.Custom;
            this.dtpAppointment.CustomFormat = "dd MMM yyyy HH:mm";
            this.Controls.Add(this.dtpAppointment);

            this.btnSchedule = new Button();
            this.btnSchedule.Location = new Point(396, 104);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new Size(110, 34);
            this.btnSchedule.TabIndex = 4;
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.Click += this.Schedule;
            this.Controls.Add(this.btnSchedule);

            this.btnReschedule = new Button();
            this.btnReschedule.Location = new Point(516, 104);
            this.btnReschedule.Name = "btnReschedule";
            this.btnReschedule.Size = new Size(170, 34);
            this.btnReschedule.TabIndex = 5;
            this.btnReschedule.Text = "Reschedule selected";
            this.btnReschedule.Click += this.Reschedule;
            this.Controls.Add(this.btnReschedule);

            this.dgvAppointments = new DataGridView();
            this.dgvAppointments.Location = new Point(28, 155);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.Size = new Size(734, 232);
            this.dgvAppointments.TabIndex = 6;
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AllowUserToResizeRows = false;
            this.dgvAppointments.RowHeadersVisible = false;
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.BackgroundColor = SystemColors.Window;
            this.dgvAppointments.CellClick += this.PickAppointment;
            this.Controls.Add(this.dgvAppointments);

            this.btnCancelAppointment = new Button();
            this.btnCancelAppointment.Location = new Point(28, 403);
            this.btnCancelAppointment.Name = "btnCancelAppointment";
            this.btnCancelAppointment.Size = new Size(165, 34);
            this.btnCancelAppointment.TabIndex = 7;
            this.btnCancelAppointment.Text = "Cancel selected";
            this.btnCancelAppointment.Click += this.CancelAppointment;
            this.Controls.Add(this.btnCancelAppointment);

            this.btnRefresh = new Button();
            this.btnRefresh.Location = new Point(203, 403);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(125, 34);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += this.RefreshAppointments;
            this.Controls.Add(this.btnRefresh);

            this.btnBack = new Button();
            this.btnBack.Location = new Point(617, 403);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new Size(145, 34);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.Controls.Add(this.btnBack);

            this.AutoScaleDimensions = new SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(790, 462);
            this.BackColor = SystemColors.Control;
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "DoctorAppointmentsForm";
            this.Text = "Diabetes Monitoring System - Follow-up appointments";
            this.btnBack.DialogResult = DialogResult.Cancel;
            this.CancelButton = this.btnBack;
            this.Load += this.RefreshAppointments;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
