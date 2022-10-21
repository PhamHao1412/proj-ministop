namespace QuanLyTiemTapHoa
{
    partial class frmMenu
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbChucVu = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNhaCungCap = new System.Windows.Forms.Button();
            this.btnDonViSP = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnTonKho = new System.Windows.Forms.Button();
            this.btnNhapKho = new System.Windows.Forms.Button();
            this.btnDonHang = new System.Windows.Forms.Button();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbChucVu);
            this.panel1.Controls.Add(this.lbUser);
            this.panel1.Controls.Add(this.lbTime);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 77);
            this.panel1.TabIndex = 0;
            // 
            // lbChucVu
            // 
            this.lbChucVu.AutoSize = true;
            this.lbChucVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChucVu.Location = new System.Drawing.Point(266, 43);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(61, 19);
            this.lbChucVu.TabIndex = 2;
            this.lbChucVu.Text = "Chức vụ";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(266, 9);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(114, 19);
            this.lbUser.TabIndex = 1;
            this.lbUser.Text = "Tên người dùng";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(451, 9);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(123, 19);
            this.lbTime.TabIndex = 0;
            this.lbTime.Text = "Thời Gian Hiện Tại";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNhaCungCap);
            this.panel2.Controls.Add(this.btnDonViSP);
            this.panel2.Controls.Add(this.btnDangXuat);
            this.panel2.Controls.Add(this.btnThongKe);
            this.panel2.Controls.Add(this.btnNhanVien);
            this.panel2.Controls.Add(this.btnTonKho);
            this.panel2.Controls.Add(this.btnNhapKho);
            this.panel2.Controls.Add(this.btnDonHang);
            this.panel2.Controls.Add(this.btnBanHang);
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 365);
            this.panel2.TabIndex = 1;
            // 
            // btnNhaCungCap
            // 
            this.btnNhaCungCap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhaCungCap.Image = global::QuanLyTiemTapHoa.Properties.Resources.Nhà_cung_cấp;
            this.btnNhaCungCap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhaCungCap.Location = new System.Drawing.Point(434, 184);
            this.btnNhaCungCap.Name = "btnNhaCungCap";
            this.btnNhaCungCap.Size = new System.Drawing.Size(141, 46);
            this.btnNhaCungCap.TabIndex = 9;
            this.btnNhaCungCap.Text = "Nhà cung cấp";
            this.btnNhaCungCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNhaCungCap.UseVisualStyleBackColor = true;
            this.btnNhaCungCap.Click += new System.EventHandler(this.btnNhaCungCap_Click);
            // 
            // btnDonViSP
            // 
            this.btnDonViSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonViSP.Image = global::QuanLyTiemTapHoa.Properties.Resources.Tồn_kho;
            this.btnDonViSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonViSP.Location = new System.Drawing.Point(434, 72);
            this.btnDonViSP.Name = "btnDonViSP";
            this.btnDonViSP.Size = new System.Drawing.Size(141, 46);
            this.btnDonViSP.TabIndex = 8;
            this.btnDonViSP.Text = "Đơn vị SP";
            this.btnDonViSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDonViSP.UseVisualStyleBackColor = true;
            this.btnDonViSP.Click += new System.EventHandler(this.btnDonViSP_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.Image = global::QuanLyTiemTapHoa.Properties.Resources.Đăng_xuất;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(656, 316);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(141, 46);
            this.btnDangXuat.TabIndex = 7;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Image = global::QuanLyTiemTapHoa.Properties.Resources.Thống_kê;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(614, 185);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(141, 46);
            this.btnThongKe.TabIndex = 6;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.Image = global::QuanLyTiemTapHoa.Properties.Resources.Nhân_viên;
            this.btnNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.Location = new System.Drawing.Point(614, 72);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(141, 46);
            this.btnNhanVien.TabIndex = 5;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnTonKho
            // 
            this.btnTonKho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTonKho.Image = global::QuanLyTiemTapHoa.Properties.Resources.Tồn_kho;
            this.btnTonKho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTonKho.Location = new System.Drawing.Point(245, 184);
            this.btnTonKho.Name = "btnTonKho";
            this.btnTonKho.Size = new System.Drawing.Size(141, 46);
            this.btnTonKho.TabIndex = 4;
            this.btnTonKho.Text = "Tồn kho";
            this.btnTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTonKho.UseVisualStyleBackColor = true;
            this.btnTonKho.Click += new System.EventHandler(this.btnTonKho_Click);
            // 
            // btnNhapKho
            // 
            this.btnNhapKho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapKho.Image = global::QuanLyTiemTapHoa.Properties.Resources.Nhập_kho;
            this.btnNhapKho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapKho.Location = new System.Drawing.Point(245, 72);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Size = new System.Drawing.Size(141, 46);
            this.btnNhapKho.TabIndex = 3;
            this.btnNhapKho.Text = "Nhập kho";
            this.btnNhapKho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNhapKho.UseVisualStyleBackColor = true;
            this.btnNhapKho.Click += new System.EventHandler(this.btnNhapKho_Click);
            // 
            // btnDonHang
            // 
            this.btnDonHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonHang.Image = global::QuanLyTiemTapHoa.Properties.Resources.Đơn_hàng;
            this.btnDonHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonHang.Location = new System.Drawing.Point(49, 184);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Size = new System.Drawing.Size(141, 46);
            this.btnDonHang.TabIndex = 2;
            this.btnDonHang.Text = "Đơn hàng";
            this.btnDonHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDonHang.UseVisualStyleBackColor = true;
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanHang.Image = global::QuanLyTiemTapHoa.Properties.Resources.Sản_phẩm;
            this.btnBanHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHang.Location = new System.Drawing.Point(49, 72);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(141, 46);
            this.btnBanHang.TabIndex = 0;
            this.btnBanHang.Text = "Bán hàng";
            this.btnBanHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBanHang.UseVisualStyleBackColor = true;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMenu";
            this.Text = "MenuChucNang";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnTonKho;
        private System.Windows.Forms.Button btnNhapKho;
        private System.Windows.Forms.Button btnDonHang;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnDonViSP;
        private System.Windows.Forms.Button btnNhaCungCap;
        private System.Windows.Forms.Label lbChucVu;
    }
}