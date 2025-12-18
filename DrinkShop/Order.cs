using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrinkShop
{
    public partial class Order : Form
    {
        // 购物车列表
        private BindingList<CartItem> shoppingCart = new BindingList<CartItem>();
        private string currentUserPhone;
        private string currentUserName;

        public Order(string phone)
        {
            InitializeComponent();
            currentUserPhone = phone;

            // 获取用户姓名
            GetUserName(phone);

            // 初始化购物车绑定
            InitializeCartBinding();

            // 初始化控件状态
            InitializeCartSettings();
            LoadDrinkTypes();
        }

        private void GetUserName(string phone)
        {
            try
            {
                DBhelper db = new DBhelper();
                // 这里需要添加一个获取用户姓名的方法
                // 暂时先显示手机号
                label4.Text = $"用户：{phone}";
            }
            catch
            {
                label4.Text = $"用户：{phone}";
            }
        }

        private void InitializeCartBinding()
        {
            // 绑定购物车到ListBox
            listBox1.DataSource = shoppingCart;
            listBox1.DisplayMember = "DisplayText";
            listBox1.ValueMember = "DrinkId";
        }

        private void InitializeCartSettings()
        {
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 100;
            numericUpDown1.Value = 1;

            // 设置DataGridView选择模式
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            // 设置ListBox选择模式
            listBox1.SelectionMode = SelectionMode.One;

            UpdateTotalAmount();
        }

        private void LoadDrinkTypes()
        {
            DBhelper dBhelper = new DBhelper();
            List<string> typeList = dBhelper.GetDrinkType();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(typeList.ToArray());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;
            string selectedType = comboBox1.SelectedItem.ToString();
            LoadDrinksBySelectedType(selectedType);
        }

        private void LoadDrinksBySelectedType(string type)
        {
            DBhelper dBhelper = new DBhelper();
            DataTable drinksData = dBhelper.GetDrinks(type);
            dataGridView1.DataSource = drinksData;
        }

        // --- 功能 1: 加入购物车 ---
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要购买的饮品。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            try
            {
                int drinkId = Convert.ToInt32(selectedRow.Cells["饮品ID"].Value);
                decimal price = Convert.ToDecimal(selectedRow.Cells["价格"].Value);
                int stock = Convert.ToInt32(selectedRow.Cells["库存"].Value);
                string name = selectedRow.Cells["饮品名称"].Value.ToString();
                int quantity = (int)numericUpDown1.Value;

                if (quantity > stock)
                {
                    MessageBox.Show($"库存不足！当前库存: {stock}", "库存警告",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 检查购物车中是否已有该商品
                CartItem existingItem = shoppingCart.FirstOrDefault(item => item.DrinkId == drinkId);
                if (existingItem != null)
                {
                    // 如果已有，增加数量
                    if (existingItem.Quantity + quantity > stock)
                    {
                        MessageBox.Show($"库存不足！当前库存: {stock}，购物车中已有 {existingItem.Quantity} 件",
                            "库存警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    existingItem.Quantity += quantity;
                }
                else
                {
                    // 如果没有，添加新项
                    shoppingCart.Add(new CartItem
                    {
                        DrinkId = drinkId,
                        Name = name,
                        Price = price,
                        Quantity = quantity
                    });
                }

                UpdateTotalAmount();
                MessageBox.Show($"已成功添加 {name} × {quantity} 到购物车", "成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据处理出错：" + ex.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 功能 2: 从购物车删除选中项 ---
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("请选择要删除的购物车项。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CartItem selectedItem = listBox1.SelectedItem as CartItem;
            if (selectedItem == null) return;

            DialogResult result = MessageBox.Show(
                $"确定要从购物车删除 {selectedItem.Name} × {selectedItem.Quantity} 吗？",
                "确认删除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                shoppingCart.Remove(selectedItem);
                UpdateTotalAmount();
                MessageBox.Show("已从购物车删除", "成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- 功能 3: 清空购物车 ---
        private void button5_Click(object sender, EventArgs e)
        {
            if (shoppingCart.Count == 0)
            {
                MessageBox.Show("购物车已经是空的！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"确定要清空购物车吗？共 {shoppingCart.Count} 件商品，总计 {shoppingCart.Sum(item => item.Subtotal):C}",
                "确认清空",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                shoppingCart.Clear();
                UpdateTotalAmount();
                MessageBox.Show("购物车已清空", "成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- 功能 4: 修改购物车数量 ---
        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("请选择要修改数量的购物车项。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CartItem selectedItem = listBox1.SelectedItem as CartItem;
            if (selectedItem == null) return;

            // 检查当前库存
            DBhelper db = new DBhelper();
            DataTable drinks = db.GetDrinks();
            var row = drinks.Select($"饮品ID = {selectedItem.DrinkId}").FirstOrDefault();

            if (row != null)
            {
                int stock = Convert.ToInt32(row["库存"]);

                // 弹出对话框输入新数量
                using (QuantityForm qtyForm = new QuantityForm(selectedItem.Quantity, stock))
                {
                    if (qtyForm.ShowDialog() == DialogResult.OK)
                    {
                        int newQuantity = qtyForm.Quantity;

                        if (newQuantity > stock)
                        {
                            MessageBox.Show($"库存不足！当前库存: {stock}", "库存警告",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        selectedItem.Quantity = newQuantity;
                        UpdateTotalAmount();
                        MessageBox.Show($"已将 {selectedItem.Name} 数量修改为 {newQuantity}", "成功",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = shoppingCart.Sum(item => item.Subtotal);
            label2.Text = $"总计金额: ￥{total:F2}";
            label2.ForeColor = total > 0 ? Color.Red : Color.Black;

            // 更新按钮状态
            button3.Enabled = shoppingCart.Count > 0;
            button4.Enabled = listBox1.SelectedItem != null;
            button6.Enabled = listBox1.SelectedItem != null;
        }

        // --- 功能 5: 结算下单 ---
        private void button3_Click(object sender, EventArgs e)
        {
            if (shoppingCart.Count == 0)
            {
                MessageBox.Show("购物车为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalAmount = shoppingCart.Sum(item => item.Subtotal);

            // 显示订单详情
            string orderDetails = "订单详情：\n\n";
            foreach (var item in shoppingCart)
            {
                orderDetails += $"{item.Name} × {item.Quantity} = ￥{item.Subtotal:F2}\n";
            }
            orderDetails += $"\n总计: ￥{totalAmount:F2}";

            DialogResult result = MessageBox.Show(
                $"{orderDetails}\n\n确认结算吗？",
                "订单确认",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DBhelper dbHelper = new DBhelper();
                (bool success, string message) = dbHelper.PlaceOrder(currentUserPhone,
                    shoppingCart.ToList(), totalAmount);

                if (success)
                {
                    MessageBox.Show(message, "下单成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    shoppingCart.Clear();
                    UpdateTotalAmount();
                    LoadDrinksBySelectedType(comboBox1.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show(message, "下单失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 查看历史订单
        private void button1_Click(object sender, EventArgs e)
        {
            HistoryOrder historyForm = new HistoryOrder(this.currentUserPhone);
            historyForm.ShowDialog();
        }

        // 退出登录
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出登录吗？", "退出确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                // 重新显示登录界面
                login loginForm = new login();
                loginForm.Show();
            }
        }

        // 购物车列表选择变化
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 更新删除按钮状态
            button4.Enabled = listBox1.SelectedItem != null;
            button6.Enabled = listBox1.SelectedItem != null;
        }

        // 双击购物车项也可以删除
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        // 按键事件：支持Delete键删除
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listBox1.SelectedItem != null)
            {
                button4_Click(sender, e);
            }
        }

        // 双击DataGridView行直接加入购物车（使用默认数量）
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 临时将选择的行设为选中状态
                dataGridView1.Rows[e.RowIndex].Selected = true;
                button2_Click(sender, e);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 留空
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // 留空
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // 留空
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // 留空
        }
    }
}