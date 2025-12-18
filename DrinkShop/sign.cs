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
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.name = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.phone = textBox2.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.password = textBox5.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.address = textBox4.Text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //取消键，关掉窗口
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBhelper db = new DBhelper();
            var result = db.SignUp(phone, name, address, password);
            if (result.Success)
            {
                MessageBox.Show(result.Message, "注册成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "注册失败",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
