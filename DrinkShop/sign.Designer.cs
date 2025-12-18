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
            label7 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 123);
            label1.Name = "label1";
            label1.Size = new Size(64, 24);
            label1.TabIndex = 0;
            label1.Text = "用户名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(126, 243);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 1;
            label2.Text = "密码";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(108, 183);
            label4.Name = "label4";
            label4.Size = new Size(64, 24);
            label4.TabIndex = 3;
            label4.Text = "手机号";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(126, 303);
            label5.Name = "label5";
            label5.Size = new Size(46, 24);
            label5.TabIndex = 4;
            label5.Text = "地址";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(378, 43);
            label7.Name = "label7";
            label7.Size = new Size(82, 24);
            label7.TabIndex = 6;
            label7.Text = "注册界面";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(221, 120);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(400, 30);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(221, 180);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(400, 30);
            textBox2.TabIndex = 8;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(221, 300);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(400, 30);
            textBox4.TabIndex = 10;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(221, 240);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(400, 30);
            textBox5.TabIndex = 11;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(273, 377);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 14;
            button1.Text = "注册";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(429, 379);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(46, 24);
            linkLabel1.TabIndex = 15;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "取消";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // sign
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLabel1);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "sign";
            Text = "sign";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label7;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button1;
        private LinkLabel linkLabel1;
    }
}