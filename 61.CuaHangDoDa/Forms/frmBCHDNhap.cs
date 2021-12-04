using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace _61.CuaHangDoDa.Forms
{
    public partial class frmBCHDNhap : Form
    {
        public frmBCHDNhap()
        {
            InitializeComponent();
        }

        DataTable tblhdn;


        private void frm_7_Load(object sender, EventArgs e)
        {
            //Class.Functions.Connect();
            txttongtien.Enabled = false;
            btntimlai.Enabled = false;
            btnin.Enabled = false;
            txttongtien.Text = "0";
            ResetValues();
            dghoadonnhap.DataSource = null;
            Class.Functions.FillCombo("SELECT manhacungcap, tennhacungcap FROM tblnhacungcap", cbonhacc, "manhacungcap", "tennhacungcap");
            cbonhacc.SelectedIndex = -1;
            Load_dghoadonnhap();

        }
        private void ResetValues()
        {
            txttongtien.Text = "";
            cbonhacc.Text = "";
            Load_dghoadonnhap();
            lbbangchu.Text = "Bằng Chữ : ";
        }

        private void Load_dghoadonnhap()
        {
            string sql;
            sql = "SELECT mahoadonnhap, ngaynhap, manhanvien, manhacungcap, tongtien FROM tblhoadonnhap";
            tblhdn = Class.Functions.GetDataToTable(sql);
            dghoadonnhap.DataSource = tblhdn;
            dghoadonnhap.Columns[0].HeaderText = "Mã Hóa Đơn";
            dghoadonnhap.Columns[1].HeaderText = "Ngày Nhập";
            dghoadonnhap.Columns[2].HeaderText = "Mã Nhân Viên";
            dghoadonnhap.Columns[3].HeaderText = "Mã Nhà Cung Cấp";
            dghoadonnhap.Columns[4].HeaderText = "Thành Tiền";
            dghoadonnhap.Columns[0].Width = 150;
            dghoadonnhap.Columns[1].Width = 100;
            dghoadonnhap.Columns[2].Width = 100;
            dghoadonnhap.Columns[3].Width = 150;
            dghoadonnhap.Columns[4].Width = 100;
            dghoadonnhap.AllowUserToAddRows = false;
            dghoadonnhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            double tongtien;
            if (cbonhacc.Text == "")
            {
                MessageBox.Show("Hãy Chọn Nhà Cung Cấp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbonhacc.Focus();
                return;
            }
            sql = " Select * from  tblhoadonnhap WHERE 1=1";

            //sql = "SELECT ngayban FROM tblhoadonnhap WHERE manhacungcap = SELECT manhacungcap FROM tblnhacungcap WHERE tennhacungcap= N'" + cbonhacc.Text + "' ";
            if (cbonhacc.Text != "")

                sql = sql + "AND manhacungcap = '" + cbonhacc.SelectedValue + "'";

            tblhdn = Class.Functions.GetDataToTable(sql);
            if (tblhdn.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
            {
                MessageBox.Show("Có " + tblhdn.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dghoadonnhap.DataSource = tblhdn;

                tongtien = Convert.ToDouble(Class.Functions.GetFieldValues("SELECT SUM(tongtien) FROM tblhoadonnhap WHERE manhacungcap= '" + cbonhacc.SelectedValue + "'"));
                txttongtien.Text = tongtien.ToString();
                btndong.Enabled = true;
                btnin.Enabled = true;
                lbbangchu.Text = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(txttongtien.Text);
            }
            //Load_dghoadonnhap();
            btndong.Enabled = true;
            btnin.Enabled = true;
            btntimlai.Enabled = true;
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinNCC;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng bán đồ da MIS";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (08)9999-9999";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;

            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";
            // Biểu diễn thông tin chung của hóa đơn bán

            sql = "SELECT manhacungcap, tennhacungcap, diachi, sodienthoai FROM tblnhacungcap  WHERE manhacungcap =N'" + cbonhacc.SelectedValue + "'";
            tblThongtinNCC = Class.Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "MÃ NHÀ CUNG CÂP:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinNCC.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "TÊN NHÀ CUNG CÂP:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinNCC.Rows[0][1].ToString();
            exRange.Range["B8:B8"].Value = "ĐỊA CHỈ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinNCC.Rows[0][2].ToString();
            exRange.Range["B9:B9"].Value = "ĐIỆN THOẠI:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinNCC.Rows[0][3].ToString();

            //Lấy thông tin hóa đơn
            sql = "SELECT  mahoadonnhap,ngaynhap,manhanvien,manhacungcap,tongtien FROM tblhoadonnhap  WHERE manhacungcap =N'" + cbonhacc.SelectedValue + "'";
            tblThongtinHD = Class.Functions.GetDataToTable(sql);
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "MÃ HÓA ĐƠN";
            exRange.Range["C11:C11"].Value = "NGÀY NHẬP";
            exRange.Range["D11:D11"].Value = "MÃ NHÂN VIÊN";
            exRange.Range["E11:E11"].Value = "MÃ NHÀ CUNG CÂP";
            exRange.Range["F11:F11"].Value = "THÀNH TIỀN"; for (hang = 0; hang <= tblThongtinHD.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHD.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHD.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = txttongtien.Text;
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 


            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            // COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(txttongtien.Text);


            exRange = exSheet.Cells[4][hang + 19]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            exSheet.Name = "Hóa đơn nhập";

            exApp.Visible = true;


        }

        private void btntimlai_Click(object sender, EventArgs e)
        {
            ResetValues();


        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dghoadonnhap_DoubleClick(object sender, EventArgs e)
        {

            string mahdnhap;


            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahdnhap = dghoadonnhap.CurrentRow.Cells["mahoadonnhap"].Value.ToString();




                frmhdnhap frm = new frmhdnhap();
                frm.txtmahdnhap.Text = mahdnhap;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

            }

        }
    }
}
