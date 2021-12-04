using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using _61.CuaHangDoDa.Class;

namespace _61.CuaHangDoDa.Forms
{
    public partial class frmdangnhap : Form
    {
        public frmdangnhap()
        {
            InitializeComponent();
        }
        public void login()
        {
            string user = "winform";
            string pass = "nhom09";

            if (txtusername.Text.Length == 0 && txtpassword.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Username và Password");
                txtusername.Focus();
            }
            else if (txtusername.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Username");
                txtusername.Focus();
            }
            else if (txtpassword.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Password");
                txtpassword.Focus();
            }
            else if (user == txtusername.Text && pass == txtpassword.Text)
            {
                this.Hide();     //ẩn form đăng nhập           
                frmMenu f = new frmMenu();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                txtusername.Text = "";
                txtpassword.Text = "";
                txtusername.Focus();
            }
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            
            login();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
