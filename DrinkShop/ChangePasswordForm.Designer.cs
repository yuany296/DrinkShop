namespace DrinkShop
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtOldPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 36);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 24);
            label1.TabIndex = 8;
            label1.Text = "旧密码:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 96);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 24);
            label2.TabIndex = 7;
            label2.Text = "新密码:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 156);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 24);
            label3.TabIndex = 6;
            label3.Text = "确认密码:";
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new Point(122, 32);
            txtOldPassword.Margin = new Padding(4);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PasswordChar = '*';
            txtOldPassword.Size = new Size(244, 30);
            txtOldPassword.TabIndex = 1;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(122, 92);
            txtNewPassword.Margin = new Padding(4);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(244, 30);
            txtNewPassword.TabIndex = 2;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(122, 152);
            txtConfirmPassword.Margin = new Padding(4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(244, 30);
            txtConfirmPassword.TabIndex = 3;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.Aqua;
            btnConfirm.ForeColor = SystemColors.Desktop;
            btnConfirm.Location = new Point(122, 216);
            btnConfirm.Margin = new Padding(4);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(98, 42);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "确定";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(232, 216);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 42);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(428, 288);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtOldPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "修改密码";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}