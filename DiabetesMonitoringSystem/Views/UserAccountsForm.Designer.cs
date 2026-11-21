using System.Drawing;
using System.Windows.Forms;

namespace DiabetesMonitoringSystem.Views
{
    partial class UserAccountsForm
    {
        private Label lblTitle;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblRole;
        private ComboBox cboRole;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblHint;
        private DataGridView dgvAccounts;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDeactivate;
        private Button btnRefresh;
        private Button btnBack;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(28, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(490, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "User accounts";
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(28, 82);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 25);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Full name";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(138, 78);
            this.txtFullName.MaxLength = 100;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(215, 34);
            this.txtFullName.TabIndex = 2;
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(28, 131);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 25);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(138, 128);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(215, 34);
            this.txtUsername.TabIndex = 4;
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(28, 180);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(100, 25);
            this.lblRole.TabIndex = 5;
            this.lblRole.Text = "Role";
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Location = new System.Drawing.Point(138, 177);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(215, 36);
            this.cboRole.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(28, 229);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 25);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(138, 226);
            this.txtPassword.MaxLength = 128;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(215, 34);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblHint
            // 
            this.lblHint.Location = new System.Drawing.Point(28, 273);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(325, 44);
            this.lblHint.TabIndex = 9;
            this.lblHint.Text = "Role and password are used for new accounts.";
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.AllowUserToResizeRows = false;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAccounts.ColumnHeadersHeight = 34;
            this.dgvAccounts.Location = new System.Drawing.Point(379, 78);
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.RowHeadersVisible = false;
            this.dgvAccounts.RowHeadersWidth = 62;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(464, 250);
            this.dgvAccounts.TabIndex = 10;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(28, 357);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(135, 34);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "Create";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(173, 357);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(152, 34);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update selected";
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.Location = new System.Drawing.Point(335, 357);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(170, 34);
            this.btnDeactivate.TabIndex = 13;
            this.btnDeactivate.Text = "Deactivate selected";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(515, 357);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 34);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Location = new System.Drawing.Point(701, 357);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(126, 34);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back";
            // 
            // UserAccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(855, 425);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.dgvAccounts);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDeactivate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserAccountsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Diabetes Monitoring System - User accounts";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
