namespace _61.CuaHangDoDa.Forms
{
        partial class frmbaocaodanhsachsanpham
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbomanhanvien = new System.Windows.Forms.ComboBox();
            this.cbomakhachhang = new System.Windows.Forms.ComboBox();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btntimlai = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btninbaocao = new System.Windows.Forms.Button();
            this.btnhienthi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txttongtienbaocao = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(106, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(615, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo cáo danh sách các sản phẩm được mua";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã nhân viên";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.cbomanhanvien);
            this.groupBox1.Controls.Add(this.cbomakhachhang);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(113, 92);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(618, 102);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // cbomanhanvien
            // 
            this.cbomanhanvien.FormattingEnabled = true;
            this.cbomanhanvien.Location = new System.Drawing.Point(460, 48);
            this.cbomanhanvien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbomanhanvien.Name = "cbomanhanvien";
            this.cbomanhanvien.Size = new System.Drawing.Size(121, 24);
            this.cbomanhanvien.TabIndex = 6;
            // 
            // cbomakhachhang
            // 
            this.cbomakhachhang.FormattingEnabled = true;
            this.cbomakhachhang.Location = new System.Drawing.Point(148, 48);
            this.cbomakhachhang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbomakhachhang.Name = "cbomakhachhang";
            this.cbomakhachhang.Size = new System.Drawing.Size(121, 24);
            this.cbomakhachhang.TabIndex = 5;
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(35, 218);
            this.DataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowHeadersWidth = 51;
            this.DataGridView.RowTemplate.Height = 24;
            this.DataGridView.Size = new System.Drawing.Size(765, 150);
            this.DataGridView.TabIndex = 6;
            this.DataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(52, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(328, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Kích đúp vào một hóa đơn để hiện thông tin chi tiết";
            // 
            // btntimlai
            // 
            this.btntimlai.Image = global::_61.CuaHangDoDa.Properties.Resources.Ahmadhania_Spherical_Redo;
            this.btntimlai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimlai.Location = new System.Drawing.Point(256, 432);
            this.btntimlai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntimlai.Name = "btntimlai";
            this.btntimlai.Size = new System.Drawing.Size(106, 55);
            this.btntimlai.TabIndex = 10;
            this.btntimlai.Text = "Tìm lại";
            this.btntimlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntimlai.UseVisualStyleBackColor = true;
            this.btntimlai.Click += new System.EventHandler(this.btntimlai_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Image = global::_61.CuaHangDoDa.Properties.Resources.Custom_Icon_Design_Flatastic_9_Login;
            this.btnthoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthoat.Location = new System.Drawing.Point(650, 432);
            this.btnthoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(106, 55);
            this.btnthoat.TabIndex = 9;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btninbaocao
            // 
            this.btninbaocao.Image = global::_61.CuaHangDoDa.Properties.Resources.Aha_Soft_Universal_Shop_Print;
            this.btninbaocao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btninbaocao.Location = new System.Drawing.Point(437, 432);
            this.btninbaocao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btninbaocao.Name = "btninbaocao";
            this.btninbaocao.Size = new System.Drawing.Size(148, 55);
            this.btninbaocao.TabIndex = 8;
            this.btninbaocao.Text = "In báo cáo";
            this.btninbaocao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btninbaocao.UseVisualStyleBackColor = true;
            this.btninbaocao.Click += new System.EventHandler(this.btninbaocao_Click);
            // 
            // btnhienthi
            // 
            this.btnhienthi.Image = global::_61.CuaHangDoDa.Properties.Resources.Iconsmind_Outline_Monitor_Analytics;
            this.btnhienthi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhienthi.Location = new System.Drawing.Point(80, 432);
            this.btnhienthi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnhienthi.Name = "btnhienthi";
            this.btnhienthi.Size = new System.Drawing.Size(122, 55);
            this.btnhienthi.TabIndex = 7;
            this.btnhienthi.Text = "Hiển thị";
            this.btnhienthi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnhienthi.UseVisualStyleBackColor = true;
            this.btnhienthi.Click += new System.EventHandler(this.btnhienthi_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(489, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tổng tiền báo cáo";
            // 
            // txttongtienbaocao
            // 
            this.txttongtienbaocao.Location = new System.Drawing.Point(650, 385);
            this.txttongtienbaocao.Name = "txttongtienbaocao";
            this.txttongtienbaocao.Size = new System.Drawing.Size(100, 22);
            this.txttongtienbaocao.TabIndex = 13;
            // 
            // frmbaocaodanhsachsanpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(840, 516);
            this.Controls.Add(this.txttongtienbaocao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btntimlai);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btninbaocao);
            this.Controls.Add(this.btnhienthi);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmbaocaodanhsachsanpham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo danh sách sản phẩm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmbaocaodanhsachsanpham_FormClosing);
            this.Load += new System.EventHandler(this.frmbaocaodanhsachsanpham_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.GroupBox groupBox1;
            private System.Windows.Forms.ComboBox cbomanhanvien;
            private System.Windows.Forms.ComboBox cbomakhachhang;
            private System.Windows.Forms.DataGridView DataGridView;
            private System.Windows.Forms.Button btnhienthi;
            private System.Windows.Forms.Button btninbaocao;
            private System.Windows.Forms.Button btnthoat;
            private System.Windows.Forms.Button btntimlai;
            private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttongtienbaocao;
    }
   }