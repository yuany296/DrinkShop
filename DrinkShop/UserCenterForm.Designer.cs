namespace DrinkShop
{
    partial class UserCenterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblOrderCount;
        private System.Windows.Forms.Label lblTotalAmount;

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
            txtPhone = new TextBox();
            txtName = new TextBox();
            txtAddress = new TextBox();
            btnSave = new Button();
            btnChangePassword = new Button();
            btnDeleteAccount = new Button();
            btnClose = new Button();
            lblOrderCount = new Label();
            lblTotalAmount = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 70);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 24);
            label1.TabIndex = 10;
            label1.Text = "手机号:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 130);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 24);
            label2.TabIndex = 9;
            label2.Text = "姓  名:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 190);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(60, 24);
            label3.TabIndex = 8;
            label3.Text = "地  址:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(128, 66);
            txtPhone.Margin = new Padding(4, 4, 4, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(244, 30);
            txtPhone.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(128, 126);
            txtName.Margin = new Padding(4, 4, 4, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(244, 30);
            txtName.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(128, 186);
            txtAddress.Margin = new Padding(4, 4, 4, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(366, 30);
            txtAddress.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LightGreen;
            btnSave.Location = new Point(223, 262);
            btnSave.Margin = new Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(98, 42);
            btnSave.TabIndex = 4;
            btnSave.Text = "保存修改";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.LightSkyBlue;
            btnChangePassword.Location = new Point(37, 262);
            btnChangePassword.Margin = new Padding(4, 4, 4, 4);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(147, 42);
            btnChangePassword.TabIndex = 5;
            btnChangePassword.Text = "修改密码";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.BackColor = Color.LightCoral;
            btnDeleteAccount.Location = new Point(302, 336);
            btnDeleteAccount.Margin = new Padding(4, 4, 4, 4);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(147, 42);
            btnDeleteAccount.TabIndex = 6;
            btnDeleteAccount.Text = "注销账号";
            btnDeleteAccount.UseVisualStyleBackColor = false;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.LightGray;
            btnClose.Location = new Point(351, 262);
            btnClose.Margin = new Padding(4, 4, 4, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(98, 42);
            btnClose.TabIndex = 7;
            btnClose.Text = "关闭";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblOrderCount
            // 
            lblOrderCount.AutoSize = true;
            lblOrderCount.Font = new Font("Microsoft Sans Serif", 10F);
            lblOrderCount.Location = new Point(37, 336);
            lblOrderCount.Margin = new Padding(4, 0, 4, 0);
            lblOrderCount.Name = "lblOrderCount";
            lblOrderCount.Size = new Size(125, 20);
            lblOrderCount.TabIndex = 1;
            lblOrderCount.Text = "历史订单：0 单";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Microsoft Sans Serif", 10F);
            lblTotalAmount.Location = new Point(37, 372);
            lblTotalAmount.Margin = new Padding(4, 0, 4, 0);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(142, 20);
            lblTotalAmount.TabIndex = 0;
            lblTotalAmount.Text = "累计消费：￥0.00";
            // 
            // UserCenterForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(513, 420);
            Controls.Add(lblTotalAmount);
            Controls.Add(lblOrderCount);
            Controls.Add(btnClose);
            Controls.Add(btnDeleteAccount);
            Controls.Add(btnChangePassword);
            Controls.Add(btnSave);
            Controls.Add(txtAddress);
            Controls.Add(txtName);
            Controls.Add(txtPhone);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserCenterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "个人中心";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}