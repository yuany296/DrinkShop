namespace DrinkShop
{
    partial class login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            label3 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("微软雅黑", 10.5F);
            textBox1.Location = new Point(222, 261);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(300, 31);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("微软雅黑", 10.5F);
            textBox2.Location = new Point(222, 159);
            textBox2.MaxLength = 11;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(300, 31);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("微软雅黑", 10.5F);
            label1.Location = new Point(110, 161);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 2;
            label1.Text = "手机号：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 10.5F);
            label2.Location = new Point(128, 263);
            label2.Name = "label2";
            label2.Size = new Size(64, 24);
            label2.TabIndex = 3;
            label2.Text = "密码：";
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.FromArgb(0, 122, 204);
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("微软雅黑", 10F);
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.LinkColor = Color.FromArgb(0, 122, 204);
            linkLabel1.Location = new Point(392, 359);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(180, 23);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "还没有账号？立即注册";
            linkLabel1.VisitedLinkColor = Color.FromArgb(0, 122, 204);
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("微软雅黑", 18F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(0, 122, 204);
            label3.Location = new Point(298, 51);
            label3.Name = "label3";
            label3.Size = new Size(137, 40);
            label3.TabIndex = 6;
            label3.Text = "用户登录";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 122, 204);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(222, 347);
            button1.Name = "button1";
            button1.Size = new Size(138, 45);
            button1.TabIndex = 3;
            button1.Text = "登 录";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(240, 248, 255);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(720, 458);
            panel1.TabIndex = 8;
            // 
            // login
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(720, 458);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "饮品店系统 - 登录";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
        private Label label3;
        private Button button1;
        private Panel panel1;
    }
}