using System;
using System.Windows.Forms;

namespace DrinkShop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 先显示登录窗体
            using (login loginForm = new login())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // 登录成功后，运行主窗体
                    Application.Run(new Order(loginForm.UserPhone));
                }
                else
                {
                    // 登录失败或取消，退出程序
                    return;
                }
            }
        }
    }
}