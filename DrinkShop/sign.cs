using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrinkShop
{
    public partial class sign : Form
    {
        private string phone = string.Empty;
        private string password = string.Empty;
        private string name = string.Empty;
        private string address = string.Empty;

        public sign()
        {
            InitializeComponent();

            // 添加输入验证
            AddInputValidation();

            // 为文本框添加提示文字
            AddPlaceholderText();

            // 设置Tab键顺序
            SetTabOrder();

            // 初始化按钮状态
            button1.Enabled = false;
        }

        private void AddInputValidation()
        {
            // 手机号文本框只允许输入数字，限制11位
            textBox2.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                // 限制最大11位
                if (textBox2.Text.Length >= 11 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            // 监听文本框变化，实时验证并更新按钮状态
            textBox1.TextChanged += (sender, e) => { this.name = textBox1.Text.Trim(); UpdateRegisterButtonState(); };
            textBox2.TextChanged += (sender, e) => { this.phone = textBox2.Text.Trim(); UpdateRegisterButtonState(); };
            textBox4.TextChanged += (sender, e) => { this.address = textBox4.Text.Trim(); };
            textBox5.TextChanged += (sender, e) => { this.password = textBox5.Text; UpdateRegisterButtonState(); };

            // 支持Enter键提交
            textBox5.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter && button1.Enabled)
                {
                    button1_Click(sender, e);
                }
            };
        }

        private void AddPlaceholderText()
        {
            // 为地址框添加提示文字
            textBox4.GotFocus += (sender, e) =>
            {
                if (textBox4.Text == "选填")
                {
                    textBox4.Text = "";
                    textBox4.ForeColor = SystemColors.WindowText;
                }
            };

            textBox4.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    textBox4.Text = "选填";
                    textBox4.ForeColor = Color.Gray;
                }
            };

            // 初始化地址框
            textBox4.Text = "选填";
            textBox4.ForeColor = Color.Gray;
        }

        private void SetTabOrder()
        {
            textBox2.TabIndex = 1;
            textBox1.TabIndex = 2;
            textBox5.TabIndex = 3;
            textBox4.TabIndex = 4;
            button1.TabIndex = 5;
            linkLabel1.TabIndex = 6;
        }

        private void UpdateRegisterButtonState()
        {
            // 验证所有必填项是否填写
            bool nameValid = !string.IsNullOrWhiteSpace(name);
            bool phoneValid = !string.IsNullOrWhiteSpace(phone);
            bool passwordValid = !string.IsNullOrWhiteSpace(password);

            button1.Enabled = nameValid && phoneValid && passwordValid;

            // 更新按钮颜色
            if (button1.Enabled)
            {
                button1.BackColor = Color.FromArgb(0, 122, 204);
            }
            else
            {
                button1.BackColor = Color.LightGray;
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // 绘制Logo
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 绘制圆形背景
            using (Brush brush = new SolidBrush(Color.FromArgb(0, 122, 204)))
            {
                e.Graphics.FillEllipse(brush, 5, 5, 90, 90);
            }

            // 绘制文字
            using (Font font = new Font("Microsoft YaHei", 20, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.White))
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString("Drink", font, textBrush,
                    new RectangleF(5, 5, 90, 90), format);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 已通过AddInputValidation方法处理
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // 已通过AddInputValidation方法处理
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // 已通过AddInputValidation方法处理
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // 已通过AddInputValidation方法处理
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 返回登录界面
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 前端验证
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("请输入用户名", "输入错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

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
                textBox5.Focus();
                return;
            }

            // 如果地址是"选填"，则设置为空
            if (address == "选填")
            {
                address = string.Empty;
            }

            // 显示加载状态
            button1.Text = "注册中...";
            button1.Enabled = false;
            Application.DoEvents();

            DBhelper db = new DBhelper();
            var result = db.SignUp(phone, name, address, password);

            if (result.Success)
            {
                MessageBox.Show(result.Message, "注册成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "注册失败",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 如果失败原因是手机号已存在，清空手机号框
                if (result.Message.Contains("手机号已注册"))
                {
                    textBox2.Focus();
                    textBox2.SelectAll();
                }

                // 恢复按钮状态
                button1.Text = "注 册";
                UpdateRegisterButtonState();
            }
        }

        // 窗体加载事件
        private void sign_Load(object sender, EventArgs e)
        {
            // 自动聚焦到手机号输入框
            textBox2.Focus();
        }

        // 键盘事件处理
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}