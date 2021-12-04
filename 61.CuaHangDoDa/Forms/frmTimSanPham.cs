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
    public partial class frmTimSanPham : Form
    {
        public frmTimSanPham()
        {
            InitializeComponent();
        }

        DataTable tblTSP;

        private void frmTimSanPham_Load(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT maloai, tenloai FROM tbltheloai", cboMaloai, "maloai", "maloai");
            cboMaloai.SelectedIndex = -1;
            Functions.FillCombo("SELECT machatlieu, tenchatlieu FROM tblchatlieu", cboMachatlieu, "machatlieu", "machatlieu");
            cboMachatlieu.SelectedIndex = -1;
            ResetValues();
            dtgvTimsp.DataSource = null;
            btnTimlai.Enabled = false;
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
            {
                if (Ctl is TextBox)
                    Ctl.Text = "";

            }
            txtSoluong.Text = "";
            cboMaloai.Text = "";
            cboMachatlieu.Text = "";
            cboMaloai.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cboMaloai.Text == "") && (cboMachatlieu.Text == "") && (txtSoluong.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "select * from tblsanpham where 1=1";
            if (cboMaloai.Text != "")
                sql = sql + " and maloai like N'%" + cboMaloai.Text + "%'";
            if (cboMachatlieu.Text != "")
                sql = sql + " and machatlieu like N'%" + cboMachatlieu.Text + "%'";
            if (txtSoluong.Text != "")
                sql = sql + " and soluong = " + txtSoluong.Text + "";
            tblTSP = Class.Functions.GetDataToTable(sql);
            if (tblTSP.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblTSP.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtgvTimsp.DataSource = tblTSP;
            Load_DataGridView();
            groupBox1.Enabled = false;
            btnTimkiem.Enabled = false;
            btnTimlai.Enabled = true;
        }

        private void Load_DataGridView()
        {
            dtgvTimsp.Columns[0].HeaderText = "Mã sản phẩm";
            dtgvTimsp.Columns[1].HeaderText = "Tên sản phẩm";
            dtgvTimsp.Columns[2].HeaderText = "Mã loại";
            dtgvTimsp.Columns[3].HeaderText = "Mã nước";
            dtgvTimsp.Columns[4].HeaderText = "Mã chất liệu";
            dtgvTimsp.Columns[5].HeaderText = "Giá nhập";
            dtgvTimsp.Columns[6].HeaderText = "Giá bán";
            dtgvTimsp.Columns[7].HeaderText = "Số lượng";
            dtgvTimsp.Columns[8].HeaderText = "Mã màu";
            dtgvTimsp.Columns[9].HeaderText = "Hình ảnh";
            dtgvTimsp.Columns[0].Width = 150;
            dtgvTimsp.Columns[1].Width = 100;
            dtgvTimsp.Columns[2].Width = 80;
            dtgvTimsp.Columns[3].Width = 80;
            dtgvTimsp.Columns[4].Width = 100;
            dtgvTimsp.Columns[5].Width = 100;
            dtgvTimsp.Columns[6].Width = 100;
            dtgvTimsp.Columns[7].Width = 100;
            dtgvTimsp.Columns[8].Width = 100;
            dtgvTimsp.Columns[9].Width = 100;
            dtgvTimsp.AllowUserToAddRows = false;
            dtgvTimsp.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvTimsp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string masp;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                masp = dtgvTimsp.CurrentRow.Cells["masanpham"].Value.ToString();
                frmDMSanpham frm = new frmDMSanpham();
                frm.txtMasanpham.Text = masp;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            groupBox1.Enabled = true;
            btnTimlai.Enabled = false;
            btnTimkiem.Enabled = true;
            dtgvTimsp.DataSource = null;
        }
    }
}
