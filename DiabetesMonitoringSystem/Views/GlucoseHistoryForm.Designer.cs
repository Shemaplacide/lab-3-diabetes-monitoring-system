using System.Drawing;
using System.Windows.Forms;

namespace DiabetesMonitoringSystem.Views
{
    partial class GlucoseHistoryForm
    {
        private Label lblTitle;
        private Label lblPatient;
        private Label lblFrom;
        private DateTimePicker dtpFrom;
        private Label lblTo;
        private DateTimePicker dtpTo;
        private Button btnFilter;
        private Button btnShowAll;
        private Label lblDateError;
        private DataGridView dgvReadings;
        private Button btnBack;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblDateError = new System.Windows.Forms.Label();
            this.dgvReadings = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReadings)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(28, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(490, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Glucose history";
            // 
            // lblPatient
            // 
            this.lblPatient.Location = new System.Drawing.Point(28, 66);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(620, 25);
            this.lblPatient.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(28, 105);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(60, 25);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd MMM yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(95, 98);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(135, 34);
            this.dtpFrom.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(236, 105);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(46, 25);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd MMM yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(283, 98);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(135, 34);
            this.dtpTo.TabIndex = 5;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(424, 98);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(128, 34);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Apply filter";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(563, 98);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(145, 34);
            this.btnShowAll.TabIndex = 7;
            this.btnShowAll.Text = "Show all";
            // 
            // lblDateError
            // 
            this.lblDateError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblDateError.Location = new System.Drawing.Point(28, 136);
            this.lblDateError.Name = "lblDateError";
            this.lblDateError.Size = new System.Drawing.Size(680, 23);
            this.lblDateError.TabIndex = 8;
            // 
            // dgvReadings
            // 
            this.dgvReadings.AllowUserToAddRows = false;
            this.dgvReadings.AllowUserToDeleteRows = false;
            this.dgvReadings.AllowUserToResizeRows = false;
            this.dgvReadings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReadings.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvReadings.ColumnHeadersHeight = 34;
            this.dgvReadings.Location = new System.Drawing.Point(28, 161);
            this.dgvReadings.MultiSelect = false;
            this.dgvReadings.Name = "dgvReadings";
            this.dgvReadings.ReadOnly = true;
            this.dgvReadings.RowHeadersVisible = false;
            this.dgvReadings.RowHeadersWidth = 62;
            this.dgvReadings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReadings.Size = new System.Drawing.Size(680, 230);
            this.dgvReadings.TabIndex = 9;
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Location = new System.Drawing.Point(563, 405);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(145, 34);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            // 
            // GlucoseHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(736, 458);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.lblDateError);
            this.Controls.Add(this.dgvReadings);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GlucoseHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Diabetes Monitoring System - Glucose history";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReadings)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
