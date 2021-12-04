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
    public partial class frmDMNhacungcap : Form
    {
        public frmDMNhacungcap()
        {
            InitializeComponent();
        }
        DataTable tblNCC;
        private void frmDMNhacungcap_Load(object sender, EventArgs e)
        {
            txtManhacungcap.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            ResetValues();
        }

        private void ResetValues()
        {
            txtManhacungcap.Text = "";
            txtDiachi.Text = "";
            txtTennhacungcap.Text = "";
            mskDienthoai.Text = "";
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT manhacungcap, tennhacungcap, diachi, sodienthoai FROM tblnhacungcap";
            tblNCC = Functions.GetDataToTable(sql);
            dtgvDMNCC.DataSource = tblNCC;
            dtgvDMNCC.Columns[0].HeaderText = "Mã nhà cung cấp";
            dtgvDMNCC.Columns[1].HeaderText = "Tên nhà cung cấp";
            dtgvDMNCC.Columns[2].HeaderText = "Địa chỉ";
            dtgvDMNCC.Columns[3].HeaderText = "Số điện thoại";
            dtgvDMNCC.Columns[0].Width = 100;
            dtgvDMNCC.Columns[1].Width = 120;
            dtgvDMNCC.Columns[2].Width = 120;
            dtgvDMNCC.Columns[3].Width = 110;
            dtgvDMNCC.AllowUserToAddRows = false;
            dtgvDMNCC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

       
       

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtManhacungcap.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtManhacungcap.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblnhacungcap WHERE Manhacungcap=N'" + txtManhacungcap.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtManhacungcap.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTennhacungcap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhacungcap.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            sql = "UPDATE tblnhacungcap SET  Tennhacungcap=N'" + txtTennhacungcap.Text.Trim().ToString()
                  + "', Diachi=N'" + txtDiachi.Text.Trim().ToString() + "', sodienthoai='" +
                mskDienthoai.Text.ToString() + "' WHERE Manhacungcap = N'" + txtManhacungcap.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtManhacungcap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtManhacungcap.Focus();
                return;
            }
            if (txtTennhacungcap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhacungcap.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            sql = "SELECT Manhacungcap FROM tblnhacungcap WHERE manhacungcap =N'" + txtManhacungcap.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã có, bạn phải nhập mã khác", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhacungcap.Focus();
                txtManhacungcap.Text = "";
                return;
            }
            sql = "INSERT INTO tblnhacungcap VALUES (N'" +txtManhacungcap.Text.Trim() + "',N'" + txtTennhacungcap.Text.Trim() + "',N'" +txtDiachi.Text.Trim() + "','" + mskDienthoai.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtManhacungcap.Enabled = false;
        
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtManhacungcap.Enabled = true;
            txtManhacungcap.Focus();
        }

        private void dtgvDMNCC_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManhacungcap.Focus();
                return;
            }
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            txtManhacungcap.Text = dtgvDMNCC.CurrentRow.Cells["manhacungcap"].Value.ToString();
            txtTennhacungcap.Text = dtgvDMNCC.CurrentRow.Cells["tennhacungcap"].Value.ToString();
            txtDiachi.Text = dtgvDMNCC.CurrentRow.Cells["diachi"].Value.ToString();
            mskDienthoai.Text = dtgvDMNCC.CurrentRow.Cells["sodienthoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }
    }
}
