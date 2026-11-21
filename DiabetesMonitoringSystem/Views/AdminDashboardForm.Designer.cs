using System.Drawing;
using System.Windows.Forms;

namespace DiabetesMonitoringSystem.Views
{
    partial class AdminDashboardForm
    {
        private Label lblTitle;
        private Label lblWelcome;
        private Button btnAccounts;
        private Button btnAssignments;
        private Button btnSignOut;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.lblTitle = new Label();
            this.lblTitle.Location = new Point(28, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(490, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Admin dashboard";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.Controls.Add(this.lblTitle);

            this.lblWelcome = new Label();
            this.lblWelcome.Location = new Point(28, 76);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(540, 25);
            this.lblWelcome.TabIndex = 1;
            this.Controls.Add(this.lblWelcome);

            this.btnAccounts = new Button();
            this.btnAccounts.Location = new Point(28, 125);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new Size(165, 34);
            this.btnAccounts.TabIndex = 2;
            this.btnAccounts.Text = "Manage accounts";
            this.btnAccounts.Click += this.OpenAccounts;
            this.Controls.Add(this.btnAccounts);

            this.btnAssignments = new Button();
            this.btnAssignments.Location = new Point(205, 125);
            this.btnAssignments.Name = "btnAssignments";
            this.btnAssignments.Size = new Size(175, 34);
            this.btnAssignments.TabIndex = 3;
            this.btnAssignments.Text = "Patient assignments";
            this.btnAssignments.Click += this.OpenAssignments;
            this.Controls.Add(this.btnAssignments);

            this.btnSignOut = new Button();
            this.btnSignOut.Location = new Point(410, 125);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new Size(150, 34);
            this.btnSignOut.TabIndex = 4;
            this.btnSignOut.Text = "Sign out";
            this.Controls.Add(this.btnSignOut);

            this.AutoScaleDimensions = new SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(600, 210);
            this.BackColor = SystemColors.Control;
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "AdminDashboardForm";
            this.Text = "Diabetes Monitoring System - Admin dashboard";
            this.btnSignOut.DialogResult = DialogResult.Cancel;
            this.CancelButton = this.btnSignOut;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
