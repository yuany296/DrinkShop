using System;
using System.Windows.Forms;

namespace DrinkShop
{
    public partial class ChangePasswordForm : Form
    {
        private string currentUserPhone;

        public ChangePasswordForm(string phone)
        {
            InitializeComponent();
            currentUserPhone = phone;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // 验证输入
            if (string.IsNullOrWhiteSpace(oldPassword))
            {
                MessageBox.Show("请输入旧密码", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("请输入新密码", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("两次输入的新密码不一致", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (newPassword == oldPassword)
            {
                MessageBox.Show("新密码不能与旧密码相同", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            // 调用DBhelper修改密码
            DBhelper db = new DBhelper();
            var result = db.ChangePassword(currentUserPhone, oldPassword, newPassword);

            if (result.Success)
            {
                MessageBox.Show(result.Message, "成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "修改失败",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPassword.Focus();
                txtOldPassword.SelectAll();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}