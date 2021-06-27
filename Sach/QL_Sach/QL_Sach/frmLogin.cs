using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sach
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void bbtnLogin_Click(object sender, EventArgs e)
        {
            string username = "Admin";
            string password = "Admin";

            if (username.Equals(btxtUserName.Text.Trim()) && password == btxtPassWord.Text.Trim())
            {
                MessageBox.Show("Đăng nhập thành công!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain tableManager = new frmMain();
                this.Hide();
                tableManager.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu, Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
