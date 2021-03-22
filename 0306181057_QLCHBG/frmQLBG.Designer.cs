namespace _0306181057_QLCHBG
{
    partial class frmQLBG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLBG));
            this.mnChucNang = new System.Windows.Forms.MenuStrip();
            this.taiKhoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangNhapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TTTKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnBot = new System.Windows.Forms.Panel();
            this.lblTGLV = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.lblLoaiNhanVienDangNhap = new DevComponents.DotNetBar.LabelX();
            this.lblTenNhanVienDangNhap = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.lblIDDangNhap = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.timerTGLV = new System.Windows.Forms.Timer(this.components);
            this.mnChucNang.SuspendLayout();
            this.pnBot.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnChucNang
            // 
            this.mnChucNang.AutoSize = false;
            this.mnChucNang.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mnChucNang.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnChucNang.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taiKhoanToolStripMenuItem,
            this.quanLiToolStripMenuItem,
            this.banHangToolStripMenuItem,
            this.khoToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.thoatToolStripMenuItem});
            this.mnChucNang.Location = new System.Drawing.Point(0, 0);
            this.mnChucNang.Name = "mnChucNang";
            this.mnChucNang.Size = new System.Drawing.Size(1382, 35);
            this.mnChucNang.TabIndex = 6;
            this.mnChucNang.Text = "menuStrip1";
            // 
            // taiKhoanToolStripMenuItem
            // 
            this.taiKhoanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dangNhapToolStripMenuItem,
            this.TTTKToolStripMenuItem,
            this.dangXuatToolStripMenuItem});
            this.taiKhoanToolStripMenuItem.Name = "taiKhoanToolStripMenuItem";
            this.taiKhoanToolStripMenuItem.Size = new System.Drawing.Size(85, 31);
            this.taiKhoanToolStripMenuItem.Text = "Tài Khoản";
            this.taiKhoanToolStripMenuItem.ToolTipText = "Các Chức Năng Về Tài Khoản";
            // 
            // dangNhapToolStripMenuItem
            // 
            this.dangNhapToolStripMenuItem.Name = "dangNhapToolStripMenuItem";
            this.dangNhapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.dangNhapToolStripMenuItem.ShowShortcutKeys = false;
            this.dangNhapToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.dangNhapToolStripMenuItem.Text = "Đăng Nhập";
            this.dangNhapToolStripMenuItem.Click += new System.EventHandler(this.dangNhapToolStripMenuItem_Click);
            // 
            // TTTKToolStripMenuItem
            // 
            this.TTTKToolStripMenuItem.Name = "TTTKToolStripMenuItem";
            this.TTTKToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.TTTKToolStripMenuItem.Text = "Thông Tin Tài Khoản";
            this.TTTKToolStripMenuItem.Click += new System.EventHandler(this.TTTKToolStripMenuItem_Click);
            // 
            // dangXuatToolStripMenuItem
            // 
            this.dangXuatToolStripMenuItem.Name = "dangXuatToolStripMenuItem";
            this.dangXuatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.dangXuatToolStripMenuItem.ShowShortcutKeys = false;
            this.dangXuatToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.dangXuatToolStripMenuItem.Text = "Đăng Xuất";
            this.dangXuatToolStripMenuItem.Click += new System.EventHandler(this.dangXuatToolStripMenuItem_Click);
            // 
            // quanLiToolStripMenuItem
            // 
            this.quanLiToolStripMenuItem.Name = "quanLiToolStripMenuItem";
            this.quanLiToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.quanLiToolStripMenuItem.Size = new System.Drawing.Size(71, 31);
            this.quanLiToolStripMenuItem.Text = "Quản Lí";
            this.quanLiToolStripMenuItem.ToolTipText = "Chức năng làm việc của Quản Lí";
            this.quanLiToolStripMenuItem.Click += new System.EventHandler(this.quanLiToolStripMenuItem_Click);
            // 
            // banHangToolStripMenuItem
            // 
            this.banHangToolStripMenuItem.Name = "banHangToolStripMenuItem";
            this.banHangToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.banHangToolStripMenuItem.Size = new System.Drawing.Size(86, 31);
            this.banHangToolStripMenuItem.Text = "Bán Hàng";
            this.banHangToolStripMenuItem.ToolTipText = "Chức năng làm việc của Nhân Viên Bán Hàng";
            this.banHangToolStripMenuItem.Click += new System.EventHandler(this.banHangToolStripMenuItem_Click);
            // 
            // khoToolStripMenuItem
            // 
            this.khoToolStripMenuItem.Name = "khoToolStripMenuItem";
            this.khoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.khoToolStripMenuItem.Size = new System.Drawing.Size(47, 31);
            this.khoToolStripMenuItem.Text = "Kho";
            this.khoToolStripMenuItem.ToolTipText = "Chức năng làm việc của Nhân viên Kho";
            this.khoToolStripMenuItem.Click += new System.EventHandler(this.khoToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 31);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.ToolTipText = "Trợ Giúp";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.thoatToolStripMenuItem.ShowShortcutKeys = false;
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(59, 31);
            this.thoatToolStripMenuItem.Text = "Thoát";
            this.thoatToolStripMenuItem.ToolTipText = "Thoát Chương Trình";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // pnBot
            // 
            this.pnBot.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnBot.Controls.Add(this.lblTGLV);
            this.pnBot.Controls.Add(this.labelX9);
            this.pnBot.Controls.Add(this.lblLoaiNhanVienDangNhap);
            this.pnBot.Controls.Add(this.lblTenNhanVienDangNhap);
            this.pnBot.Controls.Add(this.labelX8);
            this.pnBot.Controls.Add(this.labelX7);
            this.pnBot.Controls.Add(this.lblIDDangNhap);
            this.pnBot.Controls.Add(this.labelX6);
            this.pnBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBot.Location = new System.Drawing.Point(0, 781);
            this.pnBot.Name = "pnBot";
            this.pnBot.Size = new System.Drawing.Size(1382, 42);
            this.pnBot.TabIndex = 14;
            // 
            // lblTGLV
            // 
            this.lblTGLV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.lblTGLV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTGLV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTGLV.Location = new System.Drawing.Point(183, 10);
            this.lblTGLV.Name = "lblTGLV";
            this.lblTGLV.Size = new System.Drawing.Size(122, 23);
            this.lblTGLV.TabIndex = 9;
            // 
            // labelX9
            // 
            this.labelX9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX9.Location = new System.Drawing.Point(12, 10);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(165, 23);
            this.labelX9.TabIndex = 10;
            this.labelX9.Text = "Thời Gian Làm Việc:";
            // 
            // lblLoaiNhanVienDangNhap
            // 
            this.lblLoaiNhanVienDangNhap.Anchor = System.Windows.Forms.AnchorStyles.Right;
            // 
            // 
            // 
            this.lblLoaiNhanVienDangNhap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLoaiNhanVienDangNhap.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblLoaiNhanVienDangNhap.Location = new System.Drawing.Point(1187, 10);
            this.lblLoaiNhanVienDangNhap.Name = "lblLoaiNhanVienDangNhap";
            this.lblLoaiNhanVienDangNhap.Size = new System.Drawing.Size(180, 23);
            this.lblLoaiNhanVienDangNhap.TabIndex = 2;
            // 
            // lblTenNhanVienDangNhap
            // 
            this.lblTenNhanVienDangNhap.Anchor = System.Windows.Forms.AnchorStyles.Right;
            // 
            // 
            // 
            this.lblTenNhanVienDangNhap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTenNhanVienDangNhap.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenNhanVienDangNhap.Location = new System.Drawing.Point(856, 10);
            this.lblTenNhanVienDangNhap.Name = "lblTenNhanVienDangNhap";
            this.lblTenNhanVienDangNhap.Size = new System.Drawing.Size(180, 23);
            this.lblTenNhanVienDangNhap.TabIndex = 4;
            // 
            // labelX8
            // 
            this.labelX8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX8.Location = new System.Drawing.Point(1095, 10);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(73, 23);
            this.labelX8.TabIndex = 5;
            this.labelX8.Text = "Chức Vụ:";
            // 
            // labelX7
            // 
            this.labelX7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX7.Location = new System.Drawing.Point(726, 10);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(120, 23);
            this.labelX7.TabIndex = 6;
            this.labelX7.Text = "Tên Nhân Viên:";
            // 
            // lblIDDangNhap
            // 
            this.lblIDDangNhap.Anchor = System.Windows.Forms.AnchorStyles.Right;
            // 
            // 
            // 
            this.lblIDDangNhap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIDDangNhap.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblIDDangNhap.Location = new System.Drawing.Point(554, 10);
            this.lblIDDangNhap.Name = "lblIDDangNhap";
            this.lblIDDangNhap.Size = new System.Drawing.Size(142, 23);
            this.lblIDDangNhap.TabIndex = 7;
            // 
            // labelX6
            // 
            this.labelX6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX6.Location = new System.Drawing.Point(433, 10);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(108, 23);
            this.labelX6.TabIndex = 8;
            this.labelX6.Text = "ID Nhân Viên:";
            // 
            // timerTGLV
            // 
            this.timerTGLV.Interval = 1000;
            this.timerTGLV.Tick += new System.EventHandler(this.timerTGLV_Tick);
            // 
            // frmQLBG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1382, 823);
            this.Controls.Add(this.pnBot);
            this.Controls.Add(this.mnChucNang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnChucNang;
            this.Name = "frmQLBG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lí cửa hàng bán giày";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQLBG_FormClosing);
            this.Load += new System.EventHandler(this.frmQLBG_Load);
            this.mnChucNang.ResumeLayout(false);
            this.mnChucNang.PerformLayout();
            this.pnBot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnChucNang;
        private System.Windows.Forms.ToolStripMenuItem banHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taiKhoanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dangNhapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TTTKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dangXuatToolStripMenuItem;
        private System.Windows.Forms.Panel pnBot;
        private DevComponents.DotNetBar.LabelX lblLoaiNhanVienDangNhap;
        private DevComponents.DotNetBar.LabelX lblTenNhanVienDangNhap;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX lblIDDangNhap;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX lblTGLV;
        private DevComponents.DotNetBar.LabelX labelX9;
        private System.Windows.Forms.Timer timerTGLV;
        private System.Windows.Forms.ToolStripMenuItem khoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;

    }
}

