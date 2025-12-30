using System;
using System.Windows.Forms;

namespace DrinkShop
{
    public partial class PasswordConfirmForm : Form
    {
        public string Password { get; private set; }
        private string promptText;

        public PasswordConfirmForm(string prompt)
        {
            InitializeComponent();
            promptText = prompt;
            lblPrompt.Text = prompt;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("请输入密码", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            Password = txtPassword.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}