using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using _61.CuaHangDoDa.Forms;

namespace _61.CuaHangDoDa
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect();
            Application.Exit();
        }

        private void mnuSanpham_Click(object sender, EventArgs e)
        {
            Forms.frmDMSanpham f = new Forms.frmDMSanpham();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuFindSanpham_Click(object sender, EventArgs e)
        {
            Forms.frmTimSanPham f = new Forms.frmTimSanPham();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCDoanhthu_Click(object sender, EventArgs e)
        {
            Forms.frmBCDoanhthu f = new Forms.frmBCDoanhthu();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNhanvien_Click(object sender, EventArgs e)
        {
            Forms.frmDMNhanvien f = new Forms.frmDMNhanvien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuKhachhang_Click(object sender, EventArgs e)
        {
            Forms.frmDMKhachhang f = new Forms.frmDMKhachhang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNhacungcap_Click(object sender, EventArgs e)
        {
            Forms.frmDMNhacungcap f = new Forms.frmDMNhacungcap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuHoadonnhap_Click(object sender, EventArgs e)
        {
            frmhdnhap f = new frmhdnhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuHoadonban_Click(object sender, EventArgs e)
        {
            Forms.frmhoadonban f = new Forms.frmhoadonban();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCSanpham_Click(object sender, EventArgs e)
        {
            Forms.frmbaocaodanhsachsanpham f = new Forms.frmbaocaodanhsachsanpham();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuFindHoadonnhap_Click(object sender, EventArgs e)
        {
            Forms.frmtimkiemhoadonnhap f = new Forms.frmtimkiemhoadonnhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCHoadonnhap_Click(object sender, EventArgs e)
        {
            Forms.frmBCHDNhap f = new Forms.frmBCHDNhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCHoadonban_Click(object sender, EventArgs e)
        {
            Forms.frmBCHDBan f = new Forms.frmBCHDBan();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuque_Click(object sender, EventArgs e)
        {
            Forms.frmque f = new Forms.frmque();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnutheloai_Click(object sender, EventArgs e)
        {
            Forms.frmtheloai f = new Forms.frmtheloai();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnunuocsanxuat_Click(object sender, EventArgs e)
        {
            Forms.frmnuocsanxuat f = new Forms.frmnuocsanxuat();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuchatlieu_Click(object sender, EventArgs e)
        {
            Forms.frmchatlieu f = new Forms.frmchatlieu();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnumausac_Click(object sender, EventArgs e)
        {
            Forms.frmmausac f = new Forms.frmmausac();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }
    }
}
