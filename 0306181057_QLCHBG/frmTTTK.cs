using BUS;
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

namespace _0306181057_QLCHBG
{
    public partial class frmTTTK : Form
    {
        public frmTTTK()
        {
            InitializeComponent();
            LoadNV();
            dtpNgaySinh.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
        }

        #region Hàm
        
        public void LoadNV()
        {
            NhanVien_BUS nv_bus = new NhanVien_BUS();
            NhanVien_DTO nv = nv_bus.LayNV(BienToanCuc.nvDangNhap.idNhanVien);
            txtID.Text = nv.idNhanVien;
            txtMatKhau.Text = nv.matKhau;
            txtTenNhanVien.Text = nv.tenNhanVien;
            txtCMND.Text = nv.cmnd;
            txtSDT.Text = nv.sdt;
            txtDiaChi.Text = nv.diaChi;
            dtpNgaySinh.Value = nv.ngaySinh;
        }
        
        #endregion

        #region Sự Kiện
        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO(txtID.Text, txtMatKhau.Text, txtTenNhanVien.Text, txtCMND.Text, txtSDT.Text, dtpNgaySinh.Value, txtDiaChi.Text, BienToanCuc.nvDangNhap.loaiNhanVien, 1);
            NhanVien_BUS nv_bus = new NhanVien_BUS();
            if (nv_bus.Sua(nv))
            {
                MessageBox.Show("Sửa thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
