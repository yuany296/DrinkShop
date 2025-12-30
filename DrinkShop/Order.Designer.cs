namespace DrinkShop
{
    partial class Order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            listBox1 = new ListBox();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            oracleCommandBuilder1 = new Oracle.ManagedDataAccess.Client.OracleCommandBuilder();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(115, 104);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 32);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSkyBlue;
            button1.Font = new Font("Microsoft Sans Serif", 9F);
            button1.Location = new Point(911, 37);
            button1.Name = "button1";
            button1.Size = new Size(129, 29);
            button1.TabIndex = 4;
            button1.Text = "查看历史订单";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(42, 142);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(709, 377);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(868, 139);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(132, 30);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F);
            label1.Location = new Point(806, 141);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 4;
            label1.Text = "数量：";
            label1.Click += label1_Click;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Microsoft Sans Serif", 10F);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(815, 200);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(345, 224);
            listBox1.TabIndex = 6;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.DoubleClick += listBox1_DoubleClick;
            listBox1.KeyDown += listBox1_KeyDown;
            // 
            // button2
            // 
            button2.BackColor = Color.LightGreen;
            button2.Font = new Font("Microsoft Sans Serif", 9F);
            button2.Location = new Point(1033, 141);
            button2.Name = "button2";
            button2.Size = new Size(127, 31);
            button2.TabIndex = 3;
            button2.Text = "加入购物车";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Gold;
            button3.Enabled = false;
            button3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            button3.Location = new Point(1066, 488);
            button3.Name = "button3";
            button3.Size = new Size(94, 37);
            button3.TabIndex = 10;
            button3.Text = "结算下单";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(815, 493);
            label2.Name = "label2";
            label2.Size = new Size(146, 20);
            label2.TabIndex = 8;
            label2.Text = "总计金额: ￥0.00";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10F);
            label3.Location = new Point(52, 107);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 9;
            label3.Text = "类别：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10F);
            label4.Location = new Point(51, 41);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 10;
            label4.Text = "用户：加载中...";
            label4.Click += label1_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.LightCoral;
            button4.Enabled = false;
            button4.Font = new Font("Microsoft Sans Serif", 9F);
            button4.Location = new Point(815, 443);
            button4.Name = "button4";
            button4.Size = new Size(113, 37);
            button4.TabIndex = 7;
            button4.Text = "删除选中项";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.LightCoral;
            button5.Font = new Font("Microsoft Sans Serif", 9F);
            button5.Location = new Point(1039, 443);
            button5.Name = "button5";
            button5.Size = new Size(121, 37);
            button5.TabIndex = 9;
            button5.Text = "清空购物车";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.LightSkyBlue;
            button6.Enabled = false;
            button6.Font = new Font("Microsoft Sans Serif", 9F);
            button6.Location = new Point(934, 443);
            button6.Name = "button6";
            button6.Size = new Size(94, 37);
            button6.TabIndex = 8;
            button6.Text = "修改数量";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.LightGray;
            button7.Font = new Font("Microsoft Sans Serif", 9F);
            button7.Location = new Point(1066, 37);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 5;
            button7.Text = "退出登录";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(772, 37);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 11;
            button8.Text = "用户中心";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // Order
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1205, 580);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Name = "Order";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "饮品点单系统";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private ListBox listBox1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Label label3;
        private Label label4;
        private Oracle.ManagedDataAccess.Client.OracleCommandBuilder oracleCommandBuilder1;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
    }
}