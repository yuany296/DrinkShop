using System;
using System.Windows.Forms;

namespace DrinkShop
{
    public partial class QuantityForm : Form
    {
        // 公开属性，用于获取用户输入的数量
        public int Quantity { get; private set; }

        // 构造函数
        public QuantityForm(int currentQuantity, int maxQuantity = 100)
        {
            InitializeComponent();

            // 设置数值范围
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = maxQuantity;
            numericUpDown1.Value = currentQuantity;

            // 设置窗体标题
            this.Text = $"修改数量 (最大: {maxQuantity})";
        }

        // 窗体加载事件
        private void QuantityForm_Load(object sender, EventArgs e)
        {
            // 窗体加载时自动聚焦到输入框
            numericUpDown1.Focus();
            numericUpDown1.Select(0, numericUpDown1.Text.Length);
        }

        // 确定按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            Quantity = (int)numericUpDown1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 取消按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 键盘事件处理
        private void QuantityForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                button2_Click(sender, e);
            }
        }
    }
}