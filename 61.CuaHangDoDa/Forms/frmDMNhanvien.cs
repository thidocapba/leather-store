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
    public partial class frmDMNhanvien : Form
    {
        public frmDMNhanvien()
        {
            InitializeComponent();
        }
        DataTable tblNV;
        private void frmDMNhanvien_Load(object sender, EventArgs e)
        {
            txtManhanvien.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            txttenque.Enabled = false;
            Functions.FillCombo("SELECT maque FROM tblque", cbomaque, "maque", "maque");
            cbomaque.SelectedIndex = -1;
            Load_DataGridView();            
            ResetValues();
        }

        private void ResetValues()
        {
            txtManhanvien.Text = "";
            txtTennhanvien.Text = "";
            cbomaque.Text = "";
            txtDiachi.Text = "";
            chkGioitinh.Checked = false;
            txtNgaysinh.Text = "";
            masksodienthoai.Text = "";
        }


        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT a.manhanvien, a.tennhanvien, a.diachi, a.gioitinh, a.ngaysinh, a.maque, b.tenque, a.sodienthoai FROM tblnhanvien AS a JOIN tblque AS b ON a.maque = b.maque";
            tblNV = Functions.GetDataToTable(sql);
            dtgvDMNV.DataSource = tblNV;
            dtgvDMNV.Columns[0].HeaderText = "Mã nhân viên";
            dtgvDMNV.Columns[1].HeaderText = "Tên nhân viên";
            dtgvDMNV.Columns[2].HeaderText = "Địa chỉ";
            dtgvDMNV.Columns[3].HeaderText = "Giới tính"; 
            dtgvDMNV.Columns[4].HeaderText = "Ngày sinh";
            dtgvDMNV.Columns[5].HeaderText = "Mã quê";
            dtgvDMNV.Columns[6].HeaderText = "Tên quê";
            dtgvDMNV.Columns[7].HeaderText = "Số điện thoại";
            dtgvDMNV.Columns[0].Width = 100;
            dtgvDMNV.Columns[1].Width = 150;
            dtgvDMNV.Columns[2].Width = 100;
            dtgvDMNV.Columns[3].Width = 150;
            dtgvDMNV.Columns[4].Width = 100;
            dtgvDMNV.Columns[5].Width = 100;
            dtgvDMNV.Columns[6].Width = 100;
            dtgvDMNV.Columns[7].Width = 100;
            dtgvDMNV.AllowUserToAddRows = false;
            dtgvDMNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dtgvDMNV_Click(object sender, EventArgs e)
        {
          
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManhanvien.Focus();
                return;
            }
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            txtManhanvien.Text = dtgvDMNV.CurrentRow.Cells["manhanvien"].Value.ToString();
            txtTennhanvien.Text = dtgvDMNV.CurrentRow.Cells["tennhanvien"].Value.ToString();
            txtDiachi.Text = dtgvDMNV.CurrentRow.Cells["diachi"].Value.ToString();
            string ma;
            ma = dtgvDMNV.CurrentRow.Cells["maque"].Value.ToString();
            cbomaque.Text = Functions.GetFieldValues("SELECT maque FROM tblque WHERE maque = N'" + ma + "'");

            txttenque.Text = dtgvDMNV.CurrentRow.Cells["tenque"].Value.ToString();
          
            if (dtgvDMNV.CurrentRow.Cells["gioitinh"].Value.ToString() == "Nam")
                chkGioitinh.Checked = true;
            else
                chkGioitinh.Checked = false;            
            txtNgaysinh.Text = dtgvDMNV.CurrentRow.Cells["ngaysinh"].Value.ToString();
            masksodienthoai.Text = dtgvDMNV.CurrentRow.Cells["sodienthoai"].Value.ToString();
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
            txtManhanvien.Enabled = true;
            txtManhanvien.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtManhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                return;
            }
            if (txtTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            if (txtNgaysinh.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaysinh.Focus();
                return;
            }
            if (!Functions.IsDate(txtNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaysinh.Text = "";
                txtNgaysinh.Focus();
                return;
            }
            if (cbomaque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã quê", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomaque.Focus();
                return;
            }
            
            if (masksodienthoai.Text == "(   )   ")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                masksodienthoai.Focus();
                return;
            }

            sql = "SELECT manhanvien FROM tblnhanvien WHERE manhanvien=N'" + txtManhanvien.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                txtManhanvien.Focus();
                txtManhanvien.Text = "";
                return;
            }
            sql = "INSERT INTO tblnhanvien VALUES(N'" + txtManhanvien.Text.Trim() + "', N'" + txtTennhanvien.Text.Trim() + "', N'" + txtDiachi.Text.Trim() + "', N'" + gt + "', '" + Functions.ConvertDateTime(txtNgaysinh.Text.Trim()) + "', N'" + cbomaque.Text + "', N'"+ masksodienthoai.Text +"')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtManhanvien.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtManhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            if (txtNgaysinh.Text == "  /   /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaysinh.Focus();
                return;
            }
            string s;
            s = txtNgaysinh.Text.Substring(0, 10).Trim();
            if (!Functions.IsDate(s))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaysinh.Text = "";
                txtNgaysinh.Focus();
                return;
            }
            if (cbomaque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã quê", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomaque.Focus();
                return;
            }
            if (masksodienthoai.Text == "(   )   ")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                masksodienthoai.Focus();
                return;
            }
            sql = "UPDATE tblnhanvien SET tennhanvien=N'" + txtTennhanvien.Text.Trim().ToString() + "', diachi=N'" + txtDiachi.Text.Trim().ToString() + "', gioitinh=N'" + gt + "', ngaysinh=N'" + Functions.ConvertDateTime(txtNgaysinh.Text) + "', maque = N'" + cbomaque.Text + "', sodienthoai =  N'"+ masksodienthoai.Text +"' WHERE manhanvien=N'" + txtManhanvien.Text + "'";
            //MessageBox.Show(sql);
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtManhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblnhanvien WHERE manhanvien=N'" + txtManhanvien.Text + "'";
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
            txtManhanvien.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbomaque_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomaque.Text == "")
                txttenque.Text = "";
            // Khi kich chon Ma quê thi ten quê se tu dong hien ra
            str = "Select tenque from tblque where maque =N'" + cbomaque.SelectedValue + "'";
            txttenque.Text = Functions.GetFieldValues(str);
        }
    }
}
