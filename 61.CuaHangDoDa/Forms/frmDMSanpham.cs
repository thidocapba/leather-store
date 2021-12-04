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


namespace _61.CuaHangDoDa.Forms
{
    public partial class frmDMSanpham : Form
    {
        public frmDMSanpham()
        {
            InitializeComponent();
        }

        DataTable tblsp;

        private void frmDMSanpham_Load(object sender, EventArgs e)
        {
            txtMasanpham.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Class.Functions.FillCombo("SELECT maloai, tenloai FROM tbltheloai",cboMaloai, "maloai", "tenloai");
            cboMaloai.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT manuoc, tennuoc FROM tblnuocnhasanxuat",cboManuoc, "manuoc", "tennuoc");
            cboManuoc.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT machatlieu, tenchatlieu FROM tblchatlieu",cboMachatlieu, "machatlieu", "tenchatlieu");
            cboMachatlieu.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT mamau, tenmau FROM tblmausac",cboMamau, "mamau", "tenmau");
            cboMamau.SelectedIndex = -1;

            //Hiển thị thông tin của một sản phẩm được gọi từ form tìm kiếm
            if (txtMasanpham.Text != "")
            {
                btnXoa.Enabled = true;
                Load_DataGridView();
            }
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT masanpham, tensanpham, gianhap, giaban, soluong, hinhanh, maloai, manuoc, machatlieu, mamau FROM tblsanpham where masanpham = N'" + txtMasanpham.Text + "'";
            tblsp = Class.Functions.GetDataToTable(sql);
            dtgvsp.DataSource = tblsp;
            dtgvsp.Columns[0].HeaderText = "Mã sản phẩm";
            dtgvsp.Columns[1].HeaderText = "Tên sản phẩm";
            dtgvsp.Columns[2].HeaderText = "Giá nhập";
            dtgvsp.Columns[3].HeaderText = "Giá bán";
            dtgvsp.Columns[4].HeaderText = "Số lượng";
            dtgvsp.Columns[5].HeaderText = "Hình ảnh";
            dtgvsp.Columns[6].HeaderText = "Mã loại";
            dtgvsp.Columns[7].HeaderText = "Mã nước";
            dtgvsp.Columns[8].HeaderText = "Mã chất liệu";
            dtgvsp.Columns[9].HeaderText = "Mã màu";
            dtgvsp.Columns[0].Width = 80;
            dtgvsp.Columns[1].Width = 100;
            dtgvsp.Columns[2].Width = 80;
            dtgvsp.Columns[3].Width = 80;
            dtgvsp.Columns[4].Width = 80;
            dtgvsp.Columns[5].Width = 200;
            dtgvsp.Columns[6].Width = 80;
            dtgvsp.Columns[7].Width = 80;
            dtgvsp.Columns[8].Width = 80;
            dtgvsp.Columns[9].Width = 80;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dtgvsp.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dtgvsp.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMasanpham.Text = "";
            cboMaloai.Text = "";
            cboManuoc.Text = "";
            cboMachatlieu.Text = "";
            cboMamau.Text = "";
            txtTensanpham.Text = "";
            txtGianhap.Text = "";
            txtGiaban.Text = "";
            txtSoluong.Text = "";
            txtHinhanh.Text = "";
            picAnh.Image = null;

        }

        private void dtgvsp_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMasanpham.Focus();
                return;
            }
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            txtMasanpham.Text = dtgvsp.CurrentRow.Cells["masanpham"].Value.ToString();
            ma = dtgvsp.CurrentRow.Cells["maloai"].Value.ToString();
            cboMaloai.Text = Class.Functions.GetFieldValues("select tenloai from tbltheloai where maloai = N'" + ma + "'");
            ma = dtgvsp.CurrentRow.Cells["manuoc"].Value.ToString();
            cboManuoc.Text = Class.Functions.GetFieldValues("select tennuoc from tblnuocnhasanxuat where manuoc = N'" + ma + "'");
            ma = dtgvsp.CurrentRow.Cells["machatlieu"].Value.ToString();
            cboMachatlieu.Text = Class.Functions.GetFieldValues("select tenchatlieu from tblchatlieu where machatlieu = N'" + ma + "'");
            ma = dtgvsp.CurrentRow.Cells["mamau"].Value.ToString();
            cboMamau.Text = Class.Functions.GetFieldValues("select tenmau from tblmausac where mamau = N'" + ma + "'");
            txtTensanpham.Text = dtgvsp.CurrentRow.Cells["tensanpham"].Value.ToString();
            txtGianhap.Text = dtgvsp.CurrentRow.Cells["gianhap"].Value.ToString();
            txtGiaban.Text = dtgvsp.CurrentRow.Cells["giaban"].Value.ToString();
            txtSoluong.Text = dtgvsp.CurrentRow.Cells["soluong"].Value.ToString();
            txtHinhanh.Text = Class.Functions.GetFieldValues("SELECT hinhanh FROM tblsanpham WHERE masanpham = N'" + txtMasanpham.Text + "'");
            //picAnh.Image = Image.FromFile(txtHinhanh.Text);

            if (txtHinhanh.Text != "")
            {
                picAnh.Visible = true;
                picAnh.Image = Image.FromFile(txtHinhanh.Text);
            }
            else
            {
                picAnh.Visible = false;
            }
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
            txtMasanpham.Enabled = true;
            txtMasanpham.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMasanpham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtMasanpham.Focus();
                return;
            }
            if (cboMaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaloai.Focus();
                return;
            }
            if (cboManuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nước", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboManuoc.Focus();
                return;
            }
            if (cboMachatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMachatlieu.Focus();
                return;
            }
            if (cboMamau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMamau.Focus();
                return;
            }
            if (txtTensanpham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtTensanpham.Focus();
                return;
            }
            if (txtHinhanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho sản phẩm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHinhanh.Focus();
                return;
            }
            if (txtGianhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá nhập cho sản phẩm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGianhap.Focus();
                return;
            }
            if (txtGiaban.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá bán cho sản phẩm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaban.Focus();
                return;
            }
            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng cho sản phẩm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            sql = "SELECT masanpham FROM tblsanpham WHERE masanpham = N'" + txtMasanpham.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasanpham.Focus();
                txtMasanpham.Text = "";
                return;
            }
            sql = "INSERT INTO tblsanpham VALUES(N'" + txtMasanpham.Text.Trim() + "', N'" + txtTensanpham.Text.Trim() + "',N'" + cboMaloai.SelectedValue + "',N'" + cboManuoc.SelectedValue + "',N'" + cboMachatlieu.SelectedValue + "', " + txtGianhap.Text.Trim() + ", " + txtGiaban.Text.Trim() + ", " + txtSoluong.Text.Trim() + ",N'" + cboMamau.SelectedValue + "', '" + txtHinhanh.Text + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMasanpham.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = @"D:\picture123";
            dlgOpen.FilterIndex = 4;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtHinhanh.Text = dlgOpen.FileName;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtMasanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboMaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaloai.Focus();
                return;
            }
            if (cboManuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nước", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboManuoc.Focus();
                return;
            }
            if (cboMachatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMachatlieu.Focus();
                return;
            }
            if (cboMamau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMamau.Focus();
                return;
            }
            if (txtTensanpham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtTensanpham.Focus();
                return;
            }
            if (txtHinhanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho sản phẩm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHinhanh.Focus();
                return;
            }
            if (txtGianhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá nhập cho sản phẩm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGianhap.Focus();
                return;
            }
            if (txtGiaban.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá bán cho sản phẩm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaban.Focus();
                return;
            }
            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng cho sản phẩm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            sql = "UPDATE tblsanpham SET  tensanpham=N'" + txtTensanpham.Text.Trim().ToString() + "', maloai = N'" + cboMaloai.SelectedValue.ToString() + "', manuoc = N'" + cboManuoc.SelectedValue.ToString() + "', machatlieu = N'" + cboMachatlieu.SelectedValue.ToString() + "', mamau = N'" + cboMamau.SelectedValue.ToString() + "', hinhanh = '" + txtHinhanh.Text + "', gianhap = N'" + txtGianhap.Text + "', giaban = N'" + txtGiaban.Text + "', soluong = N'" + txtSoluong.Text + "' WHERE masanpham = N'" + txtMasanpham.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMasanpham.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtMasanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblsanpham WHERE masanpham = N'" + txtMasanpham.Text + "'";
                Class.Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtGiaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}

