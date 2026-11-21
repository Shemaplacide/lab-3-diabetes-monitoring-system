using System.Drawing;
using System.Windows.Forms;

namespace DiabetesMonitoringSystem.Views
{
    partial class RegisterForm
    {
        private Label lblTitle;
        private Label lblDescription;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Label lblPasswordError;
        private Button btnCreateAccount;
        private Button btnBackToLogin;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.lblTitle = new Label();
            this.lblTitle.Location = new Point(28, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(490, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create account";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.Controls.Add(this.lblTitle);

            this.lblDescription = new Label();
            this.lblDescription.Location = new Point(28, 64);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(440, 25);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Create a patient account.";
            this.Controls.Add(this.lblDescription);

            this.lblFullName = new Label();
            this.lblFullName.Location = new Point(28, 113);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new Size(150, 25);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Full name";
            this.Controls.Add(this.lblFullName);

            this.txtFullName = new TextBox();
            this.txtFullName.Location = new Point(180, 109);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new Size(300, 26);
            this.txtFullName.TabIndex = 3;
            this.txtFullName.MaxLength = 100;
            this.Controls.Add(this.txtFullName);

            this.lblUsername = new Label();
            this.lblUsername.Location = new Point(28, 164);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(150, 25);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username";
            this.Controls.Add(this.lblUsername);

            this.txtUsername = new TextBox();
            this.txtUsername.Location = new Point(180, 160);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(300, 26);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.MaxLength = 50;
            this.Controls.Add(this.txtUsername);

            this.lblPassword = new Label();
            this.lblPassword.Location = new Point(28, 215);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(150, 25);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";
            this.Controls.Add(this.lblPassword);

            this.txtPassword = new TextBox();
            this.txtPassword.Location = new Point(180, 211);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new Size(300, 26);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.MaxLength = 128;
            this.txtPassword.UseSystemPasswordChar = true;
            this.Controls.Add(this.txtPassword);

            this.lblConfirmPassword = new Label();
            this.lblConfirmPassword.Location = new Point(28, 266);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new Size(150, 25);
            this.lblConfirmPassword.TabIndex = 8;
            this.lblConfirmPassword.Text = "Confirm password";
            this.Controls.Add(this.lblConfirmPassword);

            this.txtConfirmPassword = new TextBox();
            this.txtConfirmPassword.Location = new Point(180, 262);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new Size(300, 26);
            this.txtConfirmPassword.TabIndex = 9;
            this.txtConfirmPassword.MaxLength = 128;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.Controls.Add(this.txtConfirmPassword);

            this.lblPasswordError = new Label();
            this.lblPasswordError.Location = new Point(28, 291);
            this.lblPasswordError.Name = "lblPasswordError";
            this.lblPasswordError.Size = new Size(464, 23);
            this.lblPasswordError.TabIndex = 10;
            this.lblPasswordError.ForeColor = Color.Firebrick;
            this.Controls.Add(this.lblPasswordError);

            this.btnCreateAccount = new Button();
            this.btnCreateAccount.Location = new Point(180, 326);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new Size(144, 34);
            this.btnCreateAccount.TabIndex = 11;
            this.btnCreateAccount.Text = "Create account";
            this.btnCreateAccount.Click += this.CreateAccount;
            this.Controls.Add(this.btnCreateAccount);

            this.btnBackToLogin = new Button();
            this.btnBackToLogin.Location = new Point(336, 326);
            this.btnBackToLogin.Name = "btnBackToLogin";
            this.btnBackToLogin.Size = new Size(144, 34);
            this.btnBackToLogin.TabIndex = 12;
            this.btnBackToLogin.Text = "Back to log in";
            this.Controls.Add(this.btnBackToLogin);

            this.AutoScaleDimensions = new SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(520, 400);
            this.BackColor = SystemColors.Control;
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "RegisterForm";
            this.Text = "Diabetes Monitoring System - Create account";
            this.AcceptButton = this.btnCreateAccount;
            this.btnBackToLogin.DialogResult = DialogResult.Cancel;
            this.CancelButton = this.btnBackToLogin;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
