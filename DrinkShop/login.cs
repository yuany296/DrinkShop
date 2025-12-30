using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DrinkShop
{
    public partial class login : Form
    {
        // 添加公共属性，用于传递手机号
        public string UserPhone { get; private set; }

        private string phone = string.Empty;
        private string password = string.Empty;

        public login()
        {
            InitializeComponent();

            // 添加键盘事件
            this.KeyPreview = true;

            // 初始化时禁用按钮
            button1.Enabled = false;

            // 为文本框添加输入验证
            AddInputValidation();
        }

        private void AddInputValidation()
        {
            // 手机号文本框只允许输入数字
            textBox2.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("只能输入数字", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 限制最大11位
                if (textBox2.Text.Length >= 11 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("手机号最多11位", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            textBox2.TextChanged += (sender, e) =>
            {
                phone = textBox2.Text.Trim();

                // 如果通过粘贴等方式超过11位，自动截断
                if (phone.Length > 11)
                {
                    textBox2.Text = phone.Substring(0, 11);
                    textBox2.SelectionStart = textBox2.Text.Length;
                    MessageBox.Show("手机号最多11位，已自动截断", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                UpdateLoginButtonState();
            };

            textBox1.TextChanged += (sender, e) =>
            {
                password = textBox1.Text;
                UpdateLoginButtonState();
            };
        }

        private void UpdateLoginButtonState()
        {
            // 当手机号和密码都不为空时才启用登录按钮
            bool phoneValid = !string.IsNullOrWhiteSpace(phone);
            bool passwordValid = !string.IsNullOrWhiteSpace(password);

            button1.Enabled = phoneValid && passwordValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 前端验证手机号格式
            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 11)
            {
                MessageBox.Show("手机号必须是11位数字", "输入错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("请输入密码", "输入错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            // 显示加载提示
            button1.Text = "登录中...";
            button1.Enabled = false;
            Application.DoEvents();

            try
            {
                DBhelper db = new DBhelper();
                string s = db.LoginIn(phone, password);

                if (s.StartsWith("登录成功"))
                {
                    UserPhone = this.phone; // 保存手机号
                    this.DialogResult = DialogResult.OK; // 设置对话框结果
                    this.Close(); // 关闭登录窗体
                }
                else
                {
                    MessageBox.Show(s, "登录失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Text = "登 录";
                    button1.Enabled = true;

                    // 密码错误时清空密码框
                    if (s.Contains("密码错误"))
                    {
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"登录异常: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Text = "登 录";
                button1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 窗体加载时自动聚焦到手机号输入框
            textBox2.Focus();

            // 设置Tab顺序
            textBox2.TabIndex = 1;
            textBox1.TabIndex = 2;
            button1.TabIndex = 3;
            linkLabel1.TabIndex = 4;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // 手机号输入时去除空格
            phone = textBox2.Text.Trim();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            password = textBox1.Text;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // 按Enter键直接登录
            if (e.KeyCode == Keys.Enter && button1.Enabled)
            {
                button1_Click(sender, e);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 打开注册界面
            sign signForm = new sign();
            signForm.ShowDialog();
        }

        // 添加窗体键盘事件
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("确定要退出程序吗？", "退出确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}