namespace DrinkShop
{
    partial class sign
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
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            panel1 = new Panel();
            label7 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 10.5F);
            label1.Location = new Point(102, 152);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 0;
            label1.Text = "用户名：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 10.5F);
            label2.Location = new Point(120, 272);
            label2.Name = "label2";
            label2.Size = new Size(64, 24);
            label2.TabIndex = 1;
            label2.Text = "密码：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 10.5F);
            label4.Location = new Point(102, 212);
            label4.Name = "label4";
            label4.Size = new Size(82, 24);
            label4.TabIndex = 3;
            label4.Text = "手机号：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微软雅黑", 10.5F);
            label5.Location = new Point(120, 332);
            label5.Name = "label5";
            label5.Size = new Size(64, 24);
            label5.TabIndex = 4;
            label5.Text = "地址：";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("微软雅黑", 10.5F);
            textBox1.Location = new Point(230, 150);
            textBox1.MaxLength = 30;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(350, 31);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("微软雅黑", 10.5F);
            textBox2.Location = new Point(230, 210);
            textBox2.MaxLength = 11;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(350, 31);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Font = new Font("微软雅黑", 10.5F);
            textBox4.Location = new Point(230, 330);
            textBox4.MaxLength = 50;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(350, 31);
            textBox4.TabIndex = 4;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Font = new Font("微软雅黑", 10.5F);
            textBox5.Location = new Point(230, 270);
            textBox5.MaxLength = 50;
            textBox5.Name = "textBox5";
            textBox5.PasswordChar = '*';
            textBox5.Size = new Size(350, 31);
            textBox5.TabIndex = 3;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 122, 204);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(230, 408);
            button1.Name = "button1";
            button1.Size = new Size(145, 45);
            button1.TabIndex = 5;
            button1.Text = "注 册";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.FromArgb(64, 64, 64);
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("微软雅黑", 10F);
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.LinkColor = Color.FromArgb(64, 64, 64);
            linkLabel1.Location = new Point(457, 420);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(112, 23);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "返回登录界面";
            linkLabel1.VisitedLinkColor = Color.FromArgb(64, 64, 64);
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(240, 248, 255);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(782, 553);
            panel1.TabIndex = 16;
            // 
            // label7
            // 
            label7.AccessibleRole = AccessibleRole.Clock;
            label7.AutoSize = true;
            label7.Font = new Font("微软雅黑", 18F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(0, 122, 204);
            label7.Location = new Point(315, 50);
            label7.Name = "label7";
            label7.Size = new Size(137, 40);
            label7.TabIndex = 6;
            label7.Text = "用户注册";
            // 
            // sign
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(782, 553);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "sign";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "饮品店系统 - 注册";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button1;
        private LinkLabel linkLabel1;
        private Panel panel1;
        private Label label7;
    }
}