namespace _61.CuaHangDoDa.Forms
{
    partial class frmBCHDNhap
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
            this.cbonhacc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dghoadonnhap = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txttongtien = new System.Windows.Forms.TextBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btntimlai = new System.Windows.Forms.Button();
            this.btndong = new System.Windows.Forms.Button();
            this.btnin = new System.Windows.Forms.Button();
            this.lbbangchu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dghoadonnhap)).BeginInit();
            this.SuspendLayout();
            // 
            // cbonhacc
            // 
            this.cbonhacc.FormattingEnabled = true;
            this.cbonhacc.Location = new System.Drawing.Point(481, 46);
            this.cbonhacc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbonhacc.Name = "cbonhacc";
            this.cbonhacc.Size = new System.Drawing.Size(160, 24);
            this.cbonhacc.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhà Cung Cấp";
            // 
            // dghoadonnhap
            // 
            this.dghoadonnhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dghoadonnhap.Location = new System.Drawing.Point(82, 122);
            this.dghoadonnhap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dghoadonnhap.Name = "dghoadonnhap";
            this.dghoadonnhap.RowHeadersWidth = 51;
            this.dghoadonnhap.Size = new System.Drawing.Size(820, 209);
            this.dghoadonnhap.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 375);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tổng Tiền";
            // 
            // txttongtien
            // 
            this.txttongtien.Location = new System.Drawing.Point(729, 372);
            this.txttongtien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txttongtien.Name = "txttongtien";
            this.txttongtien.Size = new System.Drawing.Size(132, 22);
            this.txttongtien.TabIndex = 4;
            // 
            // btntimkiem
            // 
            this.btntimkiem.Image = global::_61.CuaHangDoDa.Properties.Resources.Icojam_Blue_Bits_Application_search;
            this.btntimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimkiem.Location = new System.Drawing.Point(103, 446);
            this.btntimkiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(125, 51);
            this.btntimkiem.TabIndex = 5;
            this.btntimkiem.Text = "Tìm Kiếm";
            this.btntimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btntimlai
            // 
            this.btntimlai.Image = global::_61.CuaHangDoDa.Properties.Resources.Ahmadhania_Spherical_Redo;
            this.btntimlai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimlai.Location = new System.Drawing.Point(321, 446);
            this.btntimlai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btntimlai.Name = "btntimlai";
            this.btntimlai.Size = new System.Drawing.Size(125, 51);
            this.btntimlai.TabIndex = 6;
            this.btntimlai.Text = "Tìm Lại";
            this.btntimlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntimlai.UseVisualStyleBackColor = true;
            this.btntimlai.Click += new System.EventHandler(this.btntimlai_Click);
            // 
            // btndong
            // 
            this.btndong.Image = global::_61.CuaHangDoDa.Properties.Resources.Custom_Icon_Design_Flatastic_9_Login;
            this.btndong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndong.Location = new System.Drawing.Point(729, 446);
            this.btndong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(121, 51);
            this.btndong.TabIndex = 7;
            this.btndong.Text = "Đóng";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnin
            // 
            this.btnin.Image = global::_61.CuaHangDoDa.Properties.Resources.Aha_Soft_Universal_Shop_Print;
            this.btnin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnin.Location = new System.Drawing.Point(547, 446);
            this.btnin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(94, 51);
            this.btnin.TabIndex = 8;
            this.btnin.Text = "In";
            this.btnin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnin.UseVisualStyleBackColor = true;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // lbbangchu
            // 
            this.lbbangchu.AutoSize = true;
            this.lbbangchu.Location = new System.Drawing.Point(100, 377);
            this.lbbangchu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbbangchu.Name = "lbbangchu";
            this.lbbangchu.Size = new System.Drawing.Size(78, 17);
            this.lbbangchu.TabIndex = 9;
            this.lbbangchu.Text = "Bàng Chũ: ";
            // 
            // frmBCHDNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(980, 521);
            this.Controls.Add(this.lbbangchu);
            this.Controls.Add(this.btnin);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btntimlai);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.txttongtien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dghoadonnhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbonhacc);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmBCHDNhap";
            this.Text = "Báo cáo hóa đơn nhập";
            this.Load += new System.EventHandler(this.frm_7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dghoadonnhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbonhacc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dghoadonnhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttongtien;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btntimlai;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnin;
        private System.Windows.Forms.Label lbbangchu;
    }
}