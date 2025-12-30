using System;
using System.Windows.Forms;

namespace DrinkShop
{
    public partial class UserCenterForm : Form
    {
        private string currentUserPhone;
        private UserInfo currentUserInfo;
        // 添加一个标志来记录是否修改了用户信息
        private bool isUserInfoUpdated = false;

        // 在构造函数中订阅事件
        public UserCenterForm(string phone)
        {
            InitializeComponent();
            this.currentUserPhone = phone;
            LoadUserInfo();

            // 订阅FormClosing事件
            this.FormClosing += UserCenterForm_FormClosing;
        }

        private void LoadUserInfo()
        {
            try
            {
                DBhelper db = new DBhelper();
                currentUserInfo = db.GetUserDetail(currentUserPhone);

                // 显示用户信息
                txtPhone.Text = currentUserInfo.Phone;
                txtName.Text = currentUserInfo.Name;
                txtAddress.Text = currentUserInfo.Address;

                // 显示统计信息
                lblOrderCount.Text = $"历史订单：{currentUserInfo.OrderCount} 单";
                lblTotalAmount.Text = $"累计消费：￥{currentUserInfo.TotalAmount:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载用户信息失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 保存修改
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("姓名不能为空", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            DBhelper db = new DBhelper();
            var result = db.UpdateUserInfo(currentUserPhone, name, address);

            if (result.Success)
            {
                // 重要：设置更新标志为true
                isUserInfoUpdated = true;

                MessageBox.Show(result.Message, "成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentUserInfo.Name = name;
                currentUserInfo.Address = address;
            }
            else
            {
                MessageBox.Show(result.Message, "修改失败",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 修改密码
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (ChangePasswordForm form = new ChangePasswordForm(currentUserPhone))
            {
                form.ShowDialog();
            }
        }

        // 注销账号
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "警告：此操作将永久删除您的账号和所有订单记录，且无法恢复！\n\n确定要继续吗？",
                "确认注销",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            // 弹出密码验证窗体
            using (PasswordConfirmForm form = new PasswordConfirmForm("请输入密码确认注销"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string password = form.Password;

                    DBhelper db = new DBhelper();
                    var result = db.DeleteUser(currentUserPhone, password);

                    if (result.Success)
                    {
                        MessageBox.Show("账号已成功注销，感谢您使用我们的服务！", "注销成功",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 关闭所有窗体并重新启动登录界面
                        Application.Restart();
                        Environment.Exit(0);
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "注销失败",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 在UserCenterForm中添加
        private void UserCenterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 如果修改了信息，设置DialogResult为OK
            if (isUserInfoUpdated)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}