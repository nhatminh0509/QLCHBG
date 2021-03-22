using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0306181057_QLCHBG
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            NhanVien_BUS nv_bus = new NhanVien_BUS();
            if (nv_bus.DangNhap(txtUser.Text, txtPass.Text))
            {
                BienToanCuc.nvDangNhap = nv_bus.LayNV(txtUser.Text);
                frmQLBG frmQLBG = (this.MdiParent as frmQLBG);
                
                if (BienToanCuc.nvDangNhap.loaiNhanVien == "Kho")
                {
                    frmQLBG.LoadKhoDaDangNhap();
                    frmQLKho frmQLKho = new frmQLKho();
                    frmQLKho.MdiParent = this.MdiParent;
                    frmQLKho.Show();
                }
                else if (BienToanCuc.nvDangNhap.loaiNhanVien == "Thu Ngân")
                {
                    frmQLBG.LoadTNDaDangNhap();
                    frmBanHang frmBanHang = new frmBanHang();
                    frmBanHang.MdiParent = this.MdiParent;
                    frmBanHang.Show();
                }
                else
                {
                    frmQLBG.LoadQLDaDangNhap();
                    frmQuanLi frmQuanLi = new frmQuanLi();
                    frmQuanLi.MdiParent = this.MdiParent;
                    frmQuanLi.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
