using System;
using System.Data;
using System.Windows.Forms;

namespace DrinkShop
{
    public partial class HistoryOrder : Form
    {
        private string currentUserPhone;

        public HistoryOrder(string phone)
        {
            InitializeComponent();
            this.currentUserPhone = phone;
        }

        private void HistoryOrder_Load(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            try
            {
                if (string.IsNullOrEmpty(currentUserPhone))
                {
                    MessageBox.Show("未获取到用户手机号，无法加载订单历史。", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DBhelper dBhelper = new DBhelper();
                DataTable historyData = dBhelper.GetOrderHistory(currentUserPhone);

                // 检查DataTable是否有数据
                if (historyData == null || historyData.Rows.Count == 0)
                {
                    // 清空DataGridView
                    dataGridView1.DataSource = null;

                    // 显示友好的提示信息
                    Label noOrdersLabel = new Label
                    {
                        Text = "您还没有历史订单，快去下单吧！",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Microsoft YaHei", 12, FontStyle.Bold),
                        ForeColor = Color.Gray,
                        Dock = DockStyle.Fill,
                        AutoSize = false
                    };

                    // 清空DataGridView并添加提示
                    dataGridView1.Controls.Clear();
                    dataGridView1.Controls.Add(noOrdersLabel);

                    // 隐藏列标题
                    dataGridView1.ColumnHeadersVisible = false;

                    return;
                }

                // 如果有数据，显示列标题并绑定数据
                dataGridView1.ColumnHeadersVisible = true;
                dataGridView1.Controls.Clear(); // 移除可能的提示标签

                dataGridView1.DataSource = historyData;

                // 设置列标题

                if (historyData.Columns.Contains("OrderTime"))
                    dataGridView1.Columns["OrderTime"].HeaderText = "下单时间";

                if (historyData.Columns.Contains("TotalAmount"))
                {
                    dataGridView1.Columns["TotalAmount"].HeaderText = "总金额";
                    dataGridView1.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
                    dataGridView1.Columns["TotalAmount"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }

                if (historyData.Columns.Contains("Items"))
                {
                    dataGridView1.Columns["Items"].HeaderText = "订单详情";
                    dataGridView1.Columns["Items"].Width = 300;
                }

                if (historyData.Columns.Contains("ItemCount"))
                {
                    dataGridView1.Columns["ItemCount"].HeaderText = "商品数量";
                    dataGridView1.Columns["ItemCount"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }

                // 设置DataGridView样式
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                // 确保最后一列填充剩余空间
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }

                // 设置交替行颜色，提高可读性
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

                // 设置选择模式
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.ReadOnly = true;

                // 显示订单数量
                this.Text = $"历史订单 - 共 {historyData.Rows.Count} 条订单";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载订单历史失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}