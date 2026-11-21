using System.Drawing;
using System.Windows.Forms;

namespace DiabetesMonitoringSystem.Views
{
    partial class PatientAssignmentsForm
    {
        private Label lblTitle;
        private Label lblPatient;
        private ComboBox cboPatient;
        private Label lblDoctor;
        private ComboBox cboDoctor;
        private Button btnAssign;
        private DataGridView dgvAssignments;
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
            this.lblTitle.Text = "Patient assignments";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.Controls.Add(this.lblTitle);

            this.lblPatient = new Label();
            this.lblPatient.Location = new Point(28, 81);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new Size(150, 25);
            this.lblPatient.TabIndex = 1;
            this.lblPatient.Text = "Patient";
            this.Controls.Add(this.lblPatient);

            this.cboPatient = new ComboBox();
            this.cboPatient.Location = new Point(160, 77);
            this.cboPatient.Name = "cboPatient";
            this.cboPatient.Size = new Size(300, 26);
            this.cboPatient.TabIndex = 2;
            this.cboPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(this.cboPatient);

            this.lblDoctor = new Label();
            this.lblDoctor.Location = new Point(28, 123);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new Size(150, 25);
            this.lblDoctor.TabIndex = 3;
            this.lblDoctor.Text = "Active doctor";
            this.Controls.Add(this.lblDoctor);

            this.cboDoctor = new ComboBox();
            this.cboDoctor.Location = new Point(160, 119);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new Size(300, 26);
            this.cboDoctor.TabIndex = 4;
            this.cboDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(this.cboDoctor);

            this.btnAssign = new Button();
            this.btnAssign.Location = new Point(485, 115);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new Size(165, 34);
            this.btnAssign.TabIndex = 5;
            this.btnAssign.Text = "Save assignment";
            this.btnAssign.Click += this.SaveAssignment;
            this.Controls.Add(this.btnAssign);

            this.dgvAssignments = new DataGridView();
            this.dgvAssignments.Location = new Point(28, 170);
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.Size = new Size(680, 175);
            this.dgvAssignments.TabIndex = 6;
            this.dgvAssignments.ReadOnly = true;
            this.dgvAssignments.AllowUserToAddRows = false;
            this.dgvAssignments.AllowUserToDeleteRows = false;
            this.dgvAssignments.AllowUserToResizeRows = false;
            this.dgvAssignments.RowHeadersVisible = false;
            this.dgvAssignments.MultiSelect = false;
            this.dgvAssignments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssignments.BackgroundColor = SystemColors.Window;
            this.Controls.Add(this.dgvAssignments);

            this.btnRefresh = new Button();
            this.btnRefresh.Location = new Point(28, 364);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(145, 34);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += this.RefreshAssignments;
            this.Controls.Add(this.btnRefresh);

            this.btnBack = new Button();
            this.btnBack.Location = new Point(563, 364);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new Size(145, 34);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.Controls.Add(this.btnBack);

            this.AutoScaleDimensions = new SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(736, 420);
            this.BackColor = SystemColors.Control;
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "PatientAssignmentsForm";
            this.Text = "Diabetes Monitoring System - Patient assignments";
            this.btnBack.DialogResult = DialogResult.Cancel;
            this.CancelButton = this.btnBack;
            this.Load += this.RefreshAssignments;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
