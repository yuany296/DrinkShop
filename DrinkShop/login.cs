using System.ComponentModel.DataAnnotations;
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
        }

        private void button1_Click(object sender, EventArgs e)
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
                MessageBox.Show(s);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            phone = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            password = textBox1.Text;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //打开注册界面
            sign signForm = new sign();
            signForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}