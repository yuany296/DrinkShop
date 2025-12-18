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

                dataGridView1.DataSource = historyData;

                if (historyData != null && historyData.Rows.Count > 0)
                {
                    // 设置列标题
                    if (historyData.Columns.Contains("OrderID"))
                        dataGridView1.Columns["OrderID"].HeaderText = "订单编号";

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
                        dataGridView1.Columns["Items"].Width = 300; // 设置较宽的列
                    }

                    if (historyData.Columns.Contains("ItemCount"))
                    {
                        dataGridView1.Columns["ItemCount"].HeaderText = "商品数量";
                        dataGridView1.Columns["ItemCount"].DefaultCellStyle.Alignment =
                            DataGridViewContentAlignment.MiddleCenter;
                    }

                    // 设置DataGridView样式
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView1.Columns[historyData.Columns.Count - 1].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill; // 最后一列填充剩余空间

                    // 设置交替行颜色，提高可读性
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;

                    // 设置选择模式
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = false;
                    dataGridView1.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("您还没有历史订单。", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载订单历史失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}