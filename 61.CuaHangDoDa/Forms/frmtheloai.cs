using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _61.CuaHangDoDa.Class;

namespace _61.CuaHangDoDa.Forms
{
    public partial class frmtheloai : Form
    {
        DataTable tbldd;
        public frmtheloai()
        {
            InitializeComponent();
        }

        private void frmtheloai_Load(object sender, EventArgs e)
        {
            txtmaloai.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT maloai, tenloai FROM tbltheloai";
            tbldd = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tbldd;
            DataGridView.Columns[0].HeaderText = "Mã loại";
            DataGridView.Columns[1].HeaderText = "Tên loại";            
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 80;            
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            txtmaloai.Enabled = false;
            txttenloai.Enabled = true;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaloai.Focus();
                return;
            }
            if (tbldd.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            
            txtmaloai.Text = DataGridView.CurrentRow.Cells["maloai"].Value.ToString();
            txttenloai.Text = DataGridView.CurrentRow.Cells["tenloai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {            
            groupBox1.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtmaloai.Focus();
        }
        private void ResetValues()
        {
           
            txttenloai.Enabled = true;           
            txtmaloai.Enabled = true;            
            txtmaloai.Text = "";
            txttenloai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            
            if (txtmaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaloai.Focus();
                return;
            }
            if (txttenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenloai.Focus();
                return;
            }
            
            sql = "SELECT maloai FROM tbltheloai WHERE maloai=N'" + txtmaloai.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaloai.Focus();
                txtmaloai.Text = "";
                return;
            }

            sql = "INSERT INTO tbltheloai(maloai,tenloai) VALUES(N'" + txtmaloai.Text + "',N'" + txttenloai.Text + "')";
            Functions.RunSql(sql);          
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbldd.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (txttenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenloai.Focus();
                return;
            }

            sql = "UPDATE tbltheloai SET tenloai=N'" + txttenloai.Text.ToString() + "' WHERE maloai=N'" + txtmaloai.Text + "'";
            Functions.RunSql(sql);
           
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbldd.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                
                sql = "DELETE tbltheloai WHERE maloai=N'" + txtmaloai.Text + "'";
                Functions.RunSqlDel(sql);               
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
