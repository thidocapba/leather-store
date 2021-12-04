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
    public partial class frmchatlieu : Form
    {
        DataTable tbldd;
        public frmchatlieu()
        {
            InitializeComponent();
        }

        private void frmchatlieu_Load(object sender, EventArgs e)
        {
            
            txtmachatlieu.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT machatlieu, tenchatlieu FROM tblchatlieu";
            tbldd = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tbldd;            
            DataGridView.Columns[0].HeaderText = "Mã chất liệu";
            DataGridView.Columns[1].HeaderText = "Tên chất liệu";           
            DataGridView.Columns[0].Width = 150;
            DataGridView.Columns[1].Width = 150;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
           
            txtmachatlieu.Enabled = false;
            txttenchatlieu.Enabled = true;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmachatlieu.Focus();
                return;
            }
            if (tbldd.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            txtmachatlieu.Text = DataGridView.CurrentRow.Cells["machatlieu"].Value.ToString();
            txttenchatlieu.Text = DataGridView.CurrentRow.Cells["tenchatlieu"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtmachatlieu.Focus();
        }
        private void ResetValues()
        {
           
            txttenchatlieu.Enabled = true;          
            txtmachatlieu.Enabled = true;
            txtmachatlieu.Text = "";
            txttenchatlieu.Text = "";

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;

            if (txtmachatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmachatlieu.Focus();
                return;
            }
            if (txttenchatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenchatlieu.Focus();
                return;
            }

            sql = "SELECT machatlieu FROM tblchatlieu WHERE machatlieu=N'" + txtmachatlieu.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmachatlieu.Focus();
                txtmachatlieu.Text = "";
                return;
            }

            
            sql = "INSERT INTO tblchatlieu(machatlieu,tenchatlieu) VALUES(N'" + txtmachatlieu.Text + "',N'" + txttenchatlieu.Text + "')";
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
            if (txtmachatlieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenchatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenchatlieu.Focus();
                return;
            }
            

            sql = "UPDATE tblchatlieu SET tenchatlieu=N'" + txttenchatlieu.Text.ToString() + "' WHERE machatlieu=N'" + txtmachatlieu.Text + "'";
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
            if (txtmachatlieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblchatlieu WHERE machatlieu=N'" + txtmachatlieu.Text + "'";
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
