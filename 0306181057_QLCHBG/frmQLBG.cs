using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _0306181057_QLCHBG
{
    public partial class frmQLBG : Form
    {
        public frmQLBG()
        {
            InitializeComponent();
            dangNhapToolStripMenuItem.PerformClick();
            LoadChuaDangNhap();
        }

        #region Hàm
        public void TatFormCon()
        {
            foreach (Form formCon in this.MdiChildren)
            {
                formCon.Close();
            }
        }
        public void LoadChuaDangNhap()
        {
            dangNhapToolStripMenuItem.Enabled = true;
            quanLiToolStripMenuItem.Enabled = false;
            banHangToolStripMenuItem.Enabled = false;
            khoToolStripMenuItem.Enabled = false;
            TTTKToolStripMenuItem.Enabled = false;
            dangXuatToolStripMenuItem.Enabled = false;
            pnBot.Visible = false;
            DongTGLV();
        }

        public void LoadQLDaDangNhap()
        {
            dangNhapToolStripMenuItem.Enabled = false;
            quanLiToolStripMenuItem.Enabled = true;
            banHangToolStripMenuItem.Enabled = true;
            khoToolStripMenuItem.Enabled = true;
            TTTKToolStripMenuItem.Enabled = true;
            dangXuatToolStripMenuItem.Enabled = true;
            pnBot.Visible = true;
            LoadTTDangNhap();
            ChayTGLV();
        }

        public void LoadTNDaDangNhap()
        {
            dangNhapToolStripMenuItem.Enabled = false;
            quanLiToolStripMenuItem.Enabled = false;
            banHangToolStripMenuItem.Enabled = true;
            khoToolStripMenuItem.Enabled = false;
            TTTKToolStripMenuItem.Enabled = true;
            dangXuatToolStripMenuItem.Enabled = true;
            pnBot.Visible = true;
            LoadTTDangNhap();
            ChayTGLV();
        }

        public void LoadKhoDaDangNhap()
        {
            dangNhapToolStripMenuItem.Enabled = false;
            quanLiToolStripMenuItem.Enabled = false;
            banHangToolStripMenuItem.Enabled = false;
            khoToolStripMenuItem.Enabled = true;
            TTTKToolStripMenuItem.Enabled = true;
            dangXuatToolStripMenuItem.Enabled = true;
            pnBot.Visible = true;
            LoadTTDangNhap();
            ChayTGLV();
        }

        void LoadTTDangNhap()
        {
            lblIDDangNhap.Text = BienToanCuc.nvDangNhap.idNhanVien;
            lblTenNhanVienDangNhap.Text = BienToanCuc.nvDangNhap.tenNhanVien;
            lblLoaiNhanVienDangNhap.Text = BienToanCuc.nvDangNhap.loaiNhanVien;
        }

        DateTime da;
        public void ChayTGLV()
        {
            timerTGLV.Start();
            timerTGLV.Interval = 1000;
            da = DateTime.Now;
        }

        public void DongTGLV()
        {
            timerTGLV.Stop();
        }

        #endregion

        #region Sự Kiện
        private void dangNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TatFormCon();
            frmDangNhap f = new frmDangNhap();
            f.MdiParent = this;
            f.Show();
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn đăng xuất ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                NhanVien_DTO nv = new NhanVien_DTO();
                BienToanCuc.nvDangNhap = nv;
                LoadChuaDangNhap();
                TatFormCon();
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void quanLiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TatFormCon();
            frmQuanLi f = new frmQuanLi();
            f.MdiParent = this;
            f.Show();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TTTKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTTTK f = new frmTTTK();
            f.ShowDialog();
        }

        private void banHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TatFormCon();
            frmBanHang f = new frmBanHang();
            f.MdiParent = this;
            f.Show();
        }

        private void timerTGLV_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now.Subtract(da);
            lblTGLV.Text = span.Hours.ToString() + " : " + span.Minutes.ToString() + " : " + span.Seconds.ToString();
        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TatFormCon();
            frmQLKho f = new frmQLKho();
            f.MdiParent = this;
            f.Show();
        }

        private void frmQLBG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #endregion

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Users\lemin\OneDrive\Máy tính\HDSD.pdf");

            }
            catch {
                MessageBox.Show("Không Tìm Thấy File.");
            }
        }

        private void frmQLBG_Load(object sender, EventArgs e)
        {

        }

        private void huyHDToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
