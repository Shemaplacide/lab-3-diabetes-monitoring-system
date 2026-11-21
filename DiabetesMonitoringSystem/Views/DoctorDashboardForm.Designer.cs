using System.Drawing;
using System.Windows.Forms;

namespace DiabetesMonitoringSystem.Views
{
    partial class DoctorDashboardForm
    {
        private Label lblTitle;
        private Label lblWelcome;
        private Label lblPatients;
        private DataGridView dgvPatients;
        private Button btnHistory;
        private Button btnAppointments;
        private Button btnRefresh;
        private Button btnSignOut;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.lblTitle = new Label();
            this.lblTitle.Location = new Point(28, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(490, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Doctor dashboard";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.Controls.Add(this.lblTitle);

            this.lblWelcome = new Label();
            this.lblWelcome.Location = new Point(28, 71);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(550, 25);
            this.lblWelcome.TabIndex = 1;
            this.Controls.Add(this.lblWelcome);

            this.lblPatients = new Label();
            this.lblPatients.Location = new Point(28, 109);
            this.lblPatients.Name = "lblPatients";
            this.lblPatients.Size = new Size(620, 25);
            this.lblPatients.TabIndex = 2;
            this.lblPatients.Text = "Select one of your assigned patients.";
            this.Controls.Add(this.lblPatients);

            this.dgvPatients = new DataGridView();
            this.dgvPatients.Location = new Point(28, 139);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.Size = new Size(680, 229);
            this.dgvPatients.TabIndex = 3;
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.AllowUserToResizeRows = false;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.BackgroundColor = SystemColors.Window;
            this.Controls.Add(this.dgvPatients);

            this.btnHistory = new Button();
            this.btnHistory.Location = new Point(28, 384);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new Size(155, 34);
            this.btnHistory.TabIndex = 4;
            this.btnHistory.Text = "Glucose history";
            this.btnHistory.Click += this.OpenHistory;
            this.Controls.Add(this.btnHistory);

            this.btnAppointments = new Button();
            this.btnAppointments.Location = new Point(193, 384);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new Size(180, 34);
            this.btnAppointments.TabIndex = 5;
            this.btnAppointments.Text = "Manage appointments";
            this.btnAppointments.Click += this.OpenAppointments;
            this.Controls.Add(this.btnAppointments);

            this.btnRefresh = new Button();
            this.btnRefresh.Location = new Point(383, 384);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(125, 34);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += this.LoadPatients;
            this.Controls.Add(this.btnRefresh);

            this.btnSignOut = new Button();
            this.btnSignOut.Location = new Point(563, 384);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new Size(145, 34);
            this.btnSignOut.TabIndex = 7;
            this.btnSignOut.Text = "Sign out";
            this.Controls.Add(this.btnSignOut);

            this.AutoScaleDimensions = new SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(736, 442);
            this.BackColor = SystemColors.Control;
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "DoctorDashboardForm";
            this.Text = "Diabetes Monitoring System - Doctor dashboard";
            this.btnSignOut.DialogResult = DialogResult.Cancel;
            this.CancelButton = this.btnSignOut;
            this.Load += this.LoadPatients;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
