namespace _61.CuaHangDoDa.Forms
{
    partial class frmBCHDBan
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
            this.cbomsanpham = new System.Windows.Forms.ComboBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btntimlai = new System.Windows.Forms.Button();
            this.btnin = new System.Windows.Forms.Button();
            this.btndong = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txttongtien = new System.Windows.Forms.TextBox();
            this.dgnhaphang = new System.Windows.Forms.DataGridView();
            this.groupquy = new System.Windows.Forms.GroupBox();
            this.rdobtn4 = new System.Windows.Forms.RadioButton();
            this.rdobtn3 = new System.Windows.Forms.RadioButton();
            this.rdobtn2 = new System.Windows.Forms.RadioButton();
            this.rdobtn1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgnhaphang)).BeginInit();
            this.groupquy.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbomsanpham
            // 
            this.cbomsanpham.FormattingEnabled = true;
            this.cbomsanpham.Location = new System.Drawing.Point(384, 49);
            this.cbomsanpham.Margin = new System.Windows.Forms.Padding(4);
            this.cbomsanpham.Name = "cbomsanpham";
            this.cbomsanpham.Size = new System.Drawing.Size(195, 24);
            this.cbomsanpham.TabIndex = 0;
            // 
            // btntimkiem
            // 
            this.btntimkiem.Image = global::_61.CuaHangDoDa.Properties.Resources.Icojam_Blue_Bits_Application_search;
            this.btntimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimkiem.Location = new System.Drawing.Point(91, 472);
            this.btntimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(131, 52);
            this.btntimkiem.TabIndex = 3;
            this.btntimkiem.Text = "Tìm Kiếm";
            this.btntimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btntimlai
            // 
            this.btntimlai.Image = global::_61.CuaHangDoDa.Properties.Resources.Ahmadhania_Spherical_Redo;
            this.btntimlai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimlai.Location = new System.Drawing.Point(297, 472);
            this.btntimlai.Margin = new System.Windows.Forms.Padding(4);
            this.btntimlai.Name = "btntimlai";
            this.btntimlai.Size = new System.Drawing.Size(131, 52);
            this.btntimlai.TabIndex = 4;
            this.btntimlai.Text = "Tìm Lại";
            this.btntimlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntimlai.UseVisualStyleBackColor = true;
            this.btntimlai.Click += new System.EventHandler(this.btntimlai_Click);
            // 
            // btnin
            // 
            this.btnin.Image = global::_61.CuaHangDoDa.Properties.Resources.Aha_Soft_Universal_Shop_Print;
            this.btnin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnin.Location = new System.Drawing.Point(516, 472);
            this.btnin.Margin = new System.Windows.Forms.Padding(4);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(125, 52);
            this.btnin.TabIndex = 5;
            this.btnin.Text = "Xuất BC";
            this.btnin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnin.UseVisualStyleBackColor = true;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // btndong
            // 
            this.btndong.Image = global::_61.CuaHangDoDa.Properties.Resources.Custom_Icon_Design_Flatastic_9_Login;
            this.btndong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndong.Location = new System.Drawing.Point(725, 472);
            this.btndong.Margin = new System.Windows.Forms.Padding(4);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(107, 52);
            this.btndong.TabIndex = 6;
            this.btndong.Text = "Đóng";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mã Hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 423);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tổng Tiền";
            // 
            // txttongtien
            // 
            this.txttongtien.Location = new System.Drawing.Point(658, 419);
            this.txttongtien.Margin = new System.Windows.Forms.Padding(4);
            this.txttongtien.Name = "txttongtien";
            this.txttongtien.Size = new System.Drawing.Size(132, 22);
            this.txttongtien.TabIndex = 11;
            // 
            // dgnhaphang
            // 
            this.dgnhaphang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgnhaphang.Location = new System.Drawing.Point(53, 227);
            this.dgnhaphang.Margin = new System.Windows.Forms.Padding(4);
            this.dgnhaphang.Name = "dgnhaphang";
            this.dgnhaphang.RowHeadersWidth = 51;
            this.dgnhaphang.Size = new System.Drawing.Size(799, 165);
            this.dgnhaphang.TabIndex = 12;
            // 
            // groupquy
            // 
            this.groupquy.BackColor = System.Drawing.Color.PapayaWhip;
            this.groupquy.Controls.Add(this.rdobtn4);
            this.groupquy.Controls.Add(this.rdobtn3);
            this.groupquy.Controls.Add(this.rdobtn2);
            this.groupquy.Controls.Add(this.rdobtn1);
            this.groupquy.Location = new System.Drawing.Point(387, 102);
            this.groupquy.Margin = new System.Windows.Forms.Padding(4);
            this.groupquy.Name = "groupquy";
            this.groupquy.Padding = new System.Windows.Forms.Padding(4);
            this.groupquy.Size = new System.Drawing.Size(196, 112);
            this.groupquy.TabIndex = 13;
            this.groupquy.TabStop = false;
            // 
            // rdobtn4
            // 
            this.rdobtn4.AutoSize = true;
            this.rdobtn4.Location = new System.Drawing.Point(96, 69);
            this.rdobtn4.Margin = new System.Windows.Forms.Padding(4);
            this.rdobtn4.Name = "rdobtn4";
            this.rdobtn4.Size = new System.Drawing.Size(67, 21);
            this.rdobtn4.TabIndex = 3;
            this.rdobtn4.TabStop = true;
            this.rdobtn4.Text = "Quý 4";
            this.rdobtn4.UseVisualStyleBackColor = true;
            // 
            // rdobtn3
            // 
            this.rdobtn3.AutoSize = true;
            this.rdobtn3.Location = new System.Drawing.Point(96, 23);
            this.rdobtn3.Margin = new System.Windows.Forms.Padding(4);
            this.rdobtn3.Name = "rdobtn3";
            this.rdobtn3.Size = new System.Drawing.Size(67, 21);
            this.rdobtn3.TabIndex = 2;
            this.rdobtn3.TabStop = true;
            this.rdobtn3.Text = "Quý 3";
            this.rdobtn3.UseVisualStyleBackColor = true;
            // 
            // rdobtn2
            // 
            this.rdobtn2.AutoSize = true;
            this.rdobtn2.Location = new System.Drawing.Point(8, 69);
            this.rdobtn2.Margin = new System.Windows.Forms.Padding(4);
            this.rdobtn2.Name = "rdobtn2";
            this.rdobtn2.Size = new System.Drawing.Size(67, 21);
            this.rdobtn2.TabIndex = 1;
            this.rdobtn2.TabStop = true;
            this.rdobtn2.Text = "Quý 2";
            this.rdobtn2.UseVisualStyleBackColor = true;
            // 
            // rdobtn1
            // 
            this.rdobtn1.AutoSize = true;
            this.rdobtn1.Location = new System.Drawing.Point(9, 23);
            this.rdobtn1.Margin = new System.Windows.Forms.Padding(4);
            this.rdobtn1.Name = "rdobtn1";
            this.rdobtn1.Size = new System.Drawing.Size(67, 21);
            this.rdobtn1.TabIndex = 0;
            this.rdobtn1.TabStop = true;
            this.rdobtn1.Text = "Quý 1";
            this.rdobtn1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thời Gian Bán";
            // 
            // frmBCHDBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(912, 554);
            this.Controls.Add(this.groupquy);
            this.Controls.Add(this.dgnhaphang);
            this.Controls.Add(this.txttongtien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnin);
            this.Controls.Add(this.btntimlai);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.cbomsanpham);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBCHDBan";
            this.Text = "Báo cáo hóa đơn bán";
            this.Load += new System.EventHandler(this.frm9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgnhaphang)).EndInit();
            this.groupquy.ResumeLayout(false);
            this.groupquy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbomsanpham;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btntimlai;
        private System.Windows.Forms.Button btnin;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttongtien;
        private System.Windows.Forms.DataGridView dgnhaphang;
        private System.Windows.Forms.GroupBox groupquy;
        private System.Windows.Forms.RadioButton rdobtn4;
        private System.Windows.Forms.RadioButton rdobtn3;
        private System.Windows.Forms.RadioButton rdobtn2;
        private System.Windows.Forms.RadioButton rdobtn1;
        private System.Windows.Forms.Label label1;

    }
}