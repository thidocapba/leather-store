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
    public partial class frmque : Form
    {
        DataTable tbldd;
        public frmque()
        {
            InitializeComponent();
        }

        private void frmque_Load(object sender, EventArgs e)
        {
            txtmaque.Focus();
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT maque, tenque FROM tblque where maque = N'" + txtmaque.Text + "'";
            tbldd = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tbldd;
            DataGridView.Columns[0].HeaderText = "Mã quê";
            DataGridView.Columns[1].HeaderText = "Tên quê";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 100;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaque.Focus();
                return;
            }
            if (tbldd.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmaque.Text = DataGridView.CurrentRow.Cells["maque"].Value.ToString();
            txttenque.Text = DataGridView.CurrentRow.Cells["tenque"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtmaque.Enabled = true;
            txtmaque.Focus();
        }
        private void ResetValues()
        {
            txtmaque.Text = "";
            txttenque.Text = "";            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmaque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã quê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaque.Focus();
                return;
            }
            if (txttenque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên quê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenque.Focus();
                return;
            }
           
            sql = "SELECT maque FROM tblque WHERE maque=N'" + txtmaque.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã quê này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaque.Focus();
                txtmaque.Text = "";
                return;
            }

            sql = "INSERT INTO tblque(maque,tenque) VALUES(N'" + txtmaque.Text + "',N'" + txttenque.Text + "')";
            Functions.RunSql(sql);

            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmaque.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbldd.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaque.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên quê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenque.Focus();
                return;
            }
          
            sql = "UPDATE tblque SET tenque=N'" + txttenque.Text.ToString() + "' WHERE maque=N'" + txtmaque.Text + "'";
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
            if (txtmaque.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblque WHERE maque=N'" + txtmaque.Text + "'";
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
