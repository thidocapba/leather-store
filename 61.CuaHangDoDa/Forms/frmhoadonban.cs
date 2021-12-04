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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace _61.CuaHangDoDa.Forms
{
    public partial class frmhoadonban : Form
    {
        public frmhoadonban()
        {
            InitializeComponent();
        }
        DataTable tblCTHDB;
        private void frmhoadonban_Load(object sender, EventArgs e)
        {
            btnthemmoi.Enabled = true;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            txtmahoadonban.ReadOnly = true;
            txttennhanvien.ReadOnly = true;
            txtdiachikhachhang.ReadOnly = true;
            txttensanpham.ReadOnly = true;
            txtgiaban.ReadOnly = true;
            txtthanhtien.ReadOnly = true;
            txttongtien.ReadOnly = true;
            txtkhuyenmai.Text = "0";
            txttongtien.Text = "0";
            Functions.FillCombo("SELECT makhachhang FROM tblkhachhang", cbomakhachhang, "makhachhang", "makhachhang");
            cbomakhachhang.SelectedIndex = -1;
            Functions.FillCombo("SELECT manhanvien FROM tblnhanvien", cbomanhanvien, "manhanvien", "manhanvien");
            cbomanhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT masanpham, tensanpham FROM tblsanpham", cbomasanpham, "masanpham", "masanpham");
            cbomasanpham.SelectedIndex = -1;
            Functions.FillCombo("SELECT mahoadonban FROM tblchitiethoadonban", cbomahoadonban, "mahoadonban", "mahoadonban");
            cbomahoadonban.SelectedIndex = -1;
            if (txtmahoadonban.Text != "")
            {
                Load_ThongtinHD();
                btnhuy.Enabled = true;
            }
            Load_DataGridViewChitiet();
        }
        
        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "SELECT b.masanpham, b.tensanpham, a.soluong, b.giaban, a.khuyenmai, a.thanhtien FROM tblchitiethoadonban AS a JOIN tblsanpham AS b ON a.masanpham=b.masanpham WHERE a.mahoadonban = N'" + txtmahoadonban.Text + "'";
            tblCTHDB = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblCTHDB;
            DataGridView.Columns[0].HeaderText = "Mã sản phẩm";
            DataGridView.Columns[1].HeaderText = "Tên sản phẩm";
            DataGridView.Columns[2].HeaderText = "Số lượng";
            DataGridView.Columns[3].HeaderText = "Giá bán";
            DataGridView.Columns[4].HeaderText = "Khuyến mại";
            DataGridView.Columns[5].HeaderText = "Thành tiền";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[3].Width = 100;
            DataGridView.Columns[4].Width = 100;
            DataGridView.Columns[5].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT ngayban FROM tblhoadonban WHERE mahoadonban = N'" + txtmahoadonban.Text + "'";
            txtngayban.Text = Functions.GetFieldValues(str);
            str = "SELECT manhanvien FROM tblhoadonban WHERE mahoadonban = N'" + txtmahoadonban.Text + "'";
            cbomanhanvien.Text = Functions.GetFieldValues(str);

            str = "SELECT makhachhang FROM tblhoadonban WHERE mahoadonban = N'" + txtmahoadonban.Text + "'";
            cbomakhachhang.Text = Functions.GetFieldValues(str);

            str = "SELECT tongtien FROM tblhoadonban WHERE mahoadonban = N'" + txtmahoadonban.Text + "'";
            txttongtien.Text = Functions.GetFieldValues(str);


            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txttongtien.Text);
        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            groupIn4.Enabled = true;
            btnboqua.Enabled = true;
            cbomasanpham.Enabled = true;
            cbomakhachhang.Enabled = true;
            btnhuy.Enabled = false;
            btnluu.Enabled = true;
            btnthemmoi.Enabled = false;
            ResetValues();
            txtmahoadonban.Text = Functions.CreateKey("HDB"); //có tác dụng sinh khóa tự động cho Mã hóa đơn bán.
            Load_DataGridViewChitiet();
        }
        private void ResetValues()
        {
            txtmahoadonban.Text = "";
            txtngayban.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cbomanhanvien.Text = "";
            cbomakhachhang.Text = "";
            txttongtien.Text = "0";
            lblbangchu.Text = "Bằng chữ: ";
            cbomasanpham.Text = "";
            txtsoluong.Text = "";
            txtkhuyenmai.Text = "0";
            txtthanhtien.Text = "0";
            txttennhanvien.Text = "";
            txttensanpham.Text = "";
            txtgiaban.Text = "";
            txtdiachikhachhang.Text = "";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT mahoadonban FROM tblhoadonban WHERE mahoadonban=N'" + txtmahoadonban.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtngayban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtngayban.Focus();
                    return;
                }
                if (cbomanhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomanhanvien.Focus();
                    return;
                }
                if (cbomakhachhang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomakhachhang.Focus();
                    return;
                }
                sql = "INSERT INTO tblhoadonban(mahoadonban, ngayban, manhanvien, makhachhang, tongtien) " +
                    "VALUES(N'" + txtmahoadonban.Text.Trim() + "', '" +
                        Functions.ConvertDateTime(txtngayban.Text.Trim()) + "',N'" + cbomanhanvien.SelectedValue + "',N'" +
                        cbomakhachhang.SelectedValue + "'," + txttongtien.Text + ")";
                Functions.RunSql(sql);
            }

            // Lưu thông tin của các mặt hàng
            if (cbomasanpham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomasanpham.Focus();
                return;
            }
            if ((txtsoluong.Text.Trim().Length == 0) || (txtsoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            if (txtkhuyenmai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtkhuyenmai.Focus();
                return;
            }
            sql = "SELECT masanpham FROM tblchitiethoadonban WHERE masanpham=N'" + cbomasanpham.SelectedValue + "' AND mahoadonban = N'" + txtmahoadonban.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cbomasanpham.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT soluong FROM tblsanpham WHERE masanpham = N'" + cbomasanpham.SelectedValue + "'"));
            if (Convert.ToDouble(txtsoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            sql = "INSERT INTO tblchitiethoadonban(mahoadonban,masanpham, soluong, khuyenmai, thanhtien) VALUES(N'" + txtmahoadonban.Text.Trim() + "', N'" + cbomasanpham.SelectedValue + "'," + txtsoluong.Text + "," + txtkhuyenmai.Text + "," + txtthanhtien.Text + ")";

            Functions.RunSql(sql);
            Load_DataGridViewChitiet();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblsanpham
            SLcon = sl - Convert.ToDouble(txtsoluong.Text);
            sql = "UPDATE tblsanpham SET soluong =" + SLcon + " WHERE masanpham= N'" + cbomasanpham.SelectedValue + "'";
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán

            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT tongtien FROM tblhoadonban WHERE mahoadonban = N'" + txtmahoadonban.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtthanhtien.Text);
            sql = "UPDATE tblhoadonban SET tongtien =" + Tongmoi + " WHERE mahoadonban = N'" + txtmahoadonban.Text + "'";
            Functions.RunSql(sql);
            txttongtien.Text = Tongmoi.ToString();
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
            ResetValuesHang();
            btnhuy.Enabled = true;
            btnthemmoi.Enabled = true;
            groupIn4.Enabled = false;
        }
        private void ResetValuesHang()
        {
            cbomasanpham.Text = "";
            txtsoluong.Text = "";
            txtkhuyenmai.Text = "0";
            txtthanhtien.Text = "0";
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double Thanhtien;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahang = DataGridView.CurrentRow.Cells["masanpham"].Value.ToString();
                DelHang(txtmahoadonban.Text, mahang);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                Thanhtien = Convert.ToDouble(DataGridView.CurrentRow.Cells["thanhtien"].Value.ToString());
                DelUpdateTongtien(txtmahoadonban.Text, Thanhtien);
                Load_DataGridViewChitiet();
            }
        }
        private void DelHang(string Mahoadon, string Mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT soluong FROM tblchitiethoadonban WHERE mahoadonban = N'" + Mahoadon + "' AND masanpham = N'" + Mahang + "'";
            s = Convert.ToDouble(Functions.GetFieldValues(sql));
            sql = "DELETE tblchitiethoadonban WHERE mahoadonban =N'" + Mahoadon + "' AND masanpham = N'" + Mahang + "'";
            Functions.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT soluong FROM tblsanpham WHERE masanpham = N'" + Mahang + "'";
            sl = Convert.ToDouble(Functions.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE tblsanpham SET soluong =" + SLcon + " WHERE masanpham= N'" + Mahang + "'";
            Functions.RunSql(sql);
        }
        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT tongtien FROM tblhoadonban WHERE mahoadonban = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblhoadonban SET tongtien =" + Tongmoi + " WHERE mahoadonban = N'" + Mahoadon + "'";
            Functions.RunSql(sql);
            txttongtien.Text = Tongmoi.ToString();
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
        }
        private void btnhuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT masanpham FROM tblchitiethoadonban WHERE mahoadonban = N'" + txtmahoadonban.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtmahoadonban.Text, Mahang[i]);
                //Xóa hóa đơn
                sql = "DELETE tblhoadonban WHERE mahoadonban =N'" + txtmahoadonban.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                Load_DataGridViewChitiet();
                btnhuy.Enabled = false;
                txttensanpham.Text = "";
                txttennhanvien.Text = "";
                txtngayban.Text = "";
                txtgiaban.Text = "";
                txtdiachikhachhang.Text = "";

            }
        }

        private void cbomanhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomanhanvien.Text == "")
                txttennhanvien.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select tennhanvien from tblnhanvien where manhanvien =N'" + cbomanhanvien.SelectedValue + "'";
            txttennhanvien.Text = Functions.GetFieldValues(str);
        }

        private void cbomakhachhang_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomakhachhang.Text == "")
            {
                txtdiachikhachhang.Text = "";
            }
            //Khi kich chon Ma khach thi  dia chi se tu dong hien ra

            str = "Select diachi from tblkhachhang where makhachhang = N'" + cbomakhachhang.SelectedValue + "'";
            txtdiachikhachhang.Text = Functions.GetFieldValues(str);

        }

        private void cbomasanpham_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomasanpham.Text == "")
            {
                txttensanpham.Text = "";
                txtgiaban.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "SELECT tensanpham FROM tblsanpham WHERE masanpham =N'" + cbomasanpham.SelectedValue + "'";
            txttensanpham.Text = Functions.GetFieldValues(str);
            str = "SELECT giaban FROM tblsanpham WHERE masanpham =N'" + cbomasanpham.SelectedValue + "'";
            txtgiaban.Text = Functions.GetFieldValues(str);
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtkhuyenmai.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtkhuyenmai.Text);
            if (txtgiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtgiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void txtkhuyenmai_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtkhuyenmai.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtkhuyenmai.Text);
            if (txtgiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtgiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void cbomahoadonban_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT mahoadonban FROM tblhoadonban", cbomahoadonban, "mahoadonban", "mahoadonban");
            cbomahoadonban.SelectedIndex = -1;
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cbomahoadonban.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomahoadonban.Focus();
                return;
            }
            txtmahoadonban.Text = cbomahoadonban.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            cbomahoadonban.SelectedIndex = -1;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmahoadonban.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bảng ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbomanhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbomasanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql;
            sql = "UPDATE tblhoadonban SET ngayban = N'" + Functions.ConvertDateTime(txtngayban.Text) + "', manhanvien = N'" + cbomanhanvien.SelectedValue.ToString() + "' WHERE mahoadonban = N'" + txtmahoadonban.Text + "'";
            Functions.RunSql(sql);
            double sl;
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT soluong FROM tblsanpham WHERE masanpham = N'" + cbomasanpham.Text + "'"));
           // MessageBox.Show(Functions.GetFieldValues("SELECT soluong FROM tblsanpham WHERE masanpham = N'" + cbomasanpham.Text + "'"));
            //xử lý lại tổng số sản phẩm (tính cả hàng có trong tblsanpham vs tblchitiethoadonban) vì sửa nên phải cộng số lượng lại để ra số lượng ban đầu
            double sl1, sl2;
            sl1 = Convert.ToDouble(Functions.GetFieldValues("SELECT soluong FROM tblchitiethoadonban WHERE masanpham = N'" + cbomasanpham.Text + "'AND mahoadonban = N'" + txtmahoadonban.Text + "'"));
          //  MessageBox.Show(Functions.GetFieldValues("SELECT soluong FROM tblchitiethoadonban WHERE masanpham = N'" + cbomasanpham.Text + "'AND mahoadonban = N'" + txtmahoadonban.Text + "'"));

            sl2 = sl1 + sl;

            if (Convert.ToDouble(txtsoluong.Text) > sl2)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }

            double SLcon;
            double slmoi;
            slmoi = Convert.ToDouble(txtsoluong.Text);
            SLcon = sl2 - slmoi;

            sql = "UPDATE tblchitiethoadonban SET masanpham = N'" + cbomasanpham.Text + "', soluong = " + Convert.ToSingle(txtsoluong.Text) + ", khuyenmai = " + Convert.ToSingle(txtkhuyenmai.Text) + ", thanhtien = " + Convert.ToSingle(txtthanhtien.Text) + " WHERE masanpham = N'" + cbomasanpham.Text + "'AND mahoadonban = N'" + txtmahoadonban.Text + "'";
            Functions.RunSql(sql);


            // Cập nhật lại số lượng của mặt hàng vào bảng tblsanpham
            sql = "UPDATE tblsanpham SET soluong =" + SLcon + " WHERE masanpham= N'" + cbomasanpham.Text + "'";
            //MessageBox.Show(SLcon.ToString());
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán            
            string thanhtien;
            thanhtien = "SELECT SUM(thanhtien) FROM tblchitiethoadonban WHERE mahoadonban = N'" + txtmahoadonban.Text + "'  GROUP BY mahoadonban";
            string tt;
            tt = Functions.GetFieldValues(thanhtien);
            sql = "UPDATE tblhoadonban SET tongtien =" + Convert.ToSingle(tt) + " WHERE mahoadonban = N'" + txtmahoadonban.Text + "'";
            Functions.RunSql(sql);
            txttongtien.Text = tt.ToString();
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(tt.ToString());
            ResetValuesHang();
            btnhuy.Enabled = true;
            btnthemmoi.Enabled = true;
            Load_DataGridViewChitiet();
            btnboqua.Enabled = true;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            cbomakhachhang.Enabled = false;
            groupIn4.Enabled = false;
            cbomasanpham.Enabled = false;
            if (btnthemmoi.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahoadonban.Focus();
                return;
            }
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string ma;
            ma = DataGridView.CurrentRow.Cells["masanpham"].Value.ToString();
            cbomasanpham.Text = Functions.GetFieldValues("SELECT masanpham FROM tblchitiethoadonban WHERE masanpham = N'" + ma + "'");
            txtsoluong.Text = DataGridView.CurrentRow.Cells["soluong"].Value.ToString();
            txtkhuyenmai.Text = DataGridView.CurrentRow.Cells["khuyenmai"].Value.ToString();
            string s = "SELECT tennhanvien FROM tblnhanvien WHERE manhanvien = N'" + cbomanhanvien.Text + "'";
            txttennhanvien.Text = Functions.GetFieldValues(s);
            btnboqua.Enabled = true;

        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnboqua.Enabled = false;
            btnthemmoi.Enabled = true;
            btnhuy.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = true;
            txtmahoadonban.Enabled = false;
            txtngayban.Text = "";
            DataGridView.DataSource = null;
        }
    }
}
