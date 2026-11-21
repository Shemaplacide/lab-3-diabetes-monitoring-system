using System.Drawing;
using System.Windows.Forms;

namespace DiabetesMonitoringSystem.Views
{
    partial class PatientDashboardForm
    {
        private Label lblTitle;
        private Label lblWelcome;
        private Button btnRecord;
        private Button btnHistory;
        private Button btnSignOut;
        private Label lblAppointments;
        private DataGridView dgvAppointments;
        private Button btnRefresh;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.lblTitle = new Label();
            this.lblTitle.Location = new Point(28, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(490, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Patient dashboard";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.Controls.Add(this.lblTitle);

            this.lblWelcome = new Label();
            this.lblWelcome.Location = new Point(28, 69);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(540, 25);
            this.lblWelcome.TabIndex = 1;
            this.Controls.Add(this.lblWelcome);

            this.btnRecord = new Button();
            this.btnRecord.Location = new Point(28, 105);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new Size(155, 34);
            this.btnRecord.TabIndex = 2;
            this.btnRecord.Text = "Record glucose";
            this.btnRecord.Click += this.RecordGlucose;
            this.Controls.Add(this.btnRecord);

            this.btnHistory = new Button();
            this.btnHistory.Location = new Point(193, 105);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new Size(155, 34);
            this.btnHistory.TabIndex = 3;
            this.btnHistory.Text = "Glucose history";
            this.btnHistory.Click += this.OpenHistory;
            this.Controls.Add(this.btnHistory);

            this.btnSignOut = new Button();
            this.btnSignOut.Location = new Point(563, 105);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new Size(145, 34);
            this.btnSignOut.TabIndex = 4;
            this.btnSignOut.Text = "Sign out";
            this.Controls.Add(this.btnSignOut);

            this.lblAppointments = new Label();
            this.lblAppointments.Location = new Point(28, 163);
            this.lblAppointments.Name = "lblAppointments";
            this.lblAppointments.Size = new Size(400, 25);
            this.lblAppointments.TabIndex = 5;
            this.lblAppointments.Text = "My follow-up appointments";
            this.Controls.Add(this.lblAppointments);

            this.dgvAppointments = new DataGridView();
            this.dgvAppointments.Location = new Point(28, 191);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.Size = new Size(680, 202);
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
            this.Controls.Add(this.dgvAppointments);

            this.btnRefresh = new Button();
            this.btnRefresh.Location = new Point(28, 409);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(190, 34);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh appointments";
            this.btnRefresh.Click += this.RefreshAppointments;
            this.Controls.Add(this.btnRefresh);

            this.AutoScaleDimensions = new SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(736, 465);
            this.BackColor = SystemColors.Control;
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "PatientDashboardForm";
            this.Text = "Diabetes Monitoring System - Patient dashboard";
            this.btnSignOut.DialogResult = DialogResult.Cancel;
            this.CancelButton = this.btnSignOut;
            this.Load += this.RefreshAppointments;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
