namespace _61.CuaHangDoDa.Forms
{
    partial class frmBCDoanhthu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvbcdt = new System.Windows.Forms.DataGridView();
            this.txtDoanhthu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBangchu = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHienthi = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnBatdau = new System.Windows.Forms.Button();
            this.btnTimlai = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboManhanvien = new System.Windows.Forms.ComboBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvbcdt)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(677, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO DOANH THU CỦA CỬA HÀNG THEO NHÂN VIÊN VÀ THÁNG ";
            // 
            // dtgvbcdt
            // 
            this.dtgvbcdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvbcdt.Location = new System.Drawing.Point(85, 243);
            this.dtgvbcdt.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvbcdt.Name = "dtgvbcdt";
            this.dtgvbcdt.RowHeadersWidth = 51;
            this.dtgvbcdt.Size = new System.Drawing.Size(679, 185);
            this.dtgvbcdt.TabIndex = 6;
            this.dtgvbcdt.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvbcdt_CellDoubleClick);
            // 
            // txtDoanhthu
            // 
            this.txtDoanhthu.Location = new System.Drawing.Point(164, 456);
            this.txtDoanhthu.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoanhthu.Name = "txtDoanhthu";
            this.txtDoanhthu.Size = new System.Drawing.Size(132, 22);
            this.txtDoanhthu.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 459);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Doanh thu";
            // 
            // lblBangchu
            // 
            this.lblBangchu.AutoSize = true;
            this.lblBangchu.Location = new System.Drawing.Point(341, 459);
            this.lblBangchu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBangchu.Name = "lblBangchu";
            this.lblBangchu.Size = new System.Drawing.Size(72, 17);
            this.lblBangchu.TabIndex = 13;
            this.lblBangchu.Text = "Bằng chữ:";
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::_61.CuaHangDoDa.Properties.Resources.Custom_Icon_Design_Flatastic_9_Login;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(840, 526);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(105, 53);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHienthi
            // 
            this.btnHienthi.Image = global::_61.CuaHangDoDa.Properties.Resources.Iconsmind_Outline_Monitor_Analytics;
            this.btnHienthi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHienthi.Location = new System.Drawing.Point(220, 526);
            this.btnHienthi.Margin = new System.Windows.Forms.Padding(4);
            this.btnHienthi.Name = "btnHienthi";
            this.btnHienthi.Size = new System.Drawing.Size(126, 53);
            this.btnHienthi.TabIndex = 9;
            this.btnHienthi.Text = "Hiển thị";
            this.btnHienthi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHienthi.UseVisualStyleBackColor = true;
            this.btnHienthi.Click += new System.EventHandler(this.btnHienthi_Click);
            // 
            // btnIn
            // 
            this.btnIn.Image = global::_61.CuaHangDoDa.Properties.Resources.Aha_Soft_Universal_Shop_Print;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(620, 528);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(144, 53);
            this.btnIn.TabIndex = 8;
            this.btnIn.Text = "In báo cáo";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnBatdau
            // 
            this.btnBatdau.Image = global::_61.CuaHangDoDa.Properties.Resources.Oxygen_Icons_org_Oxygen_Places_start_here;
            this.btnBatdau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBatdau.Location = new System.Drawing.Point(53, 526);
            this.btnBatdau.Margin = new System.Windows.Forms.Padding(4);
            this.btnBatdau.Name = "btnBatdau";
            this.btnBatdau.Size = new System.Drawing.Size(123, 53);
            this.btnBatdau.TabIndex = 7;
            this.btnBatdau.Text = "Bắt đầu";
            this.btnBatdau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBatdau.UseVisualStyleBackColor = true;
            this.btnBatdau.Click += new System.EventHandler(this.btnBatdau_Click);
            // 
            // btnTimlai
            // 
            this.btnTimlai.Image = global::_61.CuaHangDoDa.Properties.Resources.Ahmadhania_Spherical_Redo;
            this.btnTimlai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimlai.Location = new System.Drawing.Point(427, 527);
            this.btnTimlai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimlai.Name = "btnTimlai";
            this.btnTimlai.Size = new System.Drawing.Size(106, 55);
            this.btnTimlai.TabIndex = 15;
            this.btnTimlai.Text = "Tìm lại";
            this.btnTimlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimlai.UseVisualStyleBackColor = true;
            this.btnTimlai.Click += new System.EventHandler(this.btnTimlai_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.cboManhanvien);
            this.groupBox1.Controls.Add(this.txtThang);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(220, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 149);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // cboManhanvien
            // 
            this.cboManhanvien.FormattingEnabled = true;
            this.cboManhanvien.Location = new System.Drawing.Point(236, 37);
            this.cboManhanvien.Name = "cboManhanvien";
            this.cboManhanvien.Size = new System.Drawing.Size(159, 24);
            this.cboManhanvien.TabIndex = 18;
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(236, 93);
            this.txtThang.Margin = new System.Windows.Forms.Padding(4);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(159, 22);
            this.txtThang.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 27);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 27);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mã nhân viên";
            // 
            // frmBCDoanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(985, 644);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTimlai);
            this.Controls.Add(this.lblBangchu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDoanhthu);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHienthi);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnBatdau);
            this.Controls.Add(this.dtgvbcdt);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBCDoanhthu";
            this.Text = "BÁO CÁO DOANH THU";
            this.Load += new System.EventHandler(this.frmBCDoanhthu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvbcdt)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvbcdt;
        private System.Windows.Forms.Button btnBatdau;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnHienthi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtDoanhthu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBangchu;
        private System.Windows.Forms.Button btnTimlai;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboManhanvien;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}