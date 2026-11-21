using System.Drawing;
using System.Windows.Forms;

namespace DiabetesMonitoringSystem.Views
{
    partial class RecordGlucoseForm
    {
        private Label lblTitle;
        private Label lblReading;
        private TextBox txtGlucose;
        private Label lblUnit;
        private Label lblReadingError;
        private Label lblMeasuredAt;
        private DateTimePicker dtpMeasuredAt;
        private Button btnSave;
        private Button btnBack;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.lblTitle = new Label();
            this.lblTitle.Location = new Point(28, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(490, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Record glucose";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.Controls.Add(this.lblTitle);

            this.lblReading = new Label();
            this.lblReading.Location = new Point(28, 86);
            this.lblReading.Name = "lblReading";
            this.lblReading.Size = new Size(155, 25);
            this.lblReading.TabIndex = 1;
            this.lblReading.Text = "Glucose reading";
            this.Controls.Add(this.lblReading);

            this.txtGlucose = new TextBox();
            this.txtGlucose.Location = new Point(195, 82);
            this.txtGlucose.Name = "txtGlucose";
            this.txtGlucose.Size = new Size(145, 26);
            this.txtGlucose.TabIndex = 2;
            this.txtGlucose.MaxLength = 20;
            this.Controls.Add(this.txtGlucose);

            this.lblUnit = new Label();
            this.lblUnit.Location = new Point(350, 86);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new Size(75, 25);
            this.lblUnit.TabIndex = 3;
            this.lblUnit.Text = "mg/dL";
            this.Controls.Add(this.lblUnit);

            this.lblReadingError = new Label();
            this.lblReadingError.Location = new Point(195, 112);
            this.lblReadingError.Name = "lblReadingError";
            this.lblReadingError.Size = new Size(355, 23);
            this.lblReadingError.TabIndex = 4;
            this.lblReadingError.ForeColor = Color.Firebrick;
            this.Controls.Add(this.lblReadingError);

            this.lblMeasuredAt = new Label();
            this.lblMeasuredAt.Location = new Point(28, 154);
            this.lblMeasuredAt.Name = "lblMeasuredAt";
            this.lblMeasuredAt.Size = new Size(165, 25);
            this.lblMeasuredAt.TabIndex = 5;
            this.lblMeasuredAt.Text = "Measurement time";
            this.Controls.Add(this.lblMeasuredAt);

            this.dtpMeasuredAt = new DateTimePicker();
            this.dtpMeasuredAt.Location = new Point(195, 150);
            this.dtpMeasuredAt.Name = "dtpMeasuredAt";
            this.dtpMeasuredAt.Size = new Size(215, 26);
            this.dtpMeasuredAt.TabIndex = 6;
            this.dtpMeasuredAt.Format = DateTimePickerFormat.Custom;
            this.dtpMeasuredAt.CustomFormat = "dd MMM yyyy HH:mm";
            this.Controls.Add(this.dtpMeasuredAt);

            this.btnSave = new Button();
            this.btnSave.Location = new Point(195, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(145, 34);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save reading";
            this.btnSave.Click += this.SaveReading;
            this.Controls.Add(this.btnSave);

            this.btnBack = new Button();
            this.btnBack.Location = new Point(350, 214);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new Size(145, 34);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.Controls.Add(this.btnBack);

            this.AutoScaleDimensions = new SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(575, 296);
            this.BackColor = SystemColors.Control;
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "RecordGlucoseForm";
            this.Text = "Diabetes Monitoring System - Record glucose";
            this.AcceptButton = this.btnSave;
            this.btnBack.DialogResult = DialogResult.Cancel;
            this.CancelButton = this.btnBack;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
